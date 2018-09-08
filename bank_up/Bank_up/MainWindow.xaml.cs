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
        XmlSerializer xs;
        List<currency_table> currency_list;


        public MainWindow()
        {
            InitializeComponent();
            currency_list = new List<currency_table>();
            xs = new XmlSerializer(typeof(List<currency_table>));

           // FileStream fs = new FileStream("http://www.nbp.pl/kursy/xml/LastA.xml", FileMode.Open, FileAccess.Read);
           // currency_list = (List<currency_table>)xs.Deserialize(fs);

           // fs.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            FileStream fs = new FileStream("Currencies_list.xml", FileMode.Create, FileAccess.Write);
            currency_table currency = new currency_table();
            currency.name = name_text.Text;
            currency.value = int.Parse(value_text.Text);

            currency_list.Add(currency);

            xs.Serialize(fs, currency_list);

            fs.Close();
        }
    }
}
