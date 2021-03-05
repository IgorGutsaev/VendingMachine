using Filuet.ASC.OnBoard.Dashboard.Client.Abstractions.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Rest;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;

namespace Filuet.ASC.OnBoard.Dashboard.Client.Implementations
{
    public class OnBoardApiAuthService : IAuthService
    {
        private readonly HttpClient _client;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public OnBoardApiAuthService(HttpClient client, AuthenticationStateProvider authenticationStateProvider)
        {
            _client = client;
            _authenticationStateProvider = authenticationStateProvider;
        }

        public async Task<string> Login(string username, string password)
        {
            return await _client.GetAsync($"api/auth/login?username={username}&password={password}")
                .ContinueWith(t =>
                {
                    if (!t.Result.IsSuccessStatusCode)
                        return "";

                    string token = t.Result.Content.AsString();
                    
                    ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsAuthenticated(username, token);
                    return token;
                });
        }

        public Task Logout()
        {
            return _client.GetAsync("api/auth/logout").ContinueWith(t =>
            {
                if (t.Result.IsSuccessStatusCode)
                    ((ApiAuthenticationStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();

                return t;
            });
        }
    }
}
