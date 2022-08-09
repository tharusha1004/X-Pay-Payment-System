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
using BespokeFusion;
using System.Net;
using System.Net.Mail;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for CustomerBillPayment.xaml
    /// </summary>
    public partial class CustomerBillPayment : Window
    {
        public CustomerBillPayment()
        {
            InitializeComponent();
        }
        private SqlConnection con = new SqlConnection("Data Source=LAPTOP-K3UER6UD;Initial Catalog=XPay_Payment_System;Integrated Security=True");
        private SqlCommand cmd;
        private SqlDataReader rd;

        private string username;

        private void Grid_Loaded(object sender, RoutedEventArgs e)
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
            cmd = new SqlCommand("select Email from CustomerRegistration where Username = '"+ username +"'", con);
            rd = cmd.ExecuteReader();
            rd.Read();
            string Email = rd.GetString(0);
            con.Close();

            //give a default message body
            string mail = "Dear Sir/Madam, \n Username : "+txt_username.Text +" \n Bill Type : "+cmb_category.Text + "\n Bill Number : "+txt_bnum.Text+ "\n Bill Amount : "+txt_bamt.Text+ 
                "\n Thank You for the recent payment amount "+txt_bamt.Text+ ". This is a confermation thatamount has been successfully received. \n" +
                "Best Regards, \n \n Janith Fernando, \n Managing Director, \n IT Division, \n Nexa (PVT) Ltd.";
            

            MailMessage message = new MailMessage();
            message.To.Add(Email);   //receiver email
            message.From = new MailAddress("xpay.nexa@gmail.com");  //sender email **default**
            message.Body = mail;
            //email subject (what is the purpose)
            message.Subject = "Bill Payment Achknowledgement";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("xpay.nexa@gmail.com", "Xpaynexa2021");    //Sender email and password
            smtp.Send(message);


        }

        public void clear()
        {
            cmb_category.Text = "";
            cmb_biller.Text = "";
            txt_bnum.Clear();
            txt_bamt.Clear();
        }

        private void btn_home_Selected(object sender, RoutedEventArgs e)
        {
            CustomerMainWindow obj = new CustomerMainWindow();
            obj.Show();
            Hide();
        }

        private void cmb_category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_category.SelectedIndex == 0)
            {
                cmb_biller.Items.Clear();
                cmb_biller.Items.Add("LECO");
                cmb_biller.Items.Add("CEB");
            }
            else if (cmb_category.SelectedIndex == 1)
            {
                cmb_biller.Items.Clear();
                cmb_biller.Items.Add("WATER BOARD");
            }
            else if (cmb_category.SelectedIndex == 2)
            {
                cmb_biller.Items.Clear();
                cmb_biller.Items.Add("Dialog");
                cmb_biller.Items.Add("Telecom");
            }
            else if (cmb_category.SelectedIndex == 3)
            {
                cmb_biller.Items.Clear();
                cmb_biller.Items.Add("Celinco Life Insurance");
                cmb_biller.Items.Add("AIA Insurance");
                cmb_biller.Items.Add("Janashakthi Insurance");
                cmb_biller.Items.Add("AIA Insurance");
                cmb_biller.Items.Add("Allianz Insurance");
                cmb_biller.Items.Add("Fairfirst Insurance");
                cmb_biller.Items.Add("Softlogic Life Insurance");
            }
            else if (cmb_category.SelectedIndex == 4)
            {
                cmb_biller.Items.Clear();
                cmb_biller.Items.Add("Senkadagala Finance(SFCL)");
                cmb_biller.Items.Add("Merchant Bank of Sri Lanka(MBSL)");
                cmb_biller.Items.Add("Citizens Development Business Finance(CDB)");
                cmb_biller.Items.Add("Commercial Credit and Finance(COCR)");
                cmb_biller.Items.Add("Alliance Finance(ALLI)");
                cmb_biller.Items.Add("Mercantile Investments &Finance(MERC)");
                cmb_biller.Items.Add("Softlogic Finance(CRL)");
                cmb_biller.Items.Add("Singer Finance(SFIN)");
            }
            else if (cmb_category.SelectedIndex == 5)
            {
                cmb_biller.Items.Clear();
                cmb_biller.Items.Add("Treasury bills");
                cmb_biller.Items.Add("Treasury bonds");
                cmb_biller.Items.Add("Sri Lanka Development Bonds(SLDBs)");
            }
        }

        private void btn_pay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cmb_category.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Bill Category Cannot be Empty !", "Error");
                    cmb_category.Focus();
                }
                else if (cmb_biller.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Biller Type Cannot be Empty !", "Error");
                    cmb_biller.Focus();
                }
                else if (txt_bnum.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Bill Number Cannot be Empty !", "Error");
                    txt_bnum.Focus();
                }
                else if (txt_bamt.Text.Length == 0)
                {
                    MaterialMessageBox.ShowError("Bill Amount Cannot be Empty !", "Error");
                    txt_bamt.Focus();
                }
                else if (txt_bnum.Text.Length >= 40)
                {
                    MaterialMessageBox.ShowError("Bill Number Cannot be over 40 Numbers ! ", "Error");
                    txt_bnum.Focus();
                }
                else if (txt_bamt.Text.Length >= 20)
                {
                    MaterialMessageBox.ShowError("Cannot Transfer This Amount ! ", "Error");
                    txt_bamt.Focus();
                }
                else if (txt_username.Text != username)
                {
                    MaterialMessageBox.ShowError("Username Is Wrong! \n We Will Fix It", "Error");
                    txt_username.Text = username;
                }
                else
                {
                    double bamt = Convert.ToDouble(txt_bamt.Text);
                    IOdata iod = new IOdata();
                    int i = iod.CustomerInsert("Insert into CustomerBillPayment values('" + txt_username.Text + "','" + cmb_category.Text + "','" + cmb_biller.Text + "','" + txt_bnum.Text + "', '" + bamt + "', GETDATE())");
                    if (i == 1)
                    {
                        MaterialMessageBox.Show("Your Transaction Is Done", "Information");
                        sendEmail();
                        clear();
                    }
                }
            }
            catch (FormatException)
            {
                double bamt;
                if (!double.TryParse(txt_bamt.Text, out bamt))
                {
                    MaterialMessageBox.ShowError("Bill Amount Can't Be Contain Strings Or Characters!", "Error");
                    txt_bamt.Focus();
                    return;
                }
                else
                    MaterialMessageBox.ShowError("Check Your Details Again Please !", "Error");
            }
            catch (Exception)
            {
                MaterialMessageBox.ShowError("Check Your Details Again Please !", "Error");
            }
        }

        private void btn_cls_Click(object sender, RoutedEventArgs e)
        {
            clear();
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
    }
}
