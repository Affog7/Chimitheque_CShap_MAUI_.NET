using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Models.Products
{
    public class CasNumber
    {
        public CasnumberId Casnumber_id { get; set; }
        public CasnumberLabel Casnumber_label { get; set; }
    }

    public class CasnumberId
    {
        public long Int64 { set; get; }

    }

    public class CasnumberLabel { 

        public string String { get; set; }
    }
}
