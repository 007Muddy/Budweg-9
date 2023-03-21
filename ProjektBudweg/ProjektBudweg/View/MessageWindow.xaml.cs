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
using System.Xml.Linq;

namespace ProjektBudweg.View
{
    /// <summary>
    /// Interaction logic for MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageViewModel mvm { get; set; }

        public MessageWindow()
        {
            InitializeComponent();
            mvm = new MessageViewModel();
            mvm.ShowEnumList();
            DataContext = mvm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(txtName != null && txtLastName!= null && ComboMsgType != null && ComboDepartment != null && txtMsg != null)
            {            
                if(mvm.AddMessage(txtName.Text, txtLastName.Text, txtMsg.Text))
                {
                    MessageBox.Show("Message was succesfully added");
                    txtName.Text = "";
                    txtLastName.Text = "";
                    ComboMsgType.Text = "";
                    ComboDepartment.Text = "";
                    IsAnonym.IsChecked = false;
                    NotAnonym.IsChecked = false;
                    txtMsg.Text = "";
                }
            } 
            else
            {

                MessageBox.Show("Every field has to be filled");
            }
        }

        private void IsAnonym_Checked(object sender, RoutedEventArgs e)
        {
            if(IsAnonym.IsChecked== true)
            {
                txtName.IsEnabled = false;
                txtLastName.IsEnabled = false;

                NotAnonym.IsChecked = false;
            }          
        }

        private void NotAnonym_Checked(object sender, RoutedEventArgs e)
        {
            if (NotAnonym.IsChecked == true)
            {
                txtName.IsEnabled = true;
                txtLastName.IsEnabled = true;

                IsAnonym.IsChecked = false;
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
