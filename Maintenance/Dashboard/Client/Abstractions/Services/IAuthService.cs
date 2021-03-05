using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Dashboard.Client.Abstractions.Services
{
    public interface IAuthService
    {
        Task<string> Login(string login, string password);

        Task Logout();
    }
}
