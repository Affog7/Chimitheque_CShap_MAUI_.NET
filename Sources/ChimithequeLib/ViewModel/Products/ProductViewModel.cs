using ChimithequeLib.Model;
using ChimithequeLib.Models;
using ChimithequeLib.Models.Products;
using ChimithequeLib.ViewModel.Products;
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

        private Product product;
        private List<Product_SymbolVM> symbols = new List<Product_SymbolVM>();

        public ProductViewModel()
        {
            product = new Product();
        }

        public ProductViewModel(Product product)
        {
            this.product = product;
            foreach (var e in product.Symbols)
            {
                symbols.Add(new Product_SymbolVM(e));
            }
        }

        // Id product
        public int Product_id { get => product.Product_id; }

        // Product Name
        public string Name 
        { 
            get=>product.Name.Name_label;
            set
            {
                SetProperty(product.Name.Name_label, value, product.Name, (u, n) => u.Name_label = n);
            }
        }

        // Product Type
        public string Product_type
        {
            get => product.Product_type;
           /* set
            {
                SetProperty(product.Product_type, value, product, (u, n) => u.Product_type = n);
            }*/
        }

        // Product....
        public int Product_sc
        {
            get => product.Product_sc;
          /*  set
            {
                SetProperty(product.Product_sc, value, product, (u, n) => u.Product_sc = n);
            }*/
        }

        // Cas product Number
        public string Casnumber {

            get => product.Casnumber.Casnumber_label.String;
          /*  set
            {
                SetProperty(product.Casnumber.Casnumber_label.String, value, product, (u, n) => u.Casnumber.Casnumber_label.String = n);
            }*/
        }

        // Symboles
        public IEnumerable<Product_SymbolVM> Symbols {

            get
            { 
                return symbols.AsReadOnly();
            }
            
           
        }
    }
}
