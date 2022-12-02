using ChimithequeLib.Model;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChimithequeLib.ViewModel.Products
{
    public partial class Product_Name_ViewModel:ObservableObject
    {
        //View Model for Product_Name
        private Product_Name product_name;

        public Product_Name_ViewModel()
        {
            product_name = new Product_Name();
        }
        public string Name_label 
        {
            get { return product_name.Name_label; }
            set
            {
                SetProperty(product_name.Name_label, value, product_name, (u, n) => u.Name_label = n);
            }
        }
    }
}
