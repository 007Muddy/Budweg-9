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

        }

        //private void IsAnonym_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (IsAnonym.IsChecked == true)
        //    {
        //        txtName.IsEnabled = false;
        //        txtLast.IsEnabled = false;

        //        NotAnonym.IsChecked = false;
        //    }
        //    else if (NotAnonym.IsChecked == true)

        //    {
        //        txtName.IsEnabled = true;
        //        txtLast.IsEnabled = true;

        //        IsAnonym.IsChecked = false;
        //    }
        //}
    }
}
