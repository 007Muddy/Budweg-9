using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
    public class Department
    {
        public DepartmentArea Area { get; set; }

        public enum DepartmentArea
        {
            Sales,
            Storage,
            Rebuild,
            packaging,
            Shipping,
            cafeteria
        }

        public Department(DepartmentArea area)
        {
            Area = area;
        }
    }
}
