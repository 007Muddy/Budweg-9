using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
    public class RiskLevel
    {
        public Risk risk { get; set; }

        public enum Risk
        {
            Feedback,
            Fare,
            Whistleblower
        }

        public RiskLevel(Risk risk)
        {
            this.risk = risk;
        }


    }
}
