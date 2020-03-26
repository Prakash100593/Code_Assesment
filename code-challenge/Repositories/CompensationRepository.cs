using challenge.Data;
using challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        public Compensation Add(Compensation compensation)
        {
            Employee employee = _employeeContext.Employees.Include(e => e.DirectReports)
                .SingleOrDefault(e => e.EmployeeId == compensation.Employee.EmployeeId);

            _employeeContext.Compensation.Add(compensation);
            _employeeContext.SaveChangesAsync().Wait();

            return compensation;
        }

        public Compensation GetCompensationById(string Id)
        {
            return _employeeContext.Compensation.Where(x => x.EmployeeId == Id)
                        .Include(y => y.Employee).FirstOrDefault();
        }
    }
}
