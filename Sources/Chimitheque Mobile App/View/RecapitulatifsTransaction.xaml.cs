using ChimithequeLib.Model.Storage;

namespace Chimitheque_Mobile_App.View;

public partial class RecapitulatifsTransaction : ContentPage
{
	public IDictionary<Product_Storage_Location, double> data { set; get; }
	public IList<Product_Storage_Location> Produits { get; set; }
    public RecapitulatifsTransaction(IDictionary<Product_Storage_Location, double> choixProduits, System.Collections.ObjectModel.ObservableCollection<Product_Storage_Location> produits)
	{
	//	Console.Write(choixProduits);
		Produits =  choixProduits.Keys.ToList<Product_Storage_Location>();
		data = choixProduits;

		//Console.WriteLine(choixProduits.Keys);

	//	Console.WriteLine(choixProduits.First().Key);
		InitializeComponent();
		BindingContext = this;

	}
}