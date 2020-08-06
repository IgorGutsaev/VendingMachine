using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Enums;
using Filuet.ASC.Kiosk.OnBoard.UVS.Abstractions.Interfaces;
using System.Collections.Generic;

namespace Filuet.ASC.Kiosk.OnBoard.UVS.Core
{
    public class GenericResult : IGenericResult
    {
        /// <summary>
        /// </summary>
        /// <param name="genericResultCode"></param>
        /// <param name="code"></param>
        /// <param name="description"></param>
        public GenericResult(GenericResultCodes genericResultCode, int code, string description)
        {
            GenericResultCode = genericResultCode;
            Code = code;
            Description = description;
            SubResults = new List<IGenericResult>();
        }

        /// <summary>
        /// </summary>
        /// <param name="genericResultCode"></param>
        /// <param name="code"></param>
        public GenericResult(GenericResultCodes genericResultCode, int code)
            : this(genericResultCode, code, genericResultCode.ToString())
        {
            GenericResultCode = genericResultCode;
        }

        /// <summary>
        /// </summary>
        /// <param name="genericResultCode"></param>
        public GenericResult(GenericResultCodes genericResultCode)
            : this(genericResultCode, genericResultCode == GenericResultCodes.SUCCESS ? 0 : 1)
        {
            GenericResultCode = genericResultCode;
        }

        /// <summary>
        ///     Статус ответа
        /// </summary>
        public GenericResultCodes GenericResultCode { get; }

        /// <summary>
        ///     Код ответа
        /// </summary>
        public int Code { get; }

        /// <summary>
        ///     Описание ответа
        /// </summary>
        public string Description { get; }

        /// <summary>
        ///     Под результаты.
        /// </summary>
        public List<IGenericResult> SubResults { get; }

        public object Tag { get; set; }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"GenericResultCode={GenericResultCode}; Code={Code}; Description={Description}";
        }
    }
}
