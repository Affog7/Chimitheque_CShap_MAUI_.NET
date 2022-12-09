using Chimitheque_Mobile_App.ViewModel;
using ChimithequeLib.Model;
using ChimithequeLib.Models.Storage;
using MauiPopup.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace Chimitheque_Mobile_App.View.UC;

public partial class PopupProductQuantity : BasePopupPage
{
	public Product_Storage_Location Product { get; }
	public double Unit { get;  }
	public double Choix { get; }

    public PopupProductQuantity(StoragesViewModel page, Product_Storage_Location data, double choix=10)
	{
        Product = data;

		 Unit = data.Storage_quantity.Float64 / 5;

		InitializeComponent();
		BindingContext = page;
        Valeur.Text = choix.ToString();
		Unity.Text = data.Unit_quantity.Unit_label.String ;
        Qt1.Text = (Unit* 1) .ToString();
		Qt2.Text = (Unit* 1.5) .ToString();
		Qt3.Text = (Unit* 2) .ToString();
		Qt4.Text = (Unit* 2.5) .ToString();
		Qt5.Text = (Unit* 3) .ToString();
		Qt6.Text = (Unit* 4) .ToString();

		
    }

    public void Save_Quantity(double qte)
    {
        ((StoragesViewModel)BindingContext).QuantityProduct(Product,qte);

    }

    private void Qt_Pressed(object sender, EventArgs e)
    {
        Button button = (Button)sender;

        Valeur.Text = button.Text ;
        Save_Quantity(double.Parse(Valeur.Text.ToString()));
 
    }

    private void Quit_Button_Clicked(object sender, EventArgs e=null)
    {
        MauiPopup.PopupAction.ClosePopup();
    }
    
    private void Validated_Button_Clicked(object sender, EventArgs e=null)
    {
        Console.Write(Valeur.Text);

        Save_Quantity(double.Parse(Valeur.Text.ToString()));

        Quit_Button_Clicked(sender, e); 
    }



}