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
using System.Text.RegularExpressions;
using System.Windows.Threading;
using CashUI.Windows;

namespace CashUI.Pages
{
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();

            CmbCurrency.Text = "BTC";
        }

        Boolean Connection = false;

        private void Available_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(CmbCurrency.Text))
                MessageBox.Show("Invalid currency", "Error");
            else
                NumberTextBox.Text = Page1.Available.ToString();
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            if (TxtPayTo.Text == " Enter wallet address..." || String.IsNullOrEmpty(TxtPayTo.Text))
                MessageBox.Show("Invalid or empty \"Pay to\"!", "Warning");
            else if (TxtLabel.Text == " Enter label..." || String.IsNullOrEmpty(TxtLabel.Text))
                MessageBox.Show("Invalid or empty \"Label\"!");
            else if (NumberTextBox.Text == "0.00000000" || String.IsNullOrEmpty(NumberTextBox.Text))
                MessageBox.Show("Invalid or empty \"Ammount\"!");
            else if (String.IsNullOrEmpty(CmbCurrency.Text))
                MessageBox.Show("Choose currency!");
            else
            {
                MessageBoxResult result = MessageBox.Show("Pay to: \t\t" + TxtPayTo.Text + "\nLabel: \t\t" +
                    TxtLabel.Text + "\nAmmount: \t " + NumberTextBox.Text + " " + CmbCurrency.Text + "\nTransaction fee: \t " +
                    Trans.Content + "\n\n Does everything agree?", "Send", MessageBoxButton.YesNo);
                string success = "no";

                //check if data corrrect
                if (Connection == true)
                   success = "yes";

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        if (success == "yes")
                        {
                            MessageBox.Show("Sent successfully!");
                        }
                        else
                        {
                            MessageBox.Show("Sending failed!");
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        private void ClearAll_Click(object sender, RoutedEventArgs e)
        { 
            MessageBoxResult result = MessageBox.Show("Are you sure?", "Clear all", MessageBoxButton.YesNo, MessageBoxImage.Question);
            switch(result)
            {
                case MessageBoxResult.Yes:
                    TxtPayTo.Text = String.Empty;
                    TxtLabel.Text = String.Empty;
                    NumberTextBox.Text = "0.00000000";
                    CmbCurrency.Text = String.Empty;
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Window1 w1 = new Window1();
            w1.ShowDialog();
            if (String.IsNullOrEmpty(Window1.LoadContacts)) { }
            else TxtPayTo.Text = Window1.LoadContacts.ToString();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Choose_Click(object sender, RoutedEventArgs e)
        {
            Window2 w2 = new Window2();
            w2.ShowDialog();
            Trans.Content = Window2.ChoosenFee.ToString();
        }
    }
}
