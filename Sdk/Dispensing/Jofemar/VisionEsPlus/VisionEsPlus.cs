﻿using Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware;
using Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus.Enums;
using Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus.Models;
using Filuet.Utils.Abstractions.Communication;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO.Ports;
using System.Threading;

namespace Filuet.ASC.Kiosk.OnBoard.SDK.Jofemar.VisionEsPlus
{
    public class VisionEsPlus
    {
        private VisionEsPlusSettings _settings;
        private SerialPort _port;
        private readonly byte[] _messagePacket;
        private byte[] _lastTestResponse;
        private ICommunicationChannel _channel;

        public VisionEsPlus(ICommunicationChannel channel, VisionEsPlusSettings settings)
        {
            _settings = settings;
            byte machineAddress = (byte)(Byte.Parse(_settings.Address.Substring(2), NumberStyles.HexNumber) + 0x80);
            _messagePacket = new byte[] { 0x02, 0x30, 0x30, machineAddress /* 0x81*/, 0, 0xff, 0xff, 0, 0, 3 };
            _channel = channel;
        }

        #region Actions
        internal void ChangeLight(bool isOn)
        {
            _settings.LightSettings.LightIsOn = isOn;
            //// OnSettingsChanged.Invoke
            _channel.SendCommand(ChangeLightCommand(isOn));
        }

        internal void Blink(TimeSpan? duration = null)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            bool lightIsOn = _settings.LightSettings.LightIsOn;
            while (sw.Elapsed < duration)
            {
                _channel.SendCommand(ChangeLightCommand(!lightIsOn));
                lightIsOn = !lightIsOn;
                Thread.Sleep(_settings.LightSettings.BlinkingPeriod);
            }
            sw.Stop();
        }

        internal (DeviceStateSeverity state, string message) Status(bool retryIfFaulty = true)
        {
            byte[] response = _channel.SendCommand(StatusCommand());

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

        internal void DispenseProduct(EspBeltAddress address)
        {
            byte[] response = _channel.SendCommand(VendCommand(address.Tray, address.Belt));
            VisionEsPlusResponseCodes code = ParseResponse(response);
        }

        internal bool IsBeltAvailable(EspBeltAddress address)
        {
            byte[] response = _channel.SendCommand(CheckChannelCommand(address.Tray, address.Belt));

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
