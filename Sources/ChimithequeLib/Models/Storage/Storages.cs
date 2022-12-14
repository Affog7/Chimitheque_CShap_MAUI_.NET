using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChimithequeLib.ViewModel;

namespace ChimithequeLib.Models.Storage
{
    public class Storages
    {
        public List<Product_Storage_Location> Rows { set; get; } = new List<Product_Storage_Location>();    
    }
}
