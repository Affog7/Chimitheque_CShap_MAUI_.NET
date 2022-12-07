using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.ViewModel
{
    partial class ProductDetailsUcVM : ObservableObject
    {
        [ObservableProperty]
        private string name;

        public ProductDetailsUcVM()
        {
            name = "jhqbvknl";
        }

    }
}
