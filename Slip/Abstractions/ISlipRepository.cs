using Filuet.Utils.Common.Business;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public interface ISlipRepository
    {
        /// <summary>
        /// Standard slip
        /// </summary>
        /// <param name="location"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        string GetStandard(Locale location, Lang language);

        /// <summary>
        /// Emergency slip
        /// </summary>
        /// <param name="location"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        string GetCrash(Locale location, Lang language);

        /// <summary>
        /// Test slip
        /// </summary>
        /// <param name="location"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        string GetTest(Locale location, Lang language);

        /// <summary>
        /// Order position
        /// </summary>
        /// <param name="location"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        string GetOrderLine(Locale location, Lang language);

        string GetBarcode(Locale location, Lang language);
    }
}
