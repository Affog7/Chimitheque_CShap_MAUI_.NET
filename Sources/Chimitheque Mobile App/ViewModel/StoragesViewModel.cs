using Chimitheque_Mobile_App.APisManagers;
using Chimitheque_Mobile_App.View;
using Chimitheque_Mobile_App.View.UC;
using Chimitheque_Mobile_App.View.Utils;
using ChimithequeLib;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Label = ChimithequeLib.Models.Storage.Label;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class StoragesViewModel : INotifyPropertyChanged
    {
        public Product_Storage_LocationManager manager;

        public ObservableCollection<Product_Storage_LocationViewModel> Produits { private set; get; } = new ObservableCollection<Product_Storage_LocationViewModel>();

        public IDictionary<Product_Storage_LocationViewModel, double> ChoixProduits = new Dictionary<Product_Storage_LocationViewModel, double>();

        public bool IsConnected { set; get; }

        HttpClient httpClient;

        public event PropertyChangedEventHandler PropertyChanged;
        AuthService authService = new AuthService();

        public StoragesViewModel()
        {

            manager = new Product_Storage_LocationManager();
            httpClient = App.auth.service.httpClient;

            IsConnected = Preferences.Get("isConnected", false);

            // Test
          /*  QrCodeDetectedCommand("1");*/
           QrCodeDetectedOfflineCommand("9");
               QrCodeDetectedOfflineCommand("13");
               QrCodeDetectedOfflineCommand("13");
           
        }


        public async void QrCodeDetectedCommand(string value)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(value) && double.Parse(value.ToString()) > 0)
                {
                    var data = manager.GetStorageLocationById(int.Parse(value), httpClient);

                    if (data != null && IsNotContent(data))
                    {
                        Produits.Add(data);

                        ChoixProduits.Add(data, 0);

                        await QuantityProduct(data);

                    }
                    else
                    {
                        await Message.MessageProduitExist();
                    }

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Produits"));

                }

            }
            catch (Exception)
            {
                await Message.MessageScanIncorrect();
            }
        }

        private bool IsNotContent(Product_Storage_LocationViewModel location)
        {
            bool result = true;
            foreach (var e in Produits)
            {
                if (location.Storage_id == e.Storage_id) result = false;
            }
            if (Produits.Contains(location) || !result) return false;
            return true;
        }

        [RelayCommand]
        async Task RemoveProduct(Product_Storage_LocationViewModel product)
        {
            Produits.Remove(product);
            ChoixProduits.Remove(product);
            // Console.WriteLine(product);
        }


        public void QuantityProduct(Product_Storage_LocationViewModel product, double qte)
        {
            ChoixProduits[product] = qte;
        }


        [RelayCommand]
        async Task QuantityProduct(Product_Storage_LocationViewModel data)
        {
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                await MauiPopup.PopupAction.DisplayPopup(new PopupProductQuantity(this, data, ChoixProduits[data]));
            });
        }

        [RelayCommand]
        async Task RecapTransaction()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Donnes",   ChoixProduits }
            };

            await Shell.Current.GoToAsync($"{nameof(RecapitulatifsTransaction)}", navigationParameter);

        }



        public async void QrCodeDetectedOfflineCommand(string value)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(value) && double.Parse(value.ToString()) > 0)
                {
                    var data = new Product_Storage_LocationViewModel(new Product_Storage_Location
                    {
                        Product = new ChimithequeLib.Models.Product { Name = new ChimithequeLib.Model.Product_Name { Name_label = $"PRODUCT-{Produits.Count}" } },
                        Storage_id = new Storage_Id { Int64 = int.Parse(value.ToString()), },
                        Storage_quantity = new Storage_quantity { Float64 = 0 },
                        Unit_quantity = new Unit_quantity { Unit_label = new Label { String = "" } },
                        Storelocation = new StoreLocation { StoreLocation_name = new StoreLocation_Name { String = ""} }
                        

                    });

                    if (IsNotContent(data))
                    {

                        Produits.Add(data);

                        ChoixProduits.Add(data, 0);

                        await QuantityProduct(data);

                    }
                    else
                    {
                        await Message.MessageProduitExist();
                    }

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Produits"));

                }

            }
            catch (Exception)
            {
                await Message.MessageScanIncorrect();
            }
        }


    }
}
