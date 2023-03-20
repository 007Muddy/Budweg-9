using ProjektBudweg.Model;
using ProjektBudweg.ViewModel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class AdminViewModel
    {
        private Admin admin { get; set; }
        private AdminRepo adminRepo = new AdminRepo();

        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginMessage { get; private set; }

        public AdminViewModel()
        {

        }

        public AdminViewModel(Admin admin)
        {
            this.admin = admin;
            Username = admin.UserName;
            Password = admin.Password;
        }




        public bool AccessGranted(string username, string password)
        {
            bool acces = false;
            try
            {
                if (username != null && password != null)
                {
                    Admin ad = new Admin(username, password);

                    if (adminRepo.AuthenticateUser(ad) == true)
                    {
                        LoginMessage = $"Login was successfull: Welcome {username}";
                        acces= true;
                    }
                    else
                    {
                        LoginMessage = $"Login failed please try again";
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return acces;
        }


       

    }
}
