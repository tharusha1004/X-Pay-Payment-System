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
    /// Interaction logic for CustomerMainWindow.xaml
    /// </summary>
    public partial class CustomerMainWindow : Window
    {
        public CustomerMainWindow()
        {
            InitializeComponent();
        }
        private void left_click(object sender, MouseButtonEventArgs e)
        {
            try
            {
                DragMove();
            }
            catch (Exception)
            {

            }
        }

        private void closeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void minimizeAPP(object sender, MouseButtonEventArgs e)
        {

            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void maximizeApp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Maximized;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_popup_logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_open_menu_Click(object sender, RoutedEventArgs e)
        {
            btn_open_menu.Visibility = Visibility.Collapsed;
            btn_close_menu.Visibility = Visibility.Visible;
        }

        private void btn_close_menu_Click(object sender, RoutedEventArgs e)
        {
            btn_open_menu.Visibility = Visibility.Visible;
            btn_close_menu.Visibility = Visibility.Collapsed;
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btn_home_Click(object sender, RoutedEventArgs e)
        {

        }

        public void btn_main_window_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_bill_paymeny_Selected(object sender, RoutedEventArgs e)
        {
            CustomerBillPayment obj = new CustomerBillPayment();
            obj.Show();
            Hide();
        }

        private void btn_echanneling_Selected(object sender, RoutedEventArgs e)
        {
            EChanneling obj = new EChanneling();
            obj.Show();
            Hide();
        }

        private void btn_mobile_reload_Selected(object sender, RoutedEventArgs e)
        {
            CustomerReloadPayment obj = new CustomerReloadPayment();
            obj.Show();
            Hide();
        }

        private void btn_submenu_Selected(object sender, RoutedEventArgs e)
        {
            Submenu obj = new Submenu();
            obj.Show();
            Hide();
        }

        private void btn_onlinebanking_Selected(object sender, RoutedEventArgs e)
        {
            CustomerOnlineBanking obj = new CustomerOnlineBanking();
            obj.Show();
            Hide();
        }

        private void btn_transaction_history_Selected(object sender, RoutedEventArgs e)
        {
            CustomerTransaction obj = new CustomerTransaction();
            obj.Show();
            Hide();
        }
    }
}
