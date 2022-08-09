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
    /// Interaction logic for Selection.xaml
    /// </summary>
    public partial class Selection : Window
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void btn_customer_Click(object sender, RoutedEventArgs e)
        {
            Customer_Login cus_login = new Customer_Login();
            cus_login.ShowDialog();

        }

        private void btn_dealer_Click(object sender, RoutedEventArgs e)
        {
            Dealer_login dealer_login = new Dealer_login();
            dealer_login.ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
