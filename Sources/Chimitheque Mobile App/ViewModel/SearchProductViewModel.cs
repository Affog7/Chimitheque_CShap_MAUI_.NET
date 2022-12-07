using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Chimitheque_Mobile_App.View;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Model;
using ChimithequeLib.Model.Storage;
using ChimithequeLib.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class SearchProductViewModel : ObservableObject
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

        public ReadOnlyObservableCollection<Product_Storage_Location> Products { get; set; }

        public ProductViewModel productViewModel;
        public Product_Storage_Location_ViewModel product_Storage_Location_ViewModel;

        [ObservableProperty]
        private ObservableCollection<Product_Storage_Location> productList = new ObservableCollection<Product_Storage_Location>();

        public SearchProductViewModel()
        {
            ProductManager = new Product_Storage_LocationManager();

            Products = new ReadOnlyObservableCollection<Product_Storage_Location>(ProductList);
            productViewModel = new ProductViewModel();
            product_Storage_Location_ViewModel = new Product_Storage_Location_ViewModel();
        }

        /// <summary>
        /// I want to search for a product by its name, cas, formula or codebare
        /// </summary>
        [RelayCommand]
        void SearchProduct()
        {

            var token = Preferences.Get("token", null);
            var auth = App.auth.service.httpClient;
            if (string.IsNullOrWhiteSpace(Nom) && string.IsNullOrWhiteSpace(Cas) && string.IsNullOrWhiteSpace(Formula) && string.IsNullOrWhiteSpace(Codebare))
            {
                /* Getting all the products from the server and adding them to the list. */

                ProductList.Clear();
                var result = ProductManager.GetAllStorage(auth).Rows.ToList();
                foreach (var item in result)
                    ProductList.Add(item);
            }
            else if (!string.IsNullOrWhiteSpace(Nom))
            {
                /* Clearing the list and then adding the result of the search to the list. */
                ProductList.Clear();
                var result = ProductManager.GetAllStorage(auth).Rows.Where(x => x.Product.Name.Name_label.Contains(Nom.ToUpper())).ToList();

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
                var result = ProductManager.GetAllStorage(auth).Rows.Where(x => x.Storage_qrcode.Contains(Codebare)).ToList();
                foreach (var item in result)
                    ProductList.Add(item);
            }
            else if (!string.IsNullOrWhiteSpace(Nom) && !string.IsNullOrWhiteSpace(Cas) && !string.IsNullOrWhiteSpace(Formula) && !string.IsNullOrWhiteSpace(Codebare))
            {
                ProductList.Clear();
                var result = ProductManager.GetAllStorage(auth).Rows.Where(x => x.Storage_qrcode.Contains(Codebare)).Where(x => x.Product.Name.Name_label.Contains(Nom)).ToList();
                foreach (var item in result)
                    ProductList.Add(item);
            }
        }

        [RelayCommand]
        async Task Tap(Product_Storage_Location vm)
        {
            var navigationParamater = new Dictionary<string, object>
            {
                {"Product",vm }
            };
            try
            {
                var StockView = new StockDetailView(new StockDetailViewModel());
                await Shell.Current.GoToAsync( $"StockDetailView", navigationParamater);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
