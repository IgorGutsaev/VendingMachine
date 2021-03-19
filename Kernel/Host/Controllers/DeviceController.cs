using Filuet.CSharpSDK;
using ISDK.OmnichannelPlatform.CSharpSDK.DomainDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Filuet.ASC.OnBoard.Kernel.HostApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : BaseController
    {
        public DeviceController(IConfiguration configuration, FiluetASCApiHandlerForKiosk kioskApiHandler)
            : base(configuration, kioskApiHandler)
        { }

        [HttpGet("PushTerminalActivity")]
        public async Task<IActionResult> PushTerminalActivity(string action, string message, string level = null, string author = null)
        {
            try
            {
                return Ok(await _kioskApi().PushTerminalActivityAsync(new ActivityDto { Action = action, Author = author, Message = message, Level = level }));
            }
            catch (HttpOperationException e)
            {
                return BadRequest("Unable to push activity.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ex.Message);
            }
        }
    }
}
