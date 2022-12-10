using Chimitheque_Mobile_App.ViewModel;
using ZXing;

namespace Chimitheque_Mobile_App.View;

public partial class AjoutProduits : ContentPage
{
	public AjoutProduits()
	{
		InitializeComponent();

		BindingContext =new StoragesViewModel();
	}

    public void barcodeGenerator_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
        ((StoragesViewModel)BindingContext).QrCodeDetectedCommand(e.Results.FirstOrDefault().Value);
    }

    

    private  void Quit_Pressed(object sender, EventArgs e)
    {
        
         Navigation.PopAsync();
    }
}