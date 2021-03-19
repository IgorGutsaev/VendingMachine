using Filuet.CSharpSDK;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Kernel.HostApp
{
    public class FiluetASCApiHandlerForKiosk
    {
        public readonly IFiluetASCApi Api;

        public FiluetASCApiHandlerForKiosk(string uri, string kioskLogin, string kioskPassword)
        {
            Api = new FiluetASCApi(new TokenCredentials("."), new HttpClient(), true);
            Api.BaseUri = new Uri(uri);
            var token = Api.Login(new ISDK.OmnichannelPlatform.CSharpSDK.DomainDto.LoginDto() { Login = kioskLogin, Password = kioskPassword });
            if (token == null || string.IsNullOrEmpty(token.Token))
            {
                Api = null;
                return;
            }

            Api = new FiluetASCApi(new Uri(uri), new TokenCredentials(token.Token, "Bearer"));
        }
    }
}
