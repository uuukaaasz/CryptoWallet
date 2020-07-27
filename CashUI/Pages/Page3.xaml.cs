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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NBitcoin;
using ZXing;
using ZXing.QrCode.Internal;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace CashUI.Pages
{
    public partial class Page3 : Page
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            string[] array = { "1oKQZzxmfv39UpoJNUWzLf1mfyB1vhrBh", "1G93KS1HTk1Jp8JcyYxiazK9G2Vt4SF56U", "1GKwtsf1WH3cy6SYsgPYXcDWWpP5CvGwcS", "1H3NxKczrkWzYrtjrByLPAmbeGd6QpEYUy", "13JihVztcdaHmV765JabKr8XFAQ3MpRpg8",
                "15VYwHA9YcAjucSe15bDSvzPxMi64WFafN", "18jhW21E8iTMAQEQWUE5QtZGaH5Cdnq21t", "1Fj2U8mSrEJRohxq2tw9xLBou7iqoUWQWe", "1NBwiQqvMmX2J1VCVvJ4oWjmC7Hz2BXFkN", "1MKZP1DBASQFgq2qqfWrxgtXmKQYVaQLN1",
                "1H5GTRtMMPAokA8XSnQZ7syyo9ReB1dL3V", "1En7Yn6JWUNTEmxTK6TVTpiCLBZ9bvMftM", "1LTNsUum3hyJ6tLCBRgZZAHumbzd8fWUMD", "1Gj4xdSgF3wuG34hQbuNij1HgoV8gPXHSC", "1KQNEiJ946uc9ESoFCRfA12ViC4nqRTdXw",
                "1PdyxKMM3x1MeCuRvs8W9XoyukP43QJHgR", "1PY5uB4Yo9YvLCL1hL8QtHnXRHUsRBbdbc", "1GE981FMpmRotabA3pT23y2t4DK25XVmnm", "1L8rwLJ9KVAWEgzNaJEZdgw5TfArKnhRbm", "132AKwda6iAzJzKcBZ9TMhbPAGfDdw3LhP" };
            int i = rnd.Next(0, 20);
            
            Txt_adr.Text = array[i];

            imgQRCode.Source = null;
        }

        private void QR_Click(object sender, RoutedEventArgs e)
        {
            QrEncoder encoder = new QrEncoder(Gma.QrCodeNet.Encoding.ErrorCorrectionLevel.M);
            QrCode qrCode;
            encoder.TryEncode(Txt_adr.Text, out qrCode);
            WriteableBitmapRenderer wRenderer = new WriteableBitmapRenderer(new FixedModuleSize(2, QuietZoneModules.Two), Colors.Black, Colors.White);
            WriteableBitmap wBitmap = new WriteableBitmap(70, 70, 96, 96, PixelFormats.Gray8, null);
            wRenderer.Draw(wBitmap, qrCode.Matrix);

            imgQRCode.Source = wBitmap;
        }
    }
}
