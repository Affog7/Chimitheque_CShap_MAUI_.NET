using ChimithequeLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.Models;

namespace ChimithequeLib.ViewModel
{
    public class Product_Storage_LocationViewModel : ObservableObject
    {
        private Product_Storage_Location product_Storage_Location;
        private ProductViewModel product;

        public Product_Storage_LocationViewModel()
        {
        }

        public Product_Storage_LocationViewModel(Product_Storage_Location model)
        {
            product_Storage_Location = model;
            product = new ProductViewModel(model.Product);
         }


        // Id stockage
        public int Storage_id 
        { 
            get => product_Storage_Location.Storage_id.Int64;
            set
            {
                SetProperty(product_Storage_Location.Storage_id.Int64, value, product_Storage_Location.Storage_id, (u, n) => u.Int64 = n);
            }
        }

        // Qrcode
        public string Storage_qrcode
        {
            get => product_Storage_Location.Storage_qrcode;
            set
            {
                SetProperty(product_Storage_Location.Storage_qrcode, value, product_Storage_Location, (u, n) => u.Storage_qrcode = n);
            }
         }

        // Validité
        public bool Valid
        {
            get => product_Storage_Location.Valid;
            set
            {
                SetProperty(product_Storage_Location.Valid, value, product_Storage_Location, (u, n) => u.Valid = n);
            }
        }

        // Produit
        public ProductViewModel Product
        {
            get => product;
          
        }

        // Entrepôt
        public string Storelocation
        {
            get => product_Storage_Location.Storelocation.StoreLocation_name.String;
            set
            {
                SetProperty(product_Storage_Location.Storelocation.StoreLocation_name.String, value, product_Storage_Location, (u, n) => u.Storelocation.StoreLocation_name.String = n);
            }
        }

        // Quantité
        public double Storage_quantity
        {
            get => product_Storage_Location.Storage_quantity.Float64;
            set
            {
                SetProperty(product_Storage_Location.Storage_quantity.Float64, value, product_Storage_Location, (u, n) => u.Storage_quantity.Float64 = n);
            }
        }

        // Unité 
        public string Unit_quantity
        {
            get => product_Storage_Location.Unit_quantity.Unit_label.String;
            set
            {
                SetProperty(product_Storage_Location.Unit_quantity.Unit_label.String, value, product_Storage_Location, (u, n) => u.Unit_quantity.Unit_label.String = n);
            }
        }


        // Date d'ouverture
        public string Storage_openingdate { get => product_Storage_Location.Storage_openingdate.Time; }

        // Date d'expiration
        public string Storage_expirationdate {  get => product_Storage_Location.Storage_expirationdate.Time; }


        public override string ToString()
        {
            return product.ToString();
        }
    }

}
