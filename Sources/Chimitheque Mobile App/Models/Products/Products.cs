using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.Model
{
    public class Products
    {
        public int Product_id { set; get; }
        public string Product_type { set; get; }
        public int Product_sc{ set; get; }

        public Product_Name Product_name { set; get; }
        public List<Product_Symbol> Product_symbols { set; get; }
    }
}
