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
        public RegisterAdminWindow avm { get; set; }

        public RegisterAdminWindow()
        {
            InitializeComponent();
            avm = new RegisterAdminWindow();
            DataContext = avm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername != null && txtPassword == txtPassword2)
            {
                

                avm.CreateNewUser(txtUsername.Text, txtPassword.Text);


            }
        }
    }
}
