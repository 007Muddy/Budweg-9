using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
   public class Message
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public bool IsAnonym { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int EmployeePhone { get; set; }


        public Message(string type, DateTime date, string description, bool isAnonym, string firstName, string lastName, int employeePhone)
        {
            Type = type;
            Date = date;
            Description = description;
            IsAnonym = isAnonym;
            FirstName = firstName;
            LastName = lastName;
            EmployeePhone = employeePhone;
        }



    }
} 
