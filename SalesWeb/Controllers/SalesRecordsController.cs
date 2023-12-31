﻿using Microsoft.AspNetCore.Mvc;
using SalesWeb.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace SalesWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly ISalesRecordService _salesRecordService;
        
        public SalesRecordsController(ISalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }
        
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> SimpleSearchAsync(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = DateTime.Now;
            }
            
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            
            var result = await _salesRecordService.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
        
        public async Task<IActionResult> GroupingSearchAsync(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = DateTime.Now;
            }
            
            if (!maxDate.HasValue)
            {
                maxDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            
            var result = await _salesRecordService.FindByDateGroupingAsync(minDate, maxDate);
            return View(result);
        }
    }
}