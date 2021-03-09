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

        public BaseController(IConfiguration configuration)
        {
            string url = configuration["ApiUrl"];
            _apiUri = new Uri(url);
        }

        protected string BearerToken => Request.Headers["Authorization"].ToString().Replace(BEARER_TOKEN_TYPE, string.Empty);

        protected IFiluetASCApi _api(bool noToken = false)
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
    }
}
