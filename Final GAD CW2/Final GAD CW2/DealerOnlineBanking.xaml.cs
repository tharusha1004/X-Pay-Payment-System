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
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for DealerOnlineBanking.xaml
    /// </summary>
    public partial class DealerOnlineBanking : Window
    {
        public DealerOnlineBanking()
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
            cmb_toacc.Text = "";
            txt_toaccno.Clear();
            txt_tamt.Clear();
            txt_desc.Clear();
            txt_cname.Clear();
            txt_cmobno.Clear();
            txt_cemail.Clear();
        }

        public void sendEmail()
        {
            string Email = txt_cemail.Text;

            //give a default message body
            string mail = "Dear Sir/Madam, \n Username : " + txt_username.Text + " \n Bank Name : " + cmb_toacc.Text + "\n Account Number : " + txt_toaccno.Text + "\n Bill Amount : " + txt_tamt.Text +
                "\n Thank You for the recent payment amount " + txt_tamt.Text + ". This is a confermation thatamount has been successfully received. \n" +
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

        private void btn_transfer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int toaccno;

                if (cmb_toacc.Text.Length == 0)
                {
                    MessageBox.Show("Beneficeary Bank Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cmb_toacc.Focus();
                }
                else if (txt_toaccno.Text.Length == 0)
                {
                    MessageBox.Show("Beneficeary Account Number Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_toaccno.Focus();
                }
                else if (txt_tamt.Text.Length == 0)
                {
                    MessageBox.Show("Trancefer Amount Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_tamt.Focus();
                }
                else if (txt_cname.Text.Length == 0)
                {
                    MessageBox.Show("Customer Name Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_cname.Focus();
                }
                else if (txt_cmobno.Text.Length == 0)
                {
                    MessageBox.Show("Customer Mobile Number Cannot Be Empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_cmobno.Focus();
                }
                else if (txt_toaccno.Text.Length >= 15)
                {
                    MessageBox.Show("Beneficeary Account Number Cannot Be Over 15 Numbers ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_toaccno.Focus();
                }
                else if (txt_tamt.Text.Length == 20)
                {
                    MessageBox.Show("Cannot Transfer This Amount ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_tamt.Focus();
                }
                else if (txt_cname.Text.Length >= 30)
                {
                    MessageBox.Show("Customer Name Cannot Be Containt Over 30 Characters ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_cname.Focus();
                }
                else if (!Regex.IsMatch(txt_cmobno.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                {
                    MessageBox.Show("Customer Mobile Number Is Not In Correct Format!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_cmobno.Focus();
                }
                else if (!int.TryParse(txt_toaccno.Text, out toaccno))
                {
                    MessageBox.Show("Account Number Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_toaccno.Focus();
                }
                else if (txt_username.Text != username)
                {
                    MessageBox.Show(this, "Username Is Wrong! \n We Will Fix It", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_username.Text = username;
                }
                else
                {
                    double tamt = Convert.ToDouble(txt_tamt.Text);
                    IOdata iod = new IOdata();
                    int i = iod.DealerInsert("Insert into DealerOnlineBanking values('" + txt_username.Text + "','" + cmb_toacc.Text + "', '" + txt_toaccno.Text + "', '" + tamt + "', '" + txt_cname.Text + "', '" + txt_cmobno.Text + "', GETDATE())");
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
                double toaccno;
                if (!double.TryParse(txt_tamt.Text, out tnsamt))
                {
                    MessageBox.Show("Transfer Amount Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_tamt.Focus();
                    return;
                }
                else if (!double.TryParse(txt_toaccno.Text, out toaccno))
                {
                    MessageBox.Show("Account Number Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_tamt.Focus();
                    return;
                }
                else
                    MessageBox.Show(this, "Check Your Details Again Please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (OutOfMemoryException)
            {
                // Out Of Memory Exception
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

        private void btn_historyt_Selected(object sender, RoutedEventArgs e)
        {
            DealerTransaction obj = new DealerTransaction();
            obj.Show();
            Hide();
        }
    }
}
