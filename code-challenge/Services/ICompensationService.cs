﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;

namespace challenge.Services
{
    public interface ICompensationService
    {
        Compensation GetCompensationById(string Id);
        Compensation PostCompensation(Compensation compensation);
    }
}

