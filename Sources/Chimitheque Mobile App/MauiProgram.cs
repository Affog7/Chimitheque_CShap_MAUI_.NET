using Chimitheque_Mobile_App.View;
using Chimitheque_Mobile_App.ViewModel;

namespace Chimitheque_Mobile_App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Acme-Regular.ttf", "AcmeRegular");
                });
            builder.Services.AddSingleton<AuthenticationView>();
            builder.Services.AddSingleton<AuthentificationViewModel>();

            return builder.Build();
        }
    }
}