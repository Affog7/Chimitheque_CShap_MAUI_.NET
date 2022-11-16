using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Model
{
    public class Products
    {
        public int Product_id { set; get; }
        public string Product_type { set; get; }
        public int Product_sc{ set; get; }

        public Product_Name Name { set; get; }
        public List<Product_Symbol> Symbols { set; get; }
    }
}
