using Filuet.Utils.Common.Business;

namespace Filuet.ASC.Kiosk.OnBoard.Catalog.Abstractions.Services
{
    public interface ICatalogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="uid">sku</param>
        /// <param name="language"></param>
        /// <returns></returns>
        string GetName(string uid, Lang language);
    }
}
