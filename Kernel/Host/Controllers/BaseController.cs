using Filuet.CSharpSDK;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Kernel.HostApp.Controllers
{
    public class BaseController : Microsoft.AspNetCore.Mvc.Controller
    {
        const string BEARER_TOKEN_TYPE = "Bearer";
        private readonly Uri _apiUri;
        private FiluetASCApiHandlerForKiosk _kioskApiHandler;

        public BaseController(IConfiguration configuration, FiluetASCApiHandlerForKiosk kioskApiHandler)
        {
            string url = configuration["ApiUrl"];
            _apiUri = new Uri(url);
            _kioskApiHandler = kioskApiHandler;
        }

        protected string BearerToken => Request.Headers["Authorization"].ToString().Replace(BEARER_TOKEN_TYPE, string.Empty);

        protected IFiluetASCApi _userApi(bool noToken = false)
        {
            if (noToken)
            {
                var ascApi = new FiluetASCApi(new TokenCredentials("."), new HttpClient(), true);
                ascApi.BaseUri = _apiUri;
                return ascApi;
            }
            else
            {
                StringValues authHeader = Request.Headers["Authorization"];

                if (authHeader.Count == 0)
                    return null;
                else return new FiluetASCApi(_apiUri, new TokenCredentials(authHeader.ToString().Replace(BEARER_TOKEN_TYPE, string.Empty).Trim(), BEARER_TOKEN_TYPE));
            }
        }

        protected IFiluetASCApi _kioskApi()
        {
            return _kioskApiHandler.Api;
        }
    }
}
