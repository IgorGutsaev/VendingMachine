using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.Common.Abstractions.Hardware
{
    /// <summary>
    /// Port state codes
    /// </summary>
    public enum PortResultCodes // TODO: Rename to PortCode
    {
        Success = 0,
        PortClosed = 1,
        /// <summary>
        /// Timeout (error?)
        /// </summary>
        Timeout = 2,

        /// <summary>
        ///     Ошибка контрольной суммы
        /// </summary>
        CrcFailed = 3, // TODO: Abolish

        /// <summary>
        ///     Порт не существует, для USB-конвертеров типичная ошибка при извлечении устройства.
        /// </summary>
        PortDoesNotExists = 4,

        /// <summary>
        ///     Ошибка
        /// </summary>
        Failure = 5
    }
}
