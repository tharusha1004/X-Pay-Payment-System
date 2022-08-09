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
using System.Text.RegularExpressions;
using System.Net;
using System.Net.Mail;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for DealerReload.xaml
    /// </summary>
    public partial class DealerReload : Window
    {
        public DealerReload()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader rd;

        private string username;
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

        public void clear()
        {
            cmb_misp.Text = "";
            txt_value.Clear();
            txt_cname.Clear();
            txt_cmobno.Clear();
            txt_Email.Clear();
        }

        public void sendEmail()
        {
            string Email = txt_Email.Text;

            //give a default message body
            string mail = "Dear Sir/Madam, \n Username : " + txt_username.Text + " \n Service Provider : " + cmb_misp.Text + "\n Mobile Number : " + txt_cmobno.Text + "\n Reload Amount : " + txt_value.Text +
                "\n Thank You for the recent payment amount " + txt_value.Text + ". This is a confermation thatamount has been successfully received. \n" +
                "Best Regards, \n \n Janith Disanayake, \n Managing Director, \n IT Division, \n Nexa (PVT) Ltd.";


            MailMessage message = new MailMessage();
            message.To.Add(Email);   //receiver email
            message.From = new MailAddress("xpay.nexa@gmail.com");  //sender email **default**
            message.Body = mail;
            //email subject (what is the purpose)
            message.Subject = "Online Payment Achknowledgement";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("xpay.nexa@gmail.com", "Avishka12345#");    //Sender email and password
            smtp.Send(message);


        }

        private void btn_reload_Click(object sender, RoutedEventArgs e)
        {
            if (cmb_misp.Text.Length == 0)
            {
                MessageBox.Show("SIM Card Provider Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                cmb_misp.Focus();
            }
            else if (txt_value.Text.Length == 0)
            {
                MessageBox.Show("Reload Value Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_value.Focus();
            }
            else if (txt_cname.Text.Length == 0)
            {
                MessageBox.Show("Customer Name Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_cname.Focus();
            }
            else if (txt_cmobno.Text.Length == 0)
            {
                MessageBox.Show("Reload Number Cannot Be Empty!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_cmobno.Focus();
            }
            else if (txt_cname.Text.Length >= 30)
            {
                MessageBox.Show("Customer Name Cannot Be Over 30 Characters ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_cname.Focus();
            }
            else if (txt_username.Text != username)
            {
                MessageBox.Show(this, "Username Is Wrong! \n We Will Fix It", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_username.Text = username;
            }
            else if (!Regex.IsMatch(txt_cmobno.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
            {
                MessageBox.Show("Customer Contact Number Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txt_cmobno.Focus();
            }
            else
            {
                try
                {
                    double rvalue = Convert.ToDouble(txt_value.Text);
                    IOdata iod = new IOdata();
                    int i = iod.DealerInsert("Insert into DealerReloadPayment values('" + txt_username.Text + "', '" + cmb_misp.Text + "', '" + rvalue + "', '" + txt_cname.Text + "', '" + txt_cmobno.Text + "', GETDATE())");
                    if (i == 1)
                    {
                        MessageBox.Show("Your Transaction Is Done", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        sendEmail();
                        clear();
                    }
                }
                catch (FormatException)
                {
                    double bamt;
                    if (!double.TryParse(txt_value.Text, out bamt))
                    {
                        MessageBox.Show("Bill Amount Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_value.Focus();
                    }
                    else
                        MessageBox.Show(this, "Check Your Details Again Please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (Exception)
                {
                    MessageBox.Show(this, "Check Your Details Again Please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            clear();
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

        private void btn_historyt_Selected(object sender, RoutedEventArgs e)
        {
            DealerTransaction obj = new DealerTransaction();
            obj.Show();
            Hide();
        }
    }
}
