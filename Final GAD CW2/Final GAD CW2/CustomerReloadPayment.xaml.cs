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
using System.Drawing;
using System.Drawing.Imaging;
using ZXing;
using System.IO;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for CustomerReloadPayment.xaml
    /// </summary>
    public partial class CustomerReloadPayment : Window
    {
        public CustomerReloadPayment()
        {
            InitializeComponent();
        }

        private SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader rd;


        private string username;
        private void btn_home_Selected(object sender, RoutedEventArgs e)
        {
            CustomerMainWindow obj = new CustomerMainWindow();
            obj.Show();
            Hide();
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

        public void sendEmail()
        {
            con.Open();
            cmd = new SqlCommand("select Email from CustomerRegistration where Username = '" + username + "'", con);
            rd = cmd.ExecuteReader();
            rd.Read();
            string Email = rd.GetString(0);
            con.Close();

            //give a default message body
            string mail = "Dear Sir/Madam, \n Username : " + txt_username.Text + " \n Service Provider : " + cmb_misp.Text + "\n Mobile Number : " + txt_mobileno.Text + "\n Reload Amount : " + txt_value.Text +
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

        private void clear()
        {
            cmb_misp.Text = "";
            txt_value.Clear();
            txt_mobileno.Clear();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_misp.Text.Length == 0)
                {
                    MessageBox.Show(this, "Your SIM Card Provider Cannot Be Empty! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    cmb_misp.Focus();
                }
                else if (txt_value.Text.Length == 0)
                {
                    MessageBox.Show(this, "Your Package Calue Cannot Be Empty! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_value.Focus();
                }
                else if (txt_value.Text.Length >= 20)
                {
                    MessageBox.Show(this, " Your Package Value Cannot Reload ! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_value.Focus();
                }
                else if (txt_mobileno.Text.Length == 0)
                {
                    MessageBox.Show(this, "Your Phone Number Cannot Be Empty! ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_mobileno.Focus();
                }
                else if (!Regex.IsMatch(txt_mobileno.Text, @"^(?:7|0|(?:\+94))[0-9]{8,9}$"))
                {
                    MessageBox.Show(this, "Your Phone Number Is Not In Correct Format !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_mobileno.Focus();
                }
                else if (txt_username.Text != username)
                {
                    MessageBox.Show(this, "Username Is Wrong! \n We Will Fix It", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_username.Text = username;
                }
                else
                {
                    double rvalue = Convert.ToDouble(txt_value.Text);
                    IOdata iod = new IOdata();
                    int i = iod.CustomerInsert("Insert into CustomerReloadPayment values ('" + txt_username.Text + "', '" + cmb_misp.Text + "', '" + rvalue + "', '" + txt_mobileno.Text + "', GETDATE()) ");
                    if (i == 1)
                    {
                        MessageBox.Show("Your Transaction Is Done", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                        sendEmail();
                        clear();
                    }
                }
            }
            catch (System.FormatException)
            {
                double rvalue;
                if (!double.TryParse(txt_value.Text, out rvalue))
                {
                    MessageBox.Show("Reload Amount Can't Be Contain Strings Or Characters!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    txt_value.Focus();
                    return;
                }
                else
                    MessageBox.Show(this, "Check Your Details Again Please!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Please Check Your Details Again!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            clear();
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

        private void btnConvert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Drawing.Image img = null;
                BitmapImage bimg = new BitmapImage();
                using (var ms = new MemoryStream())
                {
                    BarcodeWriter writer;
                    writer = new ZXing.BarcodeWriter() { Format = BarcodeFormat.QR_CODE };
                    writer.Options.Height = 80;
                    writer.Options.Width = 280;
                    writer.Options.PureBarcode = true;
                    //img = writer.Write(this.txtbarcodecontent.Text);
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    ms.Position = 0;
                    bimg.BeginInit();
                    bimg.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                    bimg.CacheOption = BitmapCacheOption.OnLoad;
                    bimg.UriSource = null;
                    bimg.StreamSource = ms;
                    bimg.EndInit();
                    this.imgbarcode.Source = bimg;// return File(ms.ToArray(), "image/jpeg");  
                    this.tbkbarcodecontent.Text = this.txtbarcodecontent.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
    

