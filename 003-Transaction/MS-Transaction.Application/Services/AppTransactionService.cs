using AutoMapper;
using MS_Transaction.Application.Dto;
using MS_Transaction.Application.Interfaces;
using MS_Transaction.Domain.Entities;
using MS_Transaction.Domain.Interfaces.Services;
using SharedLibrary.RabbitMQ.Interfaces;
using System;

namespace MS_Transaction.Application.Services
{
    public class AppTransactionService : IAppTransactionService
    {
        private readonly IMapper mapper;
        private readonly ITransferService userService;
        private readonly IAppMqPublishService appMessageQueueService;

        public AppTransactionService(
            IMapper _mapper,
            ITransferService _userService,
            IAppMqPublishService _mqPublisher)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.userService = _userService ?? throw new NullReferenceException(nameof(ITransferService));
            this.appMessageQueueService = _mqPublisher ?? throw new NullReferenceException(nameof(IAppMqPublishService));
        }

        public void Transfer(TransferDTO transfer)
        {
            this.userService.RegisterTransfer(this.mapper.Map<Transfer>(transfer));

            this.appMessageQueueService.PublishCreditAccount(transfer);
        }
    }
}