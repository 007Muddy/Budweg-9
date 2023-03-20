using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }
        public string Department { get; set; }


        public EmployeeViewModel(Employee emp)
        {
            EmployeeID = emp.EmployeeID;
            this.Department = emp.Department;
        }
    }
}
