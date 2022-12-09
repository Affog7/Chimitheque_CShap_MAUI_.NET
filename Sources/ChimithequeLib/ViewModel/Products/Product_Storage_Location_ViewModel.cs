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
    public class Product_Storage_Location_ViewModel:ObservableObject
    {
        private Product_Storage_Location product_Storage_Location;
        private Product product;

        public string Nomm { get; set; } = "tfgyhjk";
        public int Storage_id 
        { 
            get => product_Storage_Location.Storage_id.Int64;
            set
            {
                SetProperty(product_Storage_Location.Storage_id.Int64, value, product_Storage_Location.Storage_id, (u, n) => u.Int64 = n);
            }
        }
        public string Storage_qrcode
        {
            get => product_Storage_Location.Storage_qrcode;
            set
            {
                SetProperty(product_Storage_Location.Storage_qrcode, value, product_Storage_Location, (u, n) => u.Storage_qrcode = n);
            }
         }
        public bool Valid
        {
            get => product_Storage_Location.Valid;
            set
            {
                SetProperty(product_Storage_Location.Valid, value, product_Storage_Location, (u, n) => u.Valid = n);
            }
        }

        public Product Product
        {
            get => product;
            set
            {
                product = value;
            }
        }

        public string Storelocation
        {
            get => product_Storage_Location.Storelocation.StoreLocation_name.String;
            set
            {
                SetProperty(product_Storage_Location.Storelocation.StoreLocation_name.String, value, product_Storage_Location, (u, n) => u.Storelocation.StoreLocation_name.String = n);
            }
        }
        public double Storage_quantity
        {
            get => product_Storage_Location.Storage_quantity.Float64;
            set
            {
                SetProperty(product_Storage_Location.Storage_quantity.Float64, value, product_Storage_Location, (u, n) => u.Storage_quantity.Float64 = n);
            }
        }
        public string Unit_quantity
        {
            get => product_Storage_Location.Unit_quantity.Unit_label.String;
            set
            {
                SetProperty(product_Storage_Location.Unit_quantity.Unit_label.String, value, product_Storage_Location, (u, n) => u.Unit_quantity.Unit_label.String = n);
            }
        }
    }
}
