using ChimithequeLib.Model.Storage;

namespace Chimitheque_Mobile_App.View.UC;

public partial class ProductDetailsUc : ContentView
{
 
	public ProductDetailsUc()
	{
		InitializeComponent();
	BindingContext = new Product_Storage_Location() ;
	}
	
}