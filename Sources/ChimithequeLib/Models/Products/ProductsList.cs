using ChimithequeLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.Models
{
    public class ProductsList
    {
        public List<Products> Rows { set; get; } = new List<Products>();
    }
}
