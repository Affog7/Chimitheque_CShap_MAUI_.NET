using ChimithequeLib.Models.Storage;

namespace Chimitheque_Mobile_App.View;

[QueryProperty(nameof(Donnes), "donnes")]
public partial class RecapitulatifsTransaction : ContentPage
{
	public IDictionary<Product_Storage_Location, double> Donnes { set; get; }  

    public RecapitulatifsTransaction(IDictionary<Product_Storage_Location, double> choixProduits)
	{
	//	Console.Write(choixProduits);
         Donnes = choixProduits;

		Console.WriteLine(choixProduits.Keys);

	//	Console.WriteLine(choixProduits.First().Key);
		InitializeComponent();
		BindingContext = this;

	}

    public RecapitulatifsTransaction()
    {
    }
}