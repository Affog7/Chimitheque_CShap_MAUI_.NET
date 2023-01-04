using Chimitheque_Mobile_App.ViewModel;
using ChimithequeLib.Model;
using ChimithequeLib.Models.Storage;
using ChimithequeLib.ViewModel;
using MauiPopup.Views;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration;
namespace Chimitheque_Mobile_App.View.UC;

public partial class PopupProductQuantity : BasePopupPage
{
	public Product_Storage_LocationViewModel Product { get; }
	public double Unit { get; set; }
	public double Choix { get; }

    public PopupProductQuantity(ViewModel.StoragesViewModel page, Product_Storage_LocationViewModel data, double choix=10)
	{
        Product = data;
        if (data.Storage_quantity / 5 != 0 && data.Storage_quantity > 0)
        {
            Unit = data.Storage_quantity / 5;
        }
        else
        {
            Unit = 2.0;
        }
		InitializeComponent();
		BindingContext = page;
        
        Valeur.Text = choix.ToString();
		Unity.Text = data.Unit_quantity ;
        Qt1.Text = string.Format("{0:0.0}", Unit * 1);
        Qt2.Text = string.Format("{0:0.0}", Unit * 1.5);
        Qt3.Text = string.Format("{0:0.0}", Unit * 2);
        Qt4.Text = string.Format("{0:0.0}", Unit * 2.5);
        Qt5.Text = string.Format("{0:0.0}", Unit * 3);
        Qt6.Text = string.Format("{0:0.0}", Unit * 4);  


     }

    public void Save_Quantity(double qte)
    {
        ((ViewModel.StoragesViewModel)BindingContext).QuantityProduct(Product,qte);

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