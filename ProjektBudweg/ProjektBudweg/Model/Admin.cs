using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
   public class Admin
    {
        public int AdminID { get; set; }    
        public string UserName { get; set; } 
        public string Password { get; set; }
        public Admin(int adminID, string userName, string password)
        {
            AdminID = adminID;
            UserName = userName;
            Password = password;

        }

    }
}
