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
    /// Interaction logic for DangerWindow.xaml
    /// </summary>
    public partial class DangerWindow : Window
    {
        public DangerViewModel dvm { get; set; }
        public DangerWindow()
        {
            InitializeComponent();
            dvm = new DangerViewModel();
            DataContext = dvm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow fw = new FeedbackWindow();
            fw.Show();
            this.Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterAdminWindow raw = new RegisterAdminWindow();
            raw.Show();
            this.Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();   
            mw.Show();
            this.Hide();
        }
    }
}
