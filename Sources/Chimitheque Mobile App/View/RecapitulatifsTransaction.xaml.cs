using System.Collections;
using System.ComponentModel;
using ChimithequeLib.Models.Storage;
using Newtonsoft.Json;

namespace Chimitheque_Mobile_App.View;


public partial class RecapitulatifsTransaction : ContentPage, IQueryAttributable, INotifyPropertyChanged
{
	public IDictionary<Product_Storage_Location, double> Donnes { set; get; }  

    public RecapitulatifsTransaction(IDictionary<Product_Storage_Location, double> choixProduits)
	{

         Donnes = choixProduits;

		Console.WriteLine(choixProduits.Keys);


		InitializeComponent();
		BindingContext = this;

	}

    public RecapitulatifsTransaction()
    {
        InitializeComponent();
        BindingContext = this;
    }

    
    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        
        Donnes = query["Donnes"] as Dictionary<Product_Storage_Location, double>;

        OnPropertyChanged(nameof(Donnes));
    }
}

 