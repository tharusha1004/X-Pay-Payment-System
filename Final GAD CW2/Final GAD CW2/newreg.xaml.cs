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
using System.Net;
using System.Net.Mail;
using BespokeFusion;
using System.Text.RegularExpressions;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for newreg.xaml
    /// </summary>
    public partial class newreg : Window
    {
        public newreg()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        SqlCommand cmd;
        
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
                else if (cmb_selection.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Choose Your User Type !", "Error");
                    cmb_selection.Focus();
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
                    if (cmb_selection.SelectedIndex == 0)
                    {
                        con.Open();
                        cmd = new SqlCommand("Insert into CustomerRegistration values ('" + txt_name.Text + "', '" + dtp_birth.SelectedDate + "', '" + txt_age.Text + "', '" + txt_nic.Text + "', '" + txt_mobile.Text + "', '" + txt_username.Text + "', '" + txt_password.Password + "', '" + txt_email.Text + "') ", con);
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
                                Customer_Login obj = new Customer_Login();
                                obj.Show();
                                Hide();

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else
                            MessageBox.Show("Error");
                    }
                    else if (cmb_selection.SelectedIndex == 1)
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
                        else
                            MaterialMessageBox.ShowError("Please Check Again", "Error");
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
        //MessageBox.Show("You Are SuccussFully Registered !", "Info", MessageBoxButton.OK, MessageBoxImage.Information);

    }

        
    

}
