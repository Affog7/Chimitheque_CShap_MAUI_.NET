using Chimitheque_Mobile_App.View;
using Chimitheque_Mobile_App.ViewModel;
using CommunityToolkit.Maui;
using ZXing.Net.Maui.Controls;

namespace Chimitheque_Mobile_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>().UseBarcodeReader()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Acme-Regular.ttf", "AcmeRegular");
                });

            builder.UseMauiApp<App>().UseMauiCommunityToolkit();
            builder.Services.AddSingleton<AuthenticationView>();
            builder.Services.AddSingleton<AuthentificationViewModel>();

            builder.Services.AddSingleton<SearchProductView>();
            builder.Services.AddSingleton<MainView>();
            builder.Services.AddSingleton<SearchProductViewModel>();

            builder.Services.AddSingleton<StockDetailView>();
            builder.Services.AddSingleton<StockDetailViewModel>();
            return builder.Build();
        }
    }
}