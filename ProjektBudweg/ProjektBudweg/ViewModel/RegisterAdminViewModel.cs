using ProjektBudweg.ViewModel.Repositories;
using System;

namespace ProjektBudweg.ViewModel
{
    public class RegisterAdminViewModel
    {

        private AdminRepo adminRepo = new AdminRepo();

        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? LoginMessage { get; private set; }



        public bool CreateNewUser(string username, string password, string role)
        {
            bool RegisterSucces = false;
            try
            {
                if (username != null && password != null)
                {
                    adminRepo.Add(username, password, role);
                    RegisterSucces = true;
                    LoginMessage = $"Login was successfull: Welcome {username}";

                }
                else
                {
                    LoginMessage = $"Login failed please try again";
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RegisterSucces;
        }


    }
}
