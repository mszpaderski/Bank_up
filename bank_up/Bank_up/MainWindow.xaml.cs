using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Bank_up
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public XmlSerializer xs_curr;
        public List<currency_table> currency_list;
        public XmlSerializer xs_acc;
        public List<account> account_list;

        private static System.Timers.Timer int_timer;

        public MainWindow()
        {
            InitializeComponent();

            //Ściągnięcie listy walut i ich wartości.
            currency_list = new List<currency_table>(); 
            xs_curr = new XmlSerializer(typeof(List<currency_table>), "Bank_up");
            FileStream fs_curr = new FileStream(@"..\..\Currencies_list.xml", FileMode.Open, FileAccess.Read);
            currency_list = (List<currency_table>)xs_curr.Deserialize(fs_curr);
            fs_curr.Close();   
            //Teraz currency_list zawiera listę walut.

            //Ściągnięcie listy kont i ich wartości.
            account_list = new List<account>(); 
            xs_acc = new XmlSerializer(typeof(List<account>), "Bank_up");           
            FileStream fs_acc = new FileStream(@"..\..\Account_list.xml", FileMode.Open, FileAccess.Read);
            account_list = (List<account>)xs_acc.Deserialize(fs_acc);
            fs_acc.Close();
            //Teraz currency_list zawiera listę walut.

            SetTimer();
        }

        //Obsługa timera do odsetek. Ustawiony za pomocą timera co 24 dni ponieważ Timer.interval może pomieścić maksymalną wartość int32 . Lepszą wersją by był Task Sheduler po stronie serwera.
        private void SetTimer()
        {
            int_timer = new System.Timers.Timer(TimeSpan.FromDays(24).TotalMilliseconds);
            int_timer.Elapsed += on_int_timer;
            int_timer.AutoReset = true;
            int_timer.Enabled = true;
        }

        private void on_int_timer(Object source, ElapsedEventArgs e)
        {
            foreach (account acc in account_list)
            {
                acc.bring_interests();

            }
        }
        //Koniec Timera
    
    // Zapisywanie danych listy kont do pliku XML.
    public void save_acc_list()
        {
            FileStream fs_acc_write = new FileStream(@"..\..\Account_list.xml", FileMode.Create, FileAccess.Write);
            xs_acc.Serialize(fs_acc_write, account_list);
            fs_acc_write.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            accounts acc_page = new accounts();
            acc_page.ShowDialog();
        
        }

        private void acc_create_button_Click(object sender, RoutedEventArgs e)
        {
            acc_create_page acc_create_page = new acc_create_page();
            acc_create_page.ShowDialog();
        }
    }
}
