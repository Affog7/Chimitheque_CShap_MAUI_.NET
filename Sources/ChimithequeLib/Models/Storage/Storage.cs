using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Model.Storage
{
    public class Storage
    {
        public List<Product_Storage_Location> Rows { set; get; } = new List<Product_Storage_Location>();    
    }
}
