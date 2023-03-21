using ProjektBudweg.Model;
using ProjektBudweg.ViewModel.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektBudweg.ViewModel
{
    public class AdminViewModel : INotifyPropertyChanged
    {
        private Admin admin { get; set; }
        private AdminRepo adminRepo = new AdminRepo();

        public string Username { get; set; }
        public string Password { get; set; }
        public string LoginMessage { get; private set; }



        public ObservableCollection<Roles.Role> RoleList { get; private set; }

        private string selectedRole;

        public string SelectedRole
        {
            get { return selectedRole; }
            set 
            {
                if (value == selectedRole)
                {
                    selectedRole = value;
                    NotifyPropertyChanged(nameof(SelectedRole));
                }              
            }
        }
        public AdminViewModel()
        {
            RoleList = new ObservableCollection<Roles.Role>();
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
            catch (Exception)
            {
                throw;
            }
            return acces;
        }



        public bool CreateNewUser(string username, string password, string role)
        {
            bool RegisterSucces = false;
            try
            {
                if (username != null && password != null && role != null)
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





        public void ShowEnumList()
        {
            try
            {
                var roleValues = Enum.GetValues(typeof(Roles.Role));
                foreach (var value in roleValues)
                {
                    RoleList.Add((Roles.Role)value);
                }
     
            }
            catch (Exception)
            {

                throw;
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
