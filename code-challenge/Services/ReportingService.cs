using challenge.Models;
using challenge.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public class ReportingService : IReportingService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ReportingService> _logger;

        public ReportingService(ILogger<ReportingService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }
        public ReportingStructure GetReportingStructureById(string Id)
        {
            var count = GetReporteeForEmployeeById(Id);

            return new ReportingStructure
            {
                Employee = _employeeRepository.GetById(Id),
                NumberOfReports = count
            };
        }

        public int GetReporteeForEmployeeById(string Id)
        {
            var count = 0;
            Employee emp = _employeeRepository.GetById(Id);

            if (emp != null && emp.DirectReports != null && emp.DirectReports.Any())
            {
                foreach (var directReport in emp.DirectReports)
                {
                    count = count + 1 + GetReporteeForEmployeeById(directReport.EmployeeId);
                }
            }

            return count;
        }

    }
}
