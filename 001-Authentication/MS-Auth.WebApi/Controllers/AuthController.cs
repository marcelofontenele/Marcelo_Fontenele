using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS_Auth.Application.Dto;
using MS_Auth.Application.Interfaces;
using System;

namespace MS_Auth.WebApi.Controllers
{
    [ApiController]
    [Route("v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAppAuthenticationService appAuthenticationService;
        private readonly ILogger logger;

        public AuthController(
            IAppAuthenticationService _appAuthenticationService,
            ILogger<AuthController> _logger)
        {
            appAuthenticationService = _appAuthenticationService ?? throw new NullReferenceException(nameof(IAppAuthenticationService));
            logger = _logger ?? throw new NullReferenceException(nameof(ILogger<AuthController>));
        }

        [HttpPost, AllowAnonymous]
        public ActionResult<TokenDTO> Post(UserDTO user)
        {
            try
            {
                var token = appAuthenticationService.Authenticate(user);

                if (token == null)
                {
                    return NotFound(new
                    {
                        message = "Login ou senha inválidos!"
                    });
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}