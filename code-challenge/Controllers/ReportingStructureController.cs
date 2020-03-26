using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/ReportingStructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingService _reportingService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingService reportingService)
        {
            _logger = logger;
            _reportingService = reportingService;
        }

        [HttpGet("{id}", Name = "getReportingById")]
        public IActionResult GetReportingById(string id)
        {
            _logger.LogDebug($"Received employee get request for '{id}'");

            var reportingStructure = _reportingService.GetReportingStructureById(id);

            return Ok(reportingStructure);
        }
    }
}
