using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS_Investiments.Application.Dto;
using MS_Investiments.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace MS_Investiments.WebApi.Controllers
{
    [ApiController]
    [Route("v1/investiments")]
    public class InvestimentsController : ControllerBase
    {
        private readonly IAppOrderService appOrderService;
        private readonly IAppStockService appStockService;
        private readonly ILogger logger;

        public InvestimentsController(
            IAppOrderService _appOrderService,
            IAppStockService _appStockService,
            ILogger<InvestimentsController> _logger)
        {
            appOrderService = _appOrderService ?? throw new NullReferenceException(nameof(IAppOrderService));
            appStockService = _appStockService ?? throw new NullReferenceException(nameof(IAppStockService));
            logger = _logger ?? throw new NullReferenceException(nameof(ILogger<InvestimentsController>));
        }

        [HttpPost, Route("order")]
        public ActionResult Order(OrderDTO order)
        {
            try
            {
                order.UserId = Int32.Parse(this.User.Claims.FirstOrDefault(clain => clain.Type == ClaimTypes.NameIdentifier)?.Value);

                this.appOrderService.OrderEmit(order);

                return NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }

        [HttpGet, Route("trends")]
        public ActionResult<IEnumerable<StockDTO>> Trends()
        {
            try
            {
                return Ok(this.appStockService.GetTrends());
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}