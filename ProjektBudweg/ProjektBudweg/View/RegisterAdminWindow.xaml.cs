using ProjektBudweg.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjektBudweg.View
{
    /// <summary>
    /// Interaction logic for RegisterAdminWindow.xaml
    /// </summary>
    public partial class RegisterAdminWindow : Window
    {
        public AdminViewModel awm { get; set; }

        public RegisterAdminWindow()
        {
            InitializeComponent();
            awm = new AdminViewModel();
            DataContext = awm;
            awm.ShowEnumList();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername != null && txtPassword != null && txtPassword2 != null && ComboRoleType != null)
            {
                if (txtPassword.Password == txtPassword2.Password)
                {

                    AdminViewModel avm = new AdminViewModel();

                    if (avm.CreateNewUser(txtUsername.Text, txtPassword.Password, ComboRoleType.Text))
                    {
                        MessageBox.Show("You have successfully registered");
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtPassword2.Clear();
                    }
                }
            }
            else
            {
                MessageBox.Show("Every field has to be filled");
            }
        }
    }
}
