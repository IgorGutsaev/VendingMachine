using Filuet.ASC.Kiosk.OnBoard.SlipAbstractions;
using Filuet.Utils.Common.Business;
using Filuet.Utils.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
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
        public string GetStandard(Locale location)
        {
            string localePath = Directory.GetDirectories(_repositoryPath).FirstOrDefault(x => string.Equals(new DirectoryInfo(x).Name, location.GetCode(), StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrWhiteSpace(localePath))
                throw new DirectoryNotFoundException(_repositoryPath + "/" + location.GetCode());

            string componentFile = Directory.GetFiles(localePath).FirstOrDefault(x => string.Equals(new FileInfo(x).Name, "standard.html", StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrWhiteSpace(componentFile))
                throw new FileNotFoundException($"{localePath}/standard.html");

            string dictionaryFile = Directory.GetFiles(localePath).FirstOrDefault(x => string.Equals(new FileInfo(x).Name, "dictionary.json", StringComparison.InvariantCultureIgnoreCase));
            if (string.IsNullOrWhiteSpace(dictionaryFile))
                throw new FileNotFoundException($"{localePath}/dictionary.html");

            string html = File.ReadAllText(componentFile);

            System.Text.Json.JsonDocument doc = System.Text.Json.JsonDocument.Parse(File.ReadAllText(dictionaryFile));
            var dict = doc.RootElement.GetProperty("Standard").GetProperty("EN");
            for (int i = 0; i < dict.GetArrayLength(); i++)
            {
                string[] split = Regex.Matches(dict[i].GetString(), @"\[.*?\]").Cast<Match>().Select(m => m.Value).ToArray();
                if (split.Length == 2)
                    html = html.Replace(split[0].Replace("[", "$").Replace("]", "$"), split[1].Replace("[", "").Replace("]", ""));
            }

            return html;
        }

        /// <summary>
        /// An emergency slip
        /// </summary>
        /// <param name="location"></param>
        /// <returns></returns>
        public string GetCrash(Locale location)
        {
            throw new NotImplementedException();
        }

        public string GetTest(Locale location)
        {
            throw new NotImplementedException();
        }

        private readonly string _repositoryPath;
    }
}