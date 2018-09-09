using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bank_up
{
    [Serializable, XmlRoot("currency_table")]
    public class currency_table
    {
        public string name { get; set; }
        public double value { get; set; }
    }
}
