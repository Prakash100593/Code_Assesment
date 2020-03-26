using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Models
{
    public class Compensation
    {
        [Key]
        public string EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public int Salary { get; set; }
        public string EffectiveDate { get; set; }
    }
}
