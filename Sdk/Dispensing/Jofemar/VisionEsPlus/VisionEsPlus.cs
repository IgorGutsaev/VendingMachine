using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Text;
using System.Threading;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus
{
    public class VisionEsPlus
    {
        private VisionEsPlusSettings _settings;
        private SerialPort _port;
        private readonly byte[] _messagePacket;
        private byte[] _lastTestResponse;

        public VisionEsPlus(VisionEsPlusSettings settings)
        {
            _settings = settings;
            _messagePacket = new byte[] { 0x02, 0x30, 0x30, (byte)(_settings.Address + 0x80), 0, 0xff, 0xff, 0, 0, 3 };
        }

        #region Actions
        internal void ChangeLight(bool isOn)
        {
            _settings.LightSettings.LightIsOn = isOn;
            //// OnSettingsChanged.Invoke
            Execute(ChangeLightCommand(isOn));
        }

        internal void Blink(TimeSpan? duration = null)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool lightIsOn = _settings.LightSettings.LightIsOn;
            while (sw.Elapsed < duration)
            {
                Execute(ChangeLightCommand(!lightIsOn));
                lightIsOn = !lightIsOn;
                Thread.Sleep(_settings.LightSettings.BlinkingPeriod);
            }
            sw.Stop();
        }

        internal (DeviceStateSeverity state, string message) Status(bool retryIfFaulty = true)
        {
            byte[] response = Execute(StatusCommand());

            if ((response == null || response.Length == 0) && _lastTestResponse != null)
                response = _lastTestResponse;

            _lastTestResponse = response;
            VisionEsPlusResponseCodes code = ParseResponse(response);

            switch (code)
            {
                case VisionEsPlusResponseCodes.Unknown: // need to resend request in case of unknown status
                    {
                        if (retryIfFaulty)
                            return Status(false);
                        else return (DeviceStateSeverity.Inoperable, "The door is probably open");
                    }
                case VisionEsPlusResponseCodes.Ok:
                case VisionEsPlusResponseCodes.Ready:
                case VisionEsPlusResponseCodes.FaultIn485Bus:
                    return (DeviceStateSeverity.Normal, string.Empty);
                default:
                    switch (TryGetDoorState(response))
                    {
                        case DoorState.DoorClosed:
                            return (DeviceStateSeverity.Normal, "The door was closed");
                        case DoorState.DoorOpen:
                            return (DeviceStateSeverity.MaintenanceService, "The door is open");
                        case DoorState.Unknown:
                        default:
                            return (DeviceStateSeverity.Inoperable, string.Empty);
                    }
            }
        }

        internal void DispenseProduct(int tray, int belt)
        {
            byte[] response = Execute(VendCommand(tray, belt));
            VisionEsPlusResponseCodes code = ParseResponse(response);
        }

        internal bool IsBeltAvailable(int tray, int belt)
        {
            byte[] response = Execute(CheckChannelCommand(tray, belt));

            return response.Length == 8 && response[4] == 0x43; // 0x44 means bealt is unavailable
        }
        #endregion

        #region Commands
        /// <summary>
        /// Turn on/off the light
        /// </summary>
        /// <returns>команда</returns>
        private byte[] ChangeLightCommand(bool isOn)
        {
            var comm = new byte[_messagePacket.Length];
            Array.Copy(_messagePacket, comm, _messagePacket.Length);
            comm[4] = 0x4c;
            if (isOn)
                comm[5] = 0x81;
            else comm[5] = 0x80;
            InjectCheckSumm(comm);
            return comm;
        }

        /// <summary>
        /// Get status of dispensing machine
        /// </summary>
        /// <returns>команда</returns>
        private byte[] StatusCommand()
        {
            var comm = new byte[_messagePacket.Length];
            Array.Copy(_messagePacket, comm, _messagePacket.Length);
            comm[4] = 0x53;
            InjectCheckSumm(comm);
            return comm;
        }

        /// <summary>
        /// Get status of dispensing machine
        /// </summary>
        /// <returns>команда</returns>
        private byte[] CheckChannelCommand(int tray, int belt)
        {
            var comm = new byte[_messagePacket.Length];
            Array.Copy(_messagePacket, comm, _messagePacket.Length);
            comm[4] = 0x43;
            comm[5] = 0x43;
            comm[6] = (byte)(tray * 10 + belt);
            InjectCheckSumm(comm);
            return comm;
        }

        /// <summary>
        ///     Выдача товара с парковкой лифта
        /// </summary>
        /// <param name="tray"></param>
        /// <param name="belt"></param>
        /// <returns></returns>
        private byte[] VendCommand(int tray, int belt)
        {
            var retval = new byte[_messagePacket.Length];
            Array.Copy(_messagePacket, retval, _messagePacket.Length);
            retval[4] = 0x56;
            retval[5] = (byte)(tray + 0x80);
            retval[6] = (byte)(belt + 0x80);
            InjectCheckSumm(retval);
            return retval;
        }
        #endregion

        #region Private
        /// <summary>
        /// 
        /// </summary>
        /// <param name="command">executable command</param>
        /// <param name="timeout"></param>
        /// <returns>Command result</returns>
        private byte[] Execute(byte[] command)
        {
            if (_port == null)
                _port = new SerialPort($"COM{_settings.SerialPortNumber}", _settings.BaudRate);

            lock (_port)
            {
                var count = 0;
                while (true)
                {
                    var result = Write(command);
                    if (result != PortResultCodes.Success)
                        return null; //throw new ExternalException($"Error in [{Port.Name}] write command [{command.ByteArrayToString()}]");
                    Thread.Sleep(_settings.CommandsSendDelay);

                    byte[] buff;
                    var response = Read(out buff);
                    if (response == PortResultCodes.Success)
                        return buff;

                    if (count > (_settings.Timeout.TotalMilliseconds / _settings.CommandsSendDelay.TotalMilliseconds))
                        return null; //throw new TimeoutException($"Timeout in read answer on command [{command.ByteArrayToString()}]");

                    Thread.Sleep(_settings.CommandsSendDelay);
                    count++;
                }
            }
        }

        /// <summary>
        ///     Упаковывает и записывает в порт команду
        /// </summary>
        /// <param name="command">Команда</param>
        /// <returns>Результат записи в порт</returns>
        private PortResultCodes Write(byte[] command)
        {
            try
            {
                if (!_port.IsOpen)
                    _port.Open();
                if (!_port.IsOpen)
                    return PortResultCodes.PortClosed;

                _port.Write(command, 0, command.Length);

                Thread.Sleep(_settings.CommandsSendDelay);

                Console.WriteLine($"[{_port.PortName}] {Encoding.Default.GetString(command)}");
                return PortResultCodes.Success;
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[{_port.PortName}] timeout");
                return PortResultCodes.Timeout;
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException || ex is ArgumentException)
            {
                Console.WriteLine($"[{_port.PortName}] invalid command");
                return PortResultCodes.Failure;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"[{_port.PortName}] port closed");
                return PortResultCodes.PortClosed;
            }
        }

        /// <summary>
        ///     Считывает из порта пакет данных
        /// </summary>
        /// <returns></returns>
        private PortResultCodes Read(out byte[] buffer)
        {
            if (!_port.IsOpen)
                _port.Open();
            if (!_port.IsOpen)
            {
                buffer = null;
                return PortResultCodes.PortClosed;
            }

            byte[] data = new byte[_port.BytesToRead];

            try
            {
                _port.Read(data, 0, data.Length);
                buffer = data;
                Console.WriteLine($"[{_port.PortName}] {(buffer?.Length > 0 ? Encoding.Default.GetString(buffer) : string.Empty)}");
                return PortResultCodes.Success;
            }
            catch (TimeoutException)
            {
                Console.WriteLine($"[{_port.PortName}] timeout");
                buffer = null;
                return PortResultCodes.Timeout;
            }
            catch (Exception ex) when (ex is ArgumentNullException || ex is ArgumentOutOfRangeException || ex is ArgumentException)
            {
                Console.WriteLine($"[{_port.PortName}] invalid command");
                buffer = null;
                return PortResultCodes.Failure;
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"[{_port.PortName}] port closed");
                buffer = null;
                return PortResultCodes.PortClosed;
            }
        }

        /// <summary>
        /// Вставляет во второй и третий с конца байты контрольную сумму в соответствии с протоколом
        /// </summary>
        /// <param name="message">сообщение</param>
        private void InjectCheckSumm(IList<byte> message)
        {
            var summ = 0;
            for (var i = 0; i < message.Count - 3; i++)
                summ += message[i];
            summ &= 0xff;
            message[message.Count - 3] = (byte)(summ | 0xf0);
            message[message.Count - 2] = (byte)(summ | 0x0f);
        }

        /// <summary>
        /// Takes last byte from response array and converts it to <see cref="VisionEsPlusResponseCodes" />
        /// </summary>
        /// <param name="response"></param>
        private VisionEsPlusResponseCodes ParseResponse(IReadOnlyList<byte> response)
        {
            if (response != null && (response.Count > 10 || response.Count == 0))
                return VisionEsPlusResponseCodes.Unknown;
            return response == null ? VisionEsPlusResponseCodes.Unknown : (VisionEsPlusResponseCodes)response[response.Count - 1];
        }

        public DoorState TryGetDoorState(byte[] arr)
        {
            if (arr == null || arr.Length != 7 || arr[2] != 0x50)
                return DoorState.Unknown;
            var doorState = (DoorState)arr[3];
            return doorState;
        }
        #endregion
    }
}
