using SalesWeb.Domain.Interfaces;
using SalesWeb.Domain.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Services
{
    public class SalesRecordService: ISalesRecordService
    {
        private readonly ISalesRecordRepository _repository;

        public SalesRecordService(ISalesRecordRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            return await _repository.FindByDateAsync(minDate, maxDate);
        }
        
        public async Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate)
        {
            return await _repository.FindByDateGroupingAsync(minDate, maxDate);
        }
    }
}