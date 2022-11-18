namespace Chimitheque_Mobile_App.View;

public partial class AuthenticationView : ContentPage
{
	public AuthenticationView()
	{
		InitializeComponent();
	}

	private void txtEmail_Completed(object sender, EventArgs e)
	{
		txtPassword.Focus();
	}
}