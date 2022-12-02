using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.View.Utils
{
    class Message
    {
        private static double DURATION_MESSAGE = 15;

        public static async Task MessageProduitExist()
        {
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {

                var snackbar = Toast.Make("Le produit est déjà ajouté dans la liste", ToastDuration.Long, DURATION_MESSAGE);

                await snackbar.Show(new CancellationTokenSource().Token);
            }
                       );
        }
        
        
        public static async Task MessageScanIncorrect()
        {
            await Application.Current.Dispatcher.DispatchAsync(async () =>
            {

                var snackbar = Toast.Make("Le code produit scanné est incorrect", ToastDuration.Long, DURATION_MESSAGE);

                await snackbar.Show(new CancellationTokenSource().Token);
            }
                       );
        }
    }
}
