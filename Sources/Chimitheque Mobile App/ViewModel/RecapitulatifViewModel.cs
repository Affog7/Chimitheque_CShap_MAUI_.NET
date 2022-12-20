using System.Linq;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Chimitheque_Mobile_App.View.Utils;

namespace Chimitheque_Mobile_App.ViewModel;

public partial class RecapitulatifViewModel : ObservableObject, IQueryAttributable
{
    public IDictionary<Product_Storage_LocationViewModel, double> Donnes { set; get; }

    public bool IsConnected { set; get; }

    Product_Storage_LocationManager locationManager = new Product_Storage_LocationManager();

    public RecapitulatifViewModel()
    {
        IsConnected = Preferences.Get("isConnected", false);

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Donnes = query["Donnes"] as Dictionary<Product_Storage_LocationViewModel, double>;

        OnPropertyChanged(nameof(Donnes));
    }

    [RelayCommand]
    async void ValiderTransaction()
    {
        await this.ValiderTransAsync();

    }

    public async Task ValiderTransAsync()
    {
        if (IsConnected)
        {
            List<Product_Storage_LocationViewModel> transactions = new List<Product_Storage_LocationViewModel>();
            foreach (var s in Donnes)
            {
                s.Key.Storage_quantity = s.Key.Storage_quantity - s.Value;
                transactions.Add(s.Key);
            }

            // Reste EF

            var auth = App.auth.service.httpClient;
            var IsUpadate = locationManager.PutStorageLocation(transactions, auth);

            if (IsUpadate)
            {
                bool answer = await Message.MessageIsContinueTransactionAsync();
                if (answer)
                {
                    Shell.Current.GoToAsync("../../");
                }
                else
                {
                    Application.Current.MainPage = new View.FlyoutView();
                }
            }
        }
        else
        {
            // A Continuer
            bool answer = await Message.MessageIsContinueTransactionOfflineAsync();
            if (answer)
            {
                Shell.Current.GoToAsync("../../");
            }
            else
            {
                Application.Current.MainPage = new View.FlyoutView();
            }
        }
    }
}

