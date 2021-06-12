using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MS_Transaction.Application.Dto;
using MS_Transaction.Application.Interfaces;
using System;

namespace MS_Transaction.WebApi.Controllers
{
    [ApiController]
    [Route("v1/spb/events")]
    public class TransactionController : ControllerBase
    {
        private readonly IAppTransactionService appTransactionService;
        private readonly ILogger logger;

        public TransactionController(
            IAppTransactionService _appTransactionService,
            ILogger<TransactionController> _logger)
        {
            appTransactionService = _appTransactionService ?? throw new NullReferenceException(nameof(IAppTransactionService));
            logger = _logger ?? throw new NullReferenceException(nameof(ILogger<TransactionController>));
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Post(TransferDTO transfer)
        {
            try
            {
                this.appTransactionService.Transfer(transfer);

                return NoContent();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex, ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return BadRequest(ex.InnerException != null ? ex.InnerException.Message : ex.Message);
            }
        }
    }
}