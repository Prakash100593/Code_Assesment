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
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<EmployeeController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }


        [HttpGet("employee/{id}")]
        public IActionResult GetCompensationById(string id)
        {
            try
            {
                _logger.LogDebug($"Received compensation get request for employee Id: '{id}'");

                var compensation = _compensationService.GetCompensationById(id);

                if (compensation == null)
                {
                    return NotFound();
                }

                return Ok(compensation);
            }
            catch (Exception e)
            {
                return new JsonResult(new { info = "Error in Get Compensation By Id", reason = $"{e.Message}" });
            }
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation.Employee.FirstName} {compensation.Employee.LastName}'");

            _compensationService.PostCompensation(compensation);

            return CreatedAtRoute(new { id = compensation.Employee.EmployeeId }, compensation);
        }


    }
}
