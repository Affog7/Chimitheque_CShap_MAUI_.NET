using ChimithequeLib.Model;
using ChimithequeLib.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.ViewModel
{
    public class ProductViewModel:ObservableObject
    {
        public int Id { get; set; }
        private Product product;

        public ProductViewModel()
        {
            product = new Product();
        }
        
        public string Name 
        { 
            get=>product.Name.Name_label;
            set
            {
                SetProperty(product.Name.Name_label, value, product.Name, (u, n) => u.Name_label = n);
            }
        }
    }
}
