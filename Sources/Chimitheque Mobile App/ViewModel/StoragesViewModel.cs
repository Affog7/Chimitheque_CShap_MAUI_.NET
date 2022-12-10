using Chimitheque_Mobile_App.APisManagers;
using Chimitheque_Mobile_App.View;
using Chimitheque_Mobile_App.View.UC;
using Chimitheque_Mobile_App.View.Utils;
using ChimithequeLib;
using ChimithequeLib.APisManagers; 
using ChimithequeLib.Models.Storage;
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

namespace Chimitheque_Mobile_App.ViewModel
{
   public partial class StoragesViewModel : INotifyPropertyChanged
    {
        public Product_Storage_LocationManager manager =  new();

        public ObservableCollection<Product_Storage_Location> Produits {private set; get; }  = new ObservableCollection<Product_Storage_Location>() ;

        public IDictionary<Product_Storage_Location, double> ChoixProduits = new Dictionary<Product_Storage_Location,double>() ;

        HttpClient httpClient;

        public event PropertyChangedEventHandler PropertyChanged;
        AuthService authService = new AuthService();

        public StoragesViewModel() {

                 manager = new Product_Storage_LocationManager();
            httpClient = App.auth.service.httpClient;

            if (httpClient.DefaultRequestHeaders.Host == null)
            {
                var token = authService.GetTokenAsync("admin@chimitheque.fr", "chimitheque");
                httpClient = authService.httpClient;
            }
            QrCodeDetectedCommand("1");
            QrCodeDetectedCommand("9");

        }


        public async void QrCodeDetectedCommand(string value)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(value) && double.Parse(value.ToString()) > 0)
                {
                    var data  =  manager.GetStorageLocationById(int.Parse(value),httpClient);

                     if(data != null && IsNotContent(data))
                    {
                          Produits.Add(data);
                    
                          ChoixProduits.Add(data,0);

                        await QuantityProduct(data);

                    }
                    else
                    {

                        await Message.MessageProduitExist();
                    }

                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Produits"));

                }
   
            }catch(FormatException e)
            {
                await Message.MessageScanIncorrect();
            }
        }

        private bool IsNotContent(Product_Storage_Location location)
        {
            if (Produits.Contains(location)) return false;
            return true;
        }

        [RelayCommand]
        async Task RemoveProduct(Product_Storage_Location product)
        {
            Produits.Remove(product);
           // Console.WriteLine(product);
        }

     
        public void QuantityProduct(Product_Storage_Location product, double qte)
        {
            ChoixProduits[product] = qte;
        }


        [RelayCommand]
        async Task QuantityProduct(Product_Storage_Location data)
        {
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {
                await MauiPopup.PopupAction.DisplayPopup(new PopupProductQuantity(this,data, ChoixProduits[data]));
            });
        }

        [RelayCommand]
        async  Task  RecapTransaction()
        {
            var navigationParameter = new Dictionary<string, object>
            {
                { "Donnes",   ChoixProduits } 
            };

            await Shell.Current.GoToAsync($"{nameof(RecapitulatifsTransaction)}",navigationParameter);
   
        }
        
    
    }
}
