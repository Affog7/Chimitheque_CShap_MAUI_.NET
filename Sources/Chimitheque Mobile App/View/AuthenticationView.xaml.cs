using Chimitheque_Mobile_App.ViewModel;

namespace Chimitheque_Mobile_App.View;

public partial class AuthenticationView : ContentPage
{
    public AuthenticationView(AuthentificationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }

	private void txtEmail_Completed(object sender, EventArgs e)
	{
		txtPassword.Focus();
    }
}