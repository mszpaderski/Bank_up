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

namespace Bank_up
{
    /// <summary>
    /// Interaction logic for acc_create_page.xaml
    /// </summary>
    public partial class acc_create_page : Window
    {
        MainWindow mw = new MainWindow();
        public acc_create_page()
        {
            InitializeComponent();

            // Inicjalizacja listy walut
            foreach (currency_table currency in mw.currency_list)
            {
                combo_curr.Items.Add(currency.name);
            }
            combo_curr.SelectedIndex = 0;

        }

        //Tworzenie nowego konta.
        private void button_Click(object sender, RoutedEventArgs e)
        {
            account acc_add = new account();
            acc_add.acc_nr = int.Parse(acc_nr_text.Text);
            acc_add.owner = owner_text.Text;
            acc_add.currency = combo_curr.Text;
            acc_add.interest_type = double.Parse(interest_text.Text);
            acc_add.balance = Math.Round(double.Parse(balance_text.Text), 2);

            mw.account_list.Add(acc_add);
            mw.save_acc_list();

            MessageBox.Show("Stworzono konto o numerze: " + acc_add.acc_nr + "\nWłaściciel: " + acc_add.owner);
            this.Close();
        }
    }
}
