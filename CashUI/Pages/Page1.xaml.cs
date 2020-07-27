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

namespace CashUI.Pages
{
    public partial class Page1 : Page
    {
        public static string Available;

        public Page1()
        {
            InitializeComponent();

            Available = LblAvailable.Content.ToString();

            CmbCurrency.Text = "BTC";
            
        }

        private void ChangeCurenncy_Click(object sender, RoutedEventArgs e)
        {
            LabelA.Content = CmbCurrency.Text;
            LabelP.Content = CmbCurrency.Text;
            LabelT.Content = CmbCurrency.Text;
        }

        internal class ForegroundProperty
        {
        }
    }
}
