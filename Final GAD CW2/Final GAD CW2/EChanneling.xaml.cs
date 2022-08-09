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
using System.Data;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for EChanneling.xaml
    /// </summary>
    public partial class EChanneling : Window
    {
        public EChanneling()
        {
            InitializeComponent();
        }

        public void clear()
        {
            rbn_dname.IsChecked = false;
            rbn_spec.IsChecked = false;
            rbn_hospital.IsChecked = false;
            txt_dname.Clear();
            txt_spec.Clear();
            txt_hospital.Clear();
            DataGridViewX.ItemsSource = null;
        }

        private void rbn_dname_Checked(object sender, RoutedEventArgs e)
        {
            txt_hospital.Clear();
            txt_spec.Clear();
            txt_dname.Clear();
            txt_dname.Focus();
        }

        private void rbn_spec_Checked(object sender, RoutedEventArgs e)
        {
            txt_dname.Clear();
            txt_hospital.Clear();
            txt_spec.Clear();
            txt_spec.Focus();
        }

        private void rbn_hospital_Checked(object sender, RoutedEventArgs e)
        {
            txt_dname.Clear();
            txt_spec.Clear();
            txt_hospital.Clear();
            txt_hospital.Focus();
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)rbn_dname.IsChecked || (bool)rbn_spec.IsChecked || (bool)rbn_hospital.IsChecked)
            {
                if ((bool)rbn_dname.IsChecked && txt_dname.Text.Length == 0)
                    MessageBox.Show("If your want to Search Doctor then Doctor Name cannot Be Null!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else if ((bool)rbn_spec.IsChecked && txt_spec.Text.Length == 0)
                    MessageBox.Show("If you want to Search Specilization also then Specialization Cannot Be Null!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else if ((bool)rbn_hospital.IsChecked && txt_hospital.Text.Length == 0)
                    MessageBox.Show("If you want to Search Hospital also then Hospital Cannot Be Null!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else if ((bool)rbn_dname.IsChecked && txt_dname.Text.Length > 0)
                {
                    IOdata iod = new IOdata();
                    DataTable dt = new DataTable();
                    dt = iod.DataView("Select * from Echaneling where Dname like '%" + txt_dname.Text + "%'");
                    DataGridViewX.ItemsSource = dt.DefaultView;

                }
                else if ((bool)rbn_spec.IsChecked && txt_spec.Text.Length > 0)
                {
                    IOdata iod = new IOdata();
                    DataTable dt = new DataTable();
                    dt = iod.DataView("Select * from Echaneling where Specilization like '%" + txt_spec.Text + "%'");
                    DataGridViewX.ItemsSource = dt.DefaultView;
                }
                else if ((bool)rbn_hospital.IsChecked && txt_hospital.Text.Length > 0)
                {
                    IOdata iod = new IOdata();
                    DataTable dt = new DataTable();
                    dt = iod.DataView("Select * from Echaneling where Hospital like '%" + txt_hospital.Text + "%'");
                    DataGridViewX.ItemsSource = dt.DefaultView;
                }
            }
            else
            {
                IOdata iod = new IOdata();
                DataTable dt = new DataTable();
                dt = iod.DataView("Select * from Echaneling");
                DataGridViewX.ItemsSource = dt.DefaultView;
            }

        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btn_home_Selected(object sender, RoutedEventArgs e)
        {
            CustomerMainWindow obj = new CustomerMainWindow();
            obj.Show();
            Hide();
        }

        private void btn_bill_paymeny_Selected(object sender, RoutedEventArgs e)
        {
            CustomerBillPayment obj = new CustomerBillPayment();
            obj.Show();
            Hide();
        }

        private void btn_onlinebanking_Selected(object sender, RoutedEventArgs e)
        {
            CustomerOnlineBanking obj = new CustomerOnlineBanking();
            obj.Show();
            Hide();
        }

        private void btn_mobile_reload_Selected(object sender, RoutedEventArgs e)
        {
            CustomerReloadPayment obj = new CustomerReloadPayment();
            obj.Show();
            Hide();
        }

        private void btn_historyt_Selected(object sender, RoutedEventArgs e)
        {
            CustomerTransaction obj = new CustomerTransaction();
            obj.Show();
            Hide();
        }
    }
}
