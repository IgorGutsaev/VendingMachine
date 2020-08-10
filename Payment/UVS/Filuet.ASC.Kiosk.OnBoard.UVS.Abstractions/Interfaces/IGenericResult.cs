using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Enums;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces
{
    public interface IGenericResult
    {
        /// <summary>
        ///     Статус ответа
        /// </summary>
        GenericResultCodes GenericResultCode { get; }

        /// <summary>
        ///     Код ответа
        /// </summary>
        int Code { get; }

        /// <summary>
        ///     Описание ответа
        /// </summary>
        string Description { get; }

        /// <summary>
        ///     Под результаты.
        /// </summary>
        List<IGenericResult> SubResults { get; }

        /// <summary>
        /// Дополнительные данные произвольного типа
        /// </summary>
        object Tag { get; set; }
    }
}
