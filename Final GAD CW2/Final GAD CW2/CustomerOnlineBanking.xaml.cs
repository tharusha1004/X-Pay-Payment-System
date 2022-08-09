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
using BespokeFusion;
using System.Net;
using System.Net.Mail;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for CustomerOnlineBanking.xaml
    /// </summary>
    public partial class CustomerOnlineBanking : Window
    {
        public CustomerOnlineBanking()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader rd;

        private String username;
        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
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
            cmb_acc.Text = "";
            cmb_toacc.Text = "";
            txt_toaccno.Clear();
            txt_tnsamt.Clear();
            txt_desc.Clear();
        }

        public void sendEmail()
        {
            con.Open();
            cmd = new SqlCommand("select Email from CustomerRegistration where Username = '" + username + "'", con);
            rd = cmd.ExecuteReader();
            rd.Read();
            string Email = rd.GetString(0);
            con.Close();

            //give a default message body
            string mail = "Dear Sir/Madam, \n Username : " + txt_username.Text + " \n Bank Name : " + cmb_toacc.Text + "\n Account Number : " + txt_toaccno.Text + "\n Bill Amount : " + txt_tnsamt.Text +
                "\n Thank You for the recent payment amount " + txt_tnsamt.Text + ". This is a confermation thatamount has been successfully received. \n" +
                "Best Regards, \n \n Janith Fernando, \n Managing Director, \n IT Division, \n Nexa (PVT) Ltd.";


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

        private void btn_submit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int toaccno;
                double tamt;

                if (cmb_acc.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("ABCD", "HEllo");
                    cmb_acc.Focus();
                }
                else if (cmb_toacc.Text.Length == 0)
                {
                    MessageBox.Show(this, "Beneficery's Bank Cannot Be Null ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cmb_toacc.Focus();
                }
                else if (txt_toaccno.Text.Length == 0)
                {
                    MessageBox.Show(this, "Baneficery's Account Number Cannot be Null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_toaccno.Focus();
                }
                else if (txt_toaccno.Text.Length >= 15)
                {
                    MessageBox.Show(this, "Baneficery's Account Number Cannot Over 15 Numbers ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_toaccno.Focus();
                }
                else if (txt_tnsamt.Text.Length == 0)
                {
                    MessageBox.Show(this, "Transfer Amount Cannot be Null", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_tnsamt.Focus();
                }
                else if (!int.TryParse(txt_toaccno.Text, out toaccno))
                {
                    MessageBox.Show("Account Number Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_toaccno.Focus();
                }
                else if (!double.TryParse(txt_tnsamt.Text, out tamt))
                {
                    if (txt_tnsamt.Text.Length >= 20)
                    {
                        MessageBox.Show(this, "Cannot Transfer This Amount ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_toaccno.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Transfer Amount Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        txt_toaccno.Focus();
                    }
                }
                else if (txt_username.Text != username)
                {
                    MessageBox.Show(this, "Username Is Wrong!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_username.Text = username;
                }
                else
                {
                    double tnsamt = Convert.ToDouble(txt_tnsamt.Text);
                    IOdata IOD = new IOdata();
                    int i = IOD.CustomerInsert("insert into CustomerOnlineBanking values('" + txt_username.Text + "','" + cmb_acc.Text + "','" + cmb_toacc.Text + "','" + txt_toaccno.Text + "', '" + tnsamt + "',getdate())");
                    if (i == 1)
                    {
                        MessageBox.Show("Your Transaction Is Done", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        sendEmail();
                        clear();
                    }
                }
            }
            catch (FormatException)
            {
                double tnsamt;
                if (!double.TryParse(txt_tnsamt.Text, out tnsamt))
                {
                    MessageBox.Show("Transfer Amount Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_tnsamt.Focus();
                    return;
                }
                else
                    MessageBox.Show(this, "Check Your Details Again Please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Check Your Details Again Please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

        private void btn_transaction_history_Selected(object sender, RoutedEventArgs e)
        {
            CustomerTransaction obj = new CustomerTransaction();
            obj.Show();
            Hide();
        }
    }
}
