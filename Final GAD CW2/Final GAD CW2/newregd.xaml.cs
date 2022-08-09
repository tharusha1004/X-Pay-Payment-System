using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using BespokeFusion;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.Windows.Media.Imaging;


namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for newregd.xaml
    /// </summary>
    public partial class newregd : Window
    {
        public newregd()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        SqlCommand cmd;
        private object img_profile;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_name.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Name Cannot Be Empty !", "Error");
                    txt_name.Focus();
                }
                else if (dtp_birth.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Date Of Birth Cannot Be Empty !", "Error");
                    dtp_birth.Focus();
                }
                else if (txt_age.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Age Cannot Be Empty !", "Error");
                    txt_age.Focus();
                }
                else if (txt_nic.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("NIC Number Cannot Be Empty !", "Error");
                    txt_nic.Focus();
                }
                else if (txt_mobile.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Mobile Number Cannot Be Empty !", "Error");
                    txt_mobile.Focus();
                }
                else if (txt_username.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Userame Cannot Be Empty !", "Error");
                    txt_username.Focus();
                }
                else if (txt_password.Password.Length == 0)
                {
                    MaterialMessageBox.ShowError("Password Cannot Be Empty !", "Error");
                    txt_password.Focus();
                }
                else if (txt_email.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Email Cannot Be Empty !", "Error");
                    txt_email.Focus();
                }
                else if (!Regex.IsMatch(txt_mobile.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                {
                    MaterialMessageBox.ShowError("Your Mobile Number is Not in Correct Format !", "Error");
                    txt_mobile.Focus();
                }
                else if (!Regex.IsMatch(txt_email.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                {
                    MaterialMessageBox.ShowError("Your Email Address is Not in Correct Format !", "Error");
                    txt_email.Focus();
                }
                else
                {
                    con.Open();
                    cmd = new SqlCommand("Insert into DealerRegistration values ('" + txt_name.Text + "', '" + dtp_birth.SelectedDate + "', '" + txt_age.Text + "', '" + txt_nic.Text + "', '" + txt_mobile.Text + "', '" + txt_username.Text + "', '" + txt_password.Password + "', '" + txt_email.Text + "') ", con);
                    int i = cmd.ExecuteNonQuery();
                    if (i == 1)
                    {
                        MessageBox.Show("Success");

                        //give a default message body
                        string mail = "Registration Success Text Here";
                        //to = (txt_email.Text).ToString();
                        //from = (txt_sender.Text).ToString();
                        //mail = (txt_mail.Text).ToString();
                        //password = (txt_password.Text).ToString();

                        MailMessage message = new MailMessage();
                        message.To.Add(txt_email.Text);   //receiver email
                        message.From = new MailAddress("xpay.nexa@gmail.com");  //sender email **default**
                        message.Body = mail;
                        //email subject (what is the purpose)
                        message.Subject = "Email Subject Here";
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Port = 587;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential("xpay.nexa@gmail.com", "Xpaynexa2021");    //Sender email and password
                        try
                        {
                            smtp.Send(message);
                            //MessageBox.Show("Email send successfully", "Email", MessageBoxButton.OK);
                            Dealer_login obj = new Dealer_login();
                            obj.Show();
                            Hide();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
            catch (Exception)
            {
                MaterialMessageBox.ShowError("Please Check Again", "Error");
            }
        }

        private void dtp_birth_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            txt_age.Text = Convert.ToString(DateTime.Now.Year - dtp_birth.SelectedDate.Value.Year);
        }

        private void buttonCloseMessage_Click(object sender, RoutedEventArgs e)
        {
            Dealer_login obj = new Dealer_login();
            obj.Show();
            Hide();
        }

        
    }
}
