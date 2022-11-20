using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Model;
using ChimithequeLib.Model.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class SearchProductViewModel:ObservableObject
    {
        public Product_Storage_LocationManager ProductManager { get; set; }
        
        [ObservableProperty]
        private string nom;
        [ObservableProperty]
        string cas;
        [ObservableProperty]
        string formula;
        [ObservableProperty]
        string codebare;
        [ObservableProperty]
        bool isChimique;
        [ObservableProperty]
        bool isBiologique;
        [ObservableProperty]
        bool isConsommable;
        public ReadOnlyObservableCollection<Product> Products { get; set; }

        [ObservableProperty]
        private ObservableCollection<Product> productList = new ObservableCollection<Product>();

        public SearchProductViewModel()
        {
            ProductManager = new Product_Storage_LocationManager();
            Products = new ReadOnlyObservableCollection<Product>(ProductList);
        }

        [RelayCommand]
         void SearchProduct()
        {

            var token = Preferences.Get("token", null);
            var auth = App.auth.service.httpClient;
            if (string.IsNullOrWhiteSpace(Nom) && string.IsNullOrWhiteSpace(Cas) && string.IsNullOrWhiteSpace(Formula) && string.IsNullOrWhiteSpace(Codebare))
            {
                var result = ProductManager.GetAllStorage(auth).Rows.Select(x => x.Product).ToList();
                foreach (var item in result)
                    ProductList.Add(item);
            }
            else if(!string.IsNullOrWhiteSpace(Nom))
            {
                ProductList.Clear();
                var result = ProductManager.GetAllStorage(auth).Rows.Select(x => x.Product).Where(x=>x.Name.Name_label.Contains(Nom.ToUpper())).ToList();

                foreach (var item in result)
                    ProductList.Add(item);
            }
            else if (!string.IsNullOrWhiteSpace(Cas))
            {
                //ProductList = ProductManager.GetAllStorage(httpClient).Rows.Select(x => x.Product).Where(x => x.Cas.Contains(Cas)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Formula))
            {
                //ProductList = ProductManager.GetAllStorage(httpClient).Rows.Select(x => x.Product).Where(x => x.Formula.Contains(formula)).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(Codebare))
            {
                ProductList.Clear();
                var result = ProductManager.GetAllStorage(auth).Rows.Where(x => x.Storage_qrcode.Contains(Codebare)).Select(x => x.Product).ToList();
                foreach (var item in result)
                    ProductList.Add(item);
            }
            else if(!string.IsNullOrWhiteSpace(Nom)&& !string.IsNullOrWhiteSpace(Cas)&& !string.IsNullOrWhiteSpace(Formula)&& !string.IsNullOrWhiteSpace(Codebare))
            {
                var result = ProductManager.GetAllStorage(auth).Rows.Where(x => x.Storage_qrcode.Contains(Codebare)).Select(x => x.Product).Where(x => x.Name.Name_label.Contains(Nom)).ToList();
                foreach (var item in result)
                    ProductList.Add(item);
            }
        }
    }
}
