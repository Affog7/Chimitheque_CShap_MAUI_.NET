using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChimithequeLib.Model
{
    public class Product_Name
    {
        public string Name_label { get; set; }


        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" Name : ");
            sb.Append($"{Name_label}");




            return sb.ToString();
        }
    }
}
