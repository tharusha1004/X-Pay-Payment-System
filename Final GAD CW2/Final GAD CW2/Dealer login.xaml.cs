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
using System.Data.SqlClient;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for Dealer_login.xaml
    /// </summary>
    public partial class Dealer_login : Window
    {
        public Dealer_login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader rd;

        private void btn_signin_Click(object sender, RoutedEventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("Select Dea_password from DealerRegistration where Username = '" + txt_dealer_name.Text + "'", con);
            rd = cmd.ExecuteReader();
            rd.Read();
            string pwd = rd.GetString(0);
            con.Close();

            if (txt_dealer_passwd.Password == pwd)
            {
                DealerMainWindow obj = new DealerMainWindow ();
                obj.Show();
                Hide();

                con.Open();
                cmd = new SqlCommand("Insert into loginuser values ('" + txt_dealer_name.Text + "', getdate())", con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else
                MessageBox.Show("Your Password Is Incorrect !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            newregd obj = new newregd();
            obj.Show();
        }
    }
}
