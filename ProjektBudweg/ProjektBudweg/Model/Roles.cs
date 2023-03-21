using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.Model
{
    public class Roles
    {
        public Role role { get; set; }

        public enum Role
        {
            HR,
            Direktør
        }

        public Roles(Role role)
        {
            this.role = role;
        }


    }
}
