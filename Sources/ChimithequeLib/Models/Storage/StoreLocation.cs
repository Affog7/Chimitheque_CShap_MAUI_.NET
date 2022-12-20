using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChimithequeLib.Models.Storage
{
    public class StoreLocation
    {
        public StoreLocation_Name StoreLocation_name { get; set; }
        public Storelocation_id Storelocation_Id { get; set; }

        public override string? ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" Name : ");
            sb.Append($"{StoreLocation_name.String} \n");
          
            return sb.ToString();
        }
    }
}
