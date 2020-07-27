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
using CashUI.Pages;
using SQLite;

namespace CashUI.Windows
{
    public partial class Window1 : Window
    {                
        public static string LoadContacts;

        [Table("Contact")]
        public class Contact
        {
            [PrimaryKey, AutoIncrement, Column("_id")]
            public int Id { get; set; }
            [MaxLength(16)]
            public string Name { get; set; }
            [MaxLength(34)]
            public string Address { get; set; }
        }

        public Window1()
        {
            InitializeComponent();
            var db = new SQLiteConnection(App.databasePath);
            db.CreateTable<Contact>();
            if (db.Table<Contact>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Contact();
                newStock.Name = "App Creator";
                newStock.Address = "1EPBLmWxRKdUohYiF6h2gHZQSjauCaWCxX";
                db.Insert(newStock);
            }
            var table = db.Table<Contact>();
            foreach (var s in table)
            {
                CmbContact.Items.Add(s.Name);
            }
        }

        public void LoadContact_Click(object sender, RoutedEventArgs e)
        {
            var db = new SQLiteConnection(App.databasePath);

            var table = db.Table<Contact>();
            LoadContacts = CmbContact.Text;
            foreach (var s in table)
            {
                if (s.Name == LoadContacts)
                {
                    LoadContacts = s.Address;
                    break;
                }
            }

            this.Close();
        }

        public void SaveContact_Click(object sender, RoutedEventArgs e)
        {
            var db = new SQLiteConnection(App.databasePath);
            db.CreateTable<Contact>();
            if (db.Table<Contact>().Count() == 0)
            {
                // only insert the data if it doesn't already exist
                var newStock = new Contact();
                newStock.Name = "App Creator";
                newStock.Address = "1EPBLmWxRKdUohYiF6h2gHZQSjauCaWCxX";
                db.Insert(newStock);
            }

            if (String.IsNullOrEmpty(TxtName.Text) || String.IsNullOrEmpty(TxtAddress.Text))
            {
                MessageBox.Show("Error! Incorrect or empty values", "Error");
            }
            else
            {
                var newContact = new Contact();
                newContact.Name = TxtName.Text;
                newContact.Address = TxtAddress.Text;
                db.Insert(newContact);
                CmbContact.Items.Add(TxtName.Text);
                MessageBox.Show("Adding success!", "Save");
            }
        }
    }
}
