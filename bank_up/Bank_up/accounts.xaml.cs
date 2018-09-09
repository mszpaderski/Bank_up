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
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Bank_up
{
    /// <summary>
    /// Interaction logic for accounts.xaml
    /// </summary>
    public partial class accounts : Window
    {
        MainWindow mw = new MainWindow();
        public accounts()
        {
            InitializeComponent();

            // Inicjalizacja listy walut
            foreach (currency_table currency in mw.currency_list)
            {
                combo_curr.Items.Add(currency.name);
            }
            combo_curr.SelectedIndex = 0;

            // Uzupełnienie listy kont.
            acc_grid.ItemsSource = mw.account_list;
        }

        // Wciśnięcie funkcji wypłaty powoduje znalezienie konta o odpowiednim numerze i przesłaniu komendy wykonania przelewu z tego konta.
        private void withdraw_butt_Click(object sender, RoutedEventArgs e)
        {
            account acc = mw.account_list.Find(x => x.acc_nr == int.Parse(acc_nr_text.Text));
            acc.withdraw(double.Parse(value_text.Text), combo_curr.Text);
            MessageBox.Show("Saldo po przelewie: " + System.Convert.ToString(acc.balance));
            mw.save_acc_list();
            refresh_acc_list();
        }


        // Wciśnięcie funkcji wpłaty powoduje znalezienie konta o odpowiednim numerze i przesłaniu komendy wykonania przelewu na to konto.
        private void deposit_butt_Click(object sender, RoutedEventArgs e)
        {
            account acc = mw.account_list.Find(x => x.acc_nr == int.Parse(acc_nr_text.Text));
            acc.deposit(double.Parse(value_text.Text), combo_curr.Text);
            MessageBox.Show("Saldo po przelewie: " + System.Convert.ToString(acc.balance));
            mw.save_acc_list();
            refresh_acc_list();

        }

        //Odświerzenie listy kont w oknie.
        public void refresh_acc_list()
        {
            acc_grid.ItemsSource = null;
            acc_grid.ItemsSource = mw.account_list;
        }
    }
}
