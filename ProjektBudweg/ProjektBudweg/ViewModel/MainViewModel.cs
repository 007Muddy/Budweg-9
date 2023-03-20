using ProjektBudweg.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class MainViewModel
    {

        public List<EmployeeViewModel> EmployeeVM { get; set; } = new();
        EmployeeRepo employeeRepo;
        public MainViewModel() 
        {
            employeeRepo= new EmployeeRepo();
            if (employeeRepo != null)
            {
                foreach (Employee item in employeeRepo.GeAllEmployees())
                {
                    EmployeeViewModel employeeViewModel = new EmployeeViewModel(item);

                    EmployeeVM.Add(employeeViewModel);
                }
            }
            else
            {
                throw new Exception("Employee was null");
            }
            
        }
    }
}
