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
using System.Data.SqlClient;
using System.Data;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for DealerTransaction.xaml
    /// </summary>
    public partial class DealerTransaction : Window
    {
        private SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader rd;
        private SqlDataAdapter da;

        private string username;

        public DealerTransaction()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select username from loginuser where num = (select max(num) from loginuser) group by username", con);
            rd = cmd.ExecuteReader();
            rd.Read();
            username = rd.GetString(0);
            con.Close();
            txt_username.Text = username;
        }

        private void btn_view_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_trans_type.SelectedIndex == 0)
                {
                    con.Open();
                    da = new SqlDataAdapter("Select Transfer_no, tnsamt as  Amount, insdatetime as Transaction_Date  from DealerOnlineBanking where username = '" + txt_username.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_transaction.ItemsSource = dt.DefaultView;
                    con.Close();
                }
                else if (cmb_trans_type.SelectedIndex == 1)
                {
                    con.Open();
                    da = new SqlDataAdapter("Select Bill_no, bamt as Amount, insdatetime as Transaction_Date  from DealerBillPayment where username = '" + txt_username.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_transaction.ItemsSource = dt.DefaultView;
                    con.Close();

                }
                else if (cmb_trans_type.SelectedIndex == 2)
                {
                    con.Open();
                    da = new SqlDataAdapter("Select Reload_no, misp As Service_Provider,  rvalue As Reload_Value, insdatetime As Transaction_Date  from DealerReloadPayment where username = '" + txt_username.Text + "'", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgv_transaction.ItemsSource = dt.DefaultView;
                    con.Close();
                }
                else
                    MessageBox.Show("Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Error check again");
            }
        }

        private void btn_home_Selected(object sender, RoutedEventArgs e)
        {
            DealerMainWindow obj = new DealerMainWindow();
            obj.Show();
            Hide();
        }

        private void btn_bill_paymeny_Selected(object sender, RoutedEventArgs e)
        {
            DealerBillPayment obj = new DealerBillPayment();
            obj.Show();
            Hide();
        }

        private void btn_onlinebanking_Selected(object sender, RoutedEventArgs e)
        {
            DealerOnlineBanking obj = new DealerOnlineBanking();
            obj.Show();
            Hide();
        }

        private void btn_cashtopup_Selected(object sender, RoutedEventArgs e)
        {
            DealerCashTopup obj = new DealerCashTopup();
            obj.Show();
            Hide();
        }

        private void btn_mobile_reload_Selected(object sender, RoutedEventArgs e)
        {
            DealerReload obj = new DealerReload();
            obj.Show();
            Hide();
        }
    }
}
