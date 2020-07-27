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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace CashUI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new Pages.Page1();
        }

        private void Btn2_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new Pages.Page2();
        }

        private void Btn3_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new Pages.Page3();
        }

        private void Btn4_Click(object sender, RoutedEventArgs e)
        {
            main.Content = new Pages.Page4();
        }

        private void Default_Color_Click(object sender, RoutedEventArgs e)
        {
            Background = Brushes.LightGray;
        }

        private void Blue_Color_Click(object sender, RoutedEventArgs e)
        {
            Background = Brushes.LightBlue;
        }

        private void Red_Color_Click(object sender, RoutedEventArgs e)
        {
            Background = Brushes.LightPink;
        }

        private void Green_Color_Click(object sender, RoutedEventArgs e)
        {
            Background = Brushes.LightGreen;
        }
    }
}
