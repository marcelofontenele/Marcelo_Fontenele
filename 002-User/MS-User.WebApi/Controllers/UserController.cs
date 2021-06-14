using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS_User.Application.Dto;
using MS_User.Application.Interfaces;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MS_User.WebApi.Controllers
{
    [ApiController]
    [Route("v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IAppUserService appUserService;
        private readonly ILogger logger;

        public UserController(
            IAppUserService _appUserService,
            ILogger<UserController> _logger)
        {
            appUserService = _appUserService ?? throw new NullReferenceException(nameof(IAppUserService));
            logger = _logger ?? throw new NullReferenceException(nameof(ILogger<UserController>));
        }

        [HttpGet]
        public async Task<ActionResult<PositionDTO>> Get()
        {
            try
            {
                string userId = this.User.Claims.FirstOrDefault(clain => clain.Type == ClaimTypes.NameIdentifier)?.Value;

                var position = appUserService.GetPosition(Int32.Parse(userId));

                if (position == null)
                {
                    return NotFound();
                }

                return Ok(position);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}