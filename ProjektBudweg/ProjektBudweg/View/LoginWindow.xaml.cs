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
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public AdminViewModel avm { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            avm = new AdminViewModel();
            DataContext = avm;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (txtUsername.Text.Length > 0 && txtUsername.Text.Length > 0)
            {
                if (avm.AccessGranted(txtUsername.Text, txtPassword.Password))
                {

                    MessageBox.Show(avm.LoginMessage);

                    DangerWindow rw = new DangerWindow();
                    WhistleBlowerWindow wbw = new WhistleBlowerWindow();

                    if (avm.Role == "HR")
                    {
                        rw.Show();
                        this.Hide();
                    }
                    else if(avm.Role == "Direktør")
                    {
                        wbw.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show(avm.LoginMessage);
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Hide();
        }
    }
}
