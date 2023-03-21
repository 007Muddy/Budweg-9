using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
    public class Message : Identity
    {

        public string Type { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Department { get; set; }




        public Message(string name, string lastname, string type, string department, DateTime date, string description)
        {
            Name = name;
            Lastname = lastname;
            Type = type;
            Department = department;
            Date = date;
            Description = description;
        }

    }
}
