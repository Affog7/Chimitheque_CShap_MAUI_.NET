﻿using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
 

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class StockDetailViewModel:ObservableObject,IQueryAttributable
    {
        [ObservableProperty]
        private string imagePath1="down.png", imagePath2 = "down.png", imagePath3 = "up.png";

        [ObservableProperty]
        private int quantity;

        [ObservableProperty]
        string productName="Produit",productLocation,productLot,productCapacite,unit,dateOuverture,datePeremtion;

        [ObservableProperty]
        private int productId;

        public ReadOnlyObservableCollection<ImageSource> Symboles { get; set; }

        [ObservableProperty]
        private ObservableCollection<ImageSource> sourceList = new ObservableCollection<ImageSource>();
        Product_Storage_LocationViewModel ProductStorageLocation = new Product_Storage_LocationViewModel();

        [ObservableProperty]
        private bool isExpanded1, isExpanded2, isExpanded3=true;

        public StockDetailViewModel()
        {
            Symboles = new ReadOnlyObservableCollection<ImageSource>(SourceList);
        }
        public IDictionary<Product_Storage_LocationViewModel, double> ChoixProduits = new Dictionary<Product_Storage_LocationViewModel, double>();

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
                return  "up.png";
            else
                return  "down.png";
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
            ProductStorageLocation = query["Product"] as Product_Storage_LocationViewModel;
            ProductName = ProductStorageLocation.Product.Name;
            ProductId = ProductStorageLocation.Product.Product_id;
            ProductLocation = ProductStorageLocation.Storelocation;
            //ajout du lot
            Unit = ProductStorageLocation.Unit_quantity;
            ProductCapacite = ProductStorageLocation.Storage_quantity + ProductStorageLocation.Unit_quantity;
            //extraire les 8 premiers caractères de la date
            DateOuverture = ProductStorageLocation.Storage_openingdate.Substring(0, 10);
            DatePeremtion = ProductStorageLocation.Storage_expirationdate.Substring(0, 10);
            var data = ProductStorageLocation.Product.Symbols;
            foreach (var item in data)
            {
                SourceList.Add(ConverFromBase64ToImage(item.Symbol_image));
            }
        }

        /// <summary>
        /// Convert Base 64 String to Image
        /// </summary>
        /// <param name="base64"></param>
        /// <returns></returns>
        public ImageSource ConverFromBase64ToImage(string base64)
        {

            var base64Data = Regex.Match(base64, @"data:image/(?<type>.+?),(?<data>.+)").Groups["data"].Value;
            byte[] bytes = Convert.FromBase64String(base64Data);
            ImageSource image;
            MemoryStream ms = new MemoryStream(bytes);
            image = ImageSource.FromStream(()=>ms);
            return image;
        }

        [RelayCommand]
        async void Valider()
        {
            if (ChoixProduits.Count!=0)
            {
                ChoixProduits.Clear();
            }
            ChoixProduits.Add(ProductStorageLocation, Quantity);
            var navigationParameter = new Dictionary<string, object>
            {
                { "Donnes",   ChoixProduits }
            };

            await Shell.Current.GoToAsync($"{nameof(View.RecapitulatifsTransaction)}", navigationParameter);
        }
    }
}
