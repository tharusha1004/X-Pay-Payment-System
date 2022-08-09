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
    /// Interaction logic for Login_panel.xaml
    /// </summary>
    public partial class Login_panel : Window
    {
        public Login_panel()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            Selection selec = new Selection();
            selec.ShowDialog();
        }

        private void btn_about_us_Click(object sender, RoutedEventArgs e)
        {
            about_us about = new about_us();
            about.ShowDialog();
        }

        private void btn_privacy_Click(object sender, RoutedEventArgs e)
        {
            PrivacyPolicy obj = new PrivacyPolicy();
            obj.Show();
            Hide();
        }

        private void btn_rules_Click(object sender, RoutedEventArgs e)
        {
            Rules_and_Regulations obj = new Rules_and_Regulations();
            obj.Show();
            Hide();
        }
    }
}
