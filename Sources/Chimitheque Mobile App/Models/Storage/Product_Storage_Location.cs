using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.Model.Storage
{
    public class Product_Storage_Location
    {
        public Storage_Id Storage_id { set; get; }
        public string Storage_qrcode { set; get; }
        public Boolean Valid { set; get; }

        public Products Products { set; get; }

        public StoreLocation Storelocation { get;set; }
        public Storage_quantity Storage_quantity { get;set; }
        public Unit_quantity Unit_quantity { get;set; }

    }
}
