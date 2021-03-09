﻿using Filuet.CSharpSDK;
using ISDK.OmnichannelPlatform.CSharpSDK.DomainDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Kernel.HostApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        public AuthController(IConfiguration configuration, FiluetASCApiHandlerForKiosk kioskApiHandler)
            : base(configuration, kioskApiHandler)
        { }

        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username, string password)
        {

            try
            {
                return Ok(await _userApi(true).LoginAsync(new LoginDto { Login = username, Password = password }).ContinueWith(t => t.Result.Token));
            }
            catch (HttpOperationException e)
            {
                return BadRequest("Unable to authorize. Check your username and password");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {

            try
            {
                //await _api().ExitAsync();
                return Ok();
            }
            catch (HttpOperationException e)
            {
                return BadRequest("Unable to authorize. Check your username and password");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
