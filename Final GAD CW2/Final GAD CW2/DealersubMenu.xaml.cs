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
    /// Interaction logic for DealersubMenu.xaml
    /// </summary>
    public partial class DealersubMenu : Window
    {
        public DealersubMenu()
        {
            InitializeComponent();
        }

        private void btn_home_window_Click(object sender, RoutedEventArgs e)
        {
            DealerMainWindow obj = new DealerMainWindow();
            obj.Show();
            Hide();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DealerOnlineBanking obj = new DealerOnlineBanking();
            obj.Show();
            Hide();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DealerBillPayment obj = new DealerBillPayment();
            obj.Show();
            Hide();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DealerReload obj = new DealerReload();
            obj.Show();
            Hide();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DealerCashTopup obj = new DealerCashTopup();
            obj.Show();
            Hide();
        }
    }
}
