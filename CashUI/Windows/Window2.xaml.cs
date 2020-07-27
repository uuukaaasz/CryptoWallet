using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CashUI.Windows
{
    /// <summary>
    /// Logika interakcji dla klasy Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public static string ChoosenFee;

        public Window2()
        {
            InitializeComponent();

            TxtChoose.Text = "0.00000000";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(TxtChoose.Text))
                MessageBox.Show("Incorrect fee", "Error");
            else
            {
                ChoosenFee = TxtChoose.Text;
                this.Close();
            }
        }
    }
}
