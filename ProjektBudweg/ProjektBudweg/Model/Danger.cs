using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
   public class Danger
    {
        public DateTime Date { get; set; }
        public string Department { get; set; }
        public string RiskLevel { get; set; }

        public Danger(DateTime date, string department, string riskLevel)
        {
            Date = date;
            Department = department;
            RiskLevel = riskLevel;
        }
    }
}
