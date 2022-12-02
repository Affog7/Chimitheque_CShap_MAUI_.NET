using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chimitheque_Mobile_App.ViewModel
{
    public partial class StockDetailViewModel:ObservableObject
    {
        [ObservableProperty]
        private string imagePath1="down.svg", imagePath2 = "down.svg", imagePath3 = "up.svg";

        [ObservableProperty]
        private bool isExpanded1, isExpanded2, isExpanded3=true;

        [RelayCommand]
        void ChangeImage()
        {
            ImagePath1= Change(IsExpanded1);
            ImagePath2 = Change(IsExpanded2);
            ImagePath3 = Change(IsExpanded3);
        }
        
        string Change(bool _isExpand)
        {
            if (_isExpand)
                return  "up.svg";
            else
                return  "down.svg";
        }
    }
}
