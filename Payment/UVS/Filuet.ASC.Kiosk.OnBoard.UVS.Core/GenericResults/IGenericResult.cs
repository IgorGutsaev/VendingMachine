using System;
using System.Collections.Generic;
using System.Text;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core.GenericResults
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
