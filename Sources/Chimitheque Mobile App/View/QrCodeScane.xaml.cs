namespace Chimitheque_Mobile_App.View;

public partial class QrCodeScane : ContentPage
{
	public QrCodeScane()
	{
		InitializeComponent();
        label.Text = Preferences.Get("token", "");
    }
}