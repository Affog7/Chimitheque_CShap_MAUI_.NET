namespace Chimitheque_Mobile_App.View;

public partial class FlyoutView : Shell
{
	public FlyoutView()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(MainView), typeof(MainView));
        Routing.RegisterRoute(nameof(SearchProductView), typeof(SearchProductView));
    }
}