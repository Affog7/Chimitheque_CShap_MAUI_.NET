using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChimithequeLib.Model.Storage
{
    public class Product_Storage_Location
    {
        public Storage_Id Storage_id { set; get; }
        public string Storage_qrcode { set; get; }
        public Boolean Valid { set; get; }

        public Product Product { set; get; }

        public StoreLocation Storelocation { get;set; }
        public Storage_quantity Storage_quantity { get;set; }
        public Unit_quantity Unit_quantity { get;set; }


        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Product Name : ");
            sb.Append($"{Product.Name.Name_label    }");
            
            sb.Append("\n Qantite : ");
            sb.Append($"{Storage_quantity.Float64} {Unit_quantity.Unit_label.String} \n");
            
            sb.Append("\n Entrepot : ");
            sb.Append($"{Storelocation.StoreLocation_name.String} \n");

            



            return sb.ToString();
        }
    }
}
