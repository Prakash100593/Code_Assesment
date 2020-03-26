using challenge.Models;
using challenge.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {

        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<ICompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation GetCompensationById(string Id)
        {
            return _compensationRepository.GetCompensationById(Id);
        }

        public Compensation PostCompensation(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Add(compensation);
            }

            return compensation;
        }
    }
}
