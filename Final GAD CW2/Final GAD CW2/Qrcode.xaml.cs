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
using System.Drawing;
using System.IO;
using ZXing;

namespace Final_GAD_CW2
{
    /// <summary>
    /// Interaction logic for Qrcode.xaml
    /// </summary>
    public partial class Qrcode : Window
    {
        public Qrcode()
        {
            InitializeComponent();
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
