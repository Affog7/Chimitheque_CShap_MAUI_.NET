using ChimithequeLib.Model.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class StockDetailViewModel:ObservableObject,IQueryAttributable
    {
        [ObservableProperty]
        private string imagePath1="down.svg", imagePath2 = "down.svg", imagePath3 = "up.svg";

        [ObservableProperty]
        private int quantity;

        [ObservableProperty]
        string productName="Produit",productLocation,productLot,productCapacite;

        [ObservableProperty]
        private int productId;

        [ObservableProperty]
        private bool isExpanded1, isExpanded2, isExpanded3=true;

        [RelayCommand]
        void ChangeImage()
        {
            ImagePath1= Change(IsExpanded1);
            ImagePath2 = Change(IsExpanded2);
            ImagePath3 = Change(IsExpanded3);
        }
        
        string Change(bool _isExpand)
        {
            if (_isExpand)
                return  "up.svg";
            else
                return  "down.svg";
        }

        [RelayCommand]
        void SetQuantity(string value)
        {
            if (value.Contains('-'))
            {
                if (Quantity > 0)
                    Quantity -= int.Parse(value.Remove(0, 1));
                if (Quantity < 0)
                    Quantity = 0;
            }
            else
            {
                Quantity += int.Parse(value.Remove(0, 1));
            }

        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var ProductStorageLocation = query["Product"] as Product_Storage_Location;
            ProductName = ProductStorageLocation.Product.Name.Name_label;
            ProductId = ProductStorageLocation.Product.Product_id;
            ProductLocation = ProductStorageLocation.Storelocation.StoreLocation_name.String;
            //ajout du lot

            ProductCapacite = ProductStorageLocation.Storage_quantity.Float64+ ProductStorageLocation.Unit_quantity.Unit_label.String;

        }
    }
}
