using ChimithequeLib.Model;
using ChimithequeLib.Models.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Models
{
    public class Product : IEquatable<Product>
    {
        public int Product_id { set; get; }
        public string Product_type { set; get; }
        public int Product_sc{ set; get; }
        public CasNumber Casnumber { set; get; }
        public Product_Name Name { set; get; }
        public List<Product_Symbol> Symbols { set; get; }

        public override bool Equals(Object other)
        {
            if(ReferenceEquals(null, other)) return false;
            if(ReferenceEquals(this, other)) return true;
            if(GetType() != other.GetType()) return false;
            return Equals(other as Product);
        }

        public  bool Equals(Product obj)
        {
            return Name.Name_label.Equals(obj.Name.Name_label);
        }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" Name : ");
            sb.Append($"{Name.Name_label}");
            sb.Append("\n Type : ");
            sb.Append($"{Product_type}");

            if(Symbols != null)
            {
                sb.Append("\n Symbols : ");
                foreach(var symbol in Symbols)
                {
                    sb.Append($"\t- {symbol.Symbol_label}\n");
                }
                
            }
                
            
            
            return sb.ToString();
        }
    }
}
