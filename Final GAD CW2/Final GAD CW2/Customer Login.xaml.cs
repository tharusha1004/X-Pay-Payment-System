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
using BespokeFusion;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for Customer_Login.xaml
    /// </summary>
    public partial class Customer_Login : Window
    {
        public Customer_Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter da;
        SqlDataReader rd;
        private object ex;

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
                MaterialMessageBox.Show(ex.Message);
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
                MaterialMessageBox.ShowError(ex.Message);
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
                MaterialMessageBox.Show(ex.Message);
            }
        }

        private void btn_popup_logout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btn_Register_Click(object sender, RoutedEventArgs e)
        {
            newreg obj = new newreg();
            obj.Show();
        }

        private void btn_signin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                con.Open();
                cmd = new SqlCommand("Select Cus_password from CustomerRegistration where Username = '" + txt_customer_name.Text + "'", con);
                rd = cmd.ExecuteReader();
                rd.Read();
                string pwd = rd.GetString(0);
                con.Close();

                if (txt_customer_psswd.Password == pwd)
                {
                    CustomerMainWindow obj = new CustomerMainWindow();
                    obj.Show();
                    Hide();

                    con.Open();
                    cmd = new SqlCommand("Insert into loginuser values ('" + txt_customer_name.Text + "', getdate())", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                else
                    MessageBox.Show("Your Password Is Incorrect !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MaterialMessageBox.ShowError("Please Check Again", "Error");
            }
        }

        private void btn_Register_Click_1(object sender, RoutedEventArgs e)
        {
            newregc obj = new newregc();
            obj.Show();
            Hide();            
        }

        private void Rectangle_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }

}

