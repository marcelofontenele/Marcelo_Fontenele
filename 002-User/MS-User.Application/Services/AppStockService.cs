using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_User.Application.Dto;
using MS_User.Application.Interfaces;
using MS_User.Domain.Entities;
using MS_User.Domain.Interfaces.Services;
using System;

namespace MS_User.Application.Services
{
    public class AppStockService : IAppStockService
    {
        private readonly IMapper mapper;
        private readonly IStockService stockService;
        private readonly IConfiguration configuration;

        public AppStockService(
            IMapper _mapper,
            IConfiguration _configuration,
            IStockService _stockService)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.configuration = _configuration ?? throw new NullReferenceException(nameof(IConfiguration));
            this.stockService = _stockService ?? throw new NullReferenceException(nameof(IStockService));
        }

        public void IncludeStock(StockDTO _stock)
        {
            this.stockService.IncludeStock(this.mapper.Map<Stock>(_stock));
        }
    }
}