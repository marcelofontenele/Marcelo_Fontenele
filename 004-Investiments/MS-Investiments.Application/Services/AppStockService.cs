using AutoMapper;
using Microsoft.Extensions.Configuration;
using MS_Investiments.Application.Dto;
using MS_Investiments.Application.Interfaces;
using MS_Investiments.Domain.Interfaces.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace MS_Investiments.Application.Services
{
    public class AppStockService : IAppStockService
    {
        private readonly IMapper mapper;
        private readonly IStockService stockService;

        public AppStockService(
            IMapper _mapper,
            IConfiguration _configuration,
            IStockService _stockService)
        {
            this.mapper = _mapper ?? throw new NullReferenceException(nameof(IMapper)); ;
            this.stockService = _stockService ?? throw new NullReferenceException(nameof(IStockService));
        }

        public IEnumerable<StockDTO> GetTrends()
        {
            return this.mapper.Map<IEnumerable<StockDTO>>(this.stockService.GetTrends());
        }
    }
}