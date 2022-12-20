using Chimitheque_Mobile_App.ViewModel;
namespace Chimitheque_Mobile_App.View.UC;

public partial class KeyboardUserControl : ContentView
{
	public KeyboardUserControl()
	{
		InitializeComponent();
		plus1.CommandParameter = plus1.Text;
		plus5.CommandParameter = plus5.Text;
		plus10.CommandParameter = plus10.Text;
		moin1.CommandParameter = moin1.Text;
        moin5.CommandParameter = moin5.Text;
        moin10.CommandParameter = moin10.Text;
		List<string> list = new List<string>();
        list.AddRange(new string[] { "g", "mL", "L", "kg" });
        picker.ItemsSource = list;
        var isLogged = Preferences.Get("isConnected", false);
		if (!isLogged)
		{
			picker.IsEnabled = true;
		}
    }
}
