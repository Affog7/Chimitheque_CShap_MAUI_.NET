using System.Linq;
using ChimithequeLib.APisManagers;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Chimitheque_Mobile_App.ViewModel;

public partial class RecapitulatifViewModel:ObservableObject, IQueryAttributable
{
    public IDictionary<Product_Storage_LocationViewModel, double> Donnes { set; get; }

    Product_Storage_LocationManager locationManager = new Product_Storage_LocationManager();

    public RecapitulatifViewModel()
    {

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Donnes = query["Donnes"] as Dictionary<Product_Storage_LocationViewModel, double>;

        OnPropertyChanged(nameof(Donnes));
    }

    [RelayCommand]
    async void ValiderTransaction()
    {
        var storagevm = Donnes.First().Key;
        storagevm.Storage_quantity = storagevm.Storage_quantity - Donnes.First().Value;
        
        var auth = App.auth.service.httpClient;
        var IsUpadate=locationManager.PutStorageLocation(storagevm, auth);

        if (IsUpadate)
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("Validation", "Le produit a été recuperr avec succes. Voulez vous Recuperez un autre produits?", "Oui", "Non",FlowDirection.MatchParent);
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

