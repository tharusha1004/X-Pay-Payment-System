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

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for Submenu.xaml
    /// </summary>
    public partial class Submenu : Window
    {
        public Submenu()
        {
            InitializeComponent();
        }

        private void btn_main_window_Click(object sender, RoutedEventArgs e)
        {
            Close();
            CustomerMainWindow obj = new CustomerMainWindow();
            obj.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CustomerOnlineBanking obj = new CustomerOnlineBanking();
            obj.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CustomerBillPayment obj = new CustomerBillPayment();
            obj.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            CustomerReloadPayment obj = new CustomerReloadPayment();
            obj.Show();
            Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EChanneling obj = new EChanneling();
            obj.Show();
            Hide();
        }
    }
}
