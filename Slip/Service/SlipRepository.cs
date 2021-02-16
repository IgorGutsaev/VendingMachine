using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions.Enums;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace Filuet.ASC.Kiosk.OnBoard.SlipService
{
    public class SlipRepository : ISlipRepository
    {
        public SlipRepository(string repositoryPath)
        {
            _repositoryPath = repositoryPath;
            if (!Directory.Exists(_repositoryPath))
            {
                string path = Environment.CurrentDirectory + repositoryPath;
                if (!Directory.Exists(path))
                    throw new DirectoryNotFoundException(_repositoryPath);
                else _repositoryPath = path;
            }
        }

        /// <summary>
        /// A standard slip of an order
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetStandard(Locale location, Lang language) => GetLocalizedComponent(SlipComponent.Standard, location, language);

        /// <summary>
        /// An emergency slip
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetCrash(Locale location, Lang language)
        {
            throw new NotImplementedException();
        }

        public string GetTest(Locale location, Lang language)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get order position line (name/sku/calculations e.g. '0106 X-Cal    1 x 12.50 = 12.50 EUR')
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetOrderLine(Locale location, Lang language) => GetLocalizedComponent(SlipComponent.Line, location, language);

        public string GetBarcode(Locale location, Lang language) => GetLocalizedComponent(SlipComponent.Barcode, location, language);

        private string GetLocalePath(Locale location)
        {
            string result = Directory.GetDirectories(_repositoryPath).FirstOrDefault(x => string.Equals(new DirectoryInfo(x).Name, location.GetCode(), StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrWhiteSpace(result))
                throw new DirectoryNotFoundException(_repositoryPath + "/" + location.GetCode());

            return result;
        }

        /// <summary>
        /// Translate required component of the slip
        /// </summary>
        /// <param name="component"></param>
        /// <param name="location"></param>
        /// <returns></returns>
        private string GetLocalizedComponent(SlipComponent component, Locale location, Lang language)
        {
            string localePath = GetLocalePath(location);

            Func<string, string> getFilePath = (name) =>
            {
                string result = Directory.GetFiles(localePath).FirstOrDefault(x => string.Equals(new FileInfo(x).Name, name, StringComparison.InvariantCultureIgnoreCase));
                if (string.IsNullOrWhiteSpace(result))
                    throw new FileNotFoundException($"{localePath}/{name}");
                return result;
            };

            string componentFile = getFilePath($"{component.GetCode()}.html");
            string dictionaryFile = getFilePath("dictionary.json");

            FileInfo fi = new FileInfo(componentFile);
            string html = File.ReadAllText(fi.FullName);

            JsonDocument doc = System.Text.Json.JsonDocument.Parse(File.ReadAllText(dictionaryFile));

            JsonElement translations;
            if (doc.RootElement.TryGetProperty(Path.GetFileNameWithoutExtension(fi.Name), out translations))
            {
                var dict = translations.GetProperty(language.GetDescription().ToUpper());
                for (int i = 0; i < dict.GetArrayLength(); i++)
                {
                    string[] split = Regex.Matches(dict[i].GetString(), @"\[.*?\]").Cast<Match>().Select(m => m.Value).ToArray();
                    if (split.Length == 2)
                        html = html.Replace(split[0].Replace("[", "$").Replace("]", "$"), split[1].Replace("[", "").Replace("]", ""));
                }
            }

            return html;
        }

        private readonly string _repositoryPath;
    }
}