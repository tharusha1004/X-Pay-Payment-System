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

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for about_us.xaml
    /// </summary>
    public partial class about_us : Window
    {
        public about_us()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string street = "127, 30 Vinayalankara Mawatha";
            string city = "Colombo";
            

            try
            {
                StringBuilder queryaddress = new StringBuilder();
                queryaddress.Append("http://maps.google.com/maps?q=");
                if (street != string.Empty)
                {
                    queryaddress.Append(street + "," + "+");
                }
                if (city != string.Empty)
                {
                    queryaddress.Append(city + "," + "+");
                }



                web_map.Navigate(queryaddress.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Error");
            }
        }

        private void buttonCloseMessage_Click(object sender, RoutedEventArgs e)
        {
            Login_panel obj = new Login_panel();
            obj.Show();
            Hide();
        }
    }
}
