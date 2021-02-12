using Filuet.Utils.Common.Business;

namespace Filuet.ASC.Kiosk.OnBoard.SlipAbstractions
{
    public interface ISlipRepository
    {
        /// <summary>
        /// standard slip
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        string GetStandard(Locale location);

        /// <summary>
        /// emergency slip
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        string GetCrash(Locale location);

        /// <summary>
        /// test slip
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        string GetTest(Locale location);
    }
}
