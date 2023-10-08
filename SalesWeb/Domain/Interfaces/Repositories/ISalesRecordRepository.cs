﻿using SalesWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Domain.Interfaces.Repositories
{
    public interface ISalesRecordRepository
    {
        Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate);
        Task<List<IGrouping<Department, SalesRecord>>> FindByDateGroupingAsync(DateTime? minDate, DateTime? maxDate);
    }
}