using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class HomeViewModel : BaseClasses.ViewModelBase
    {
        public override string CustomBackgroundPath { get; set; }

        public HomeViewModel()
        {
            ViewInstance = new View.HomeView();
            CustomBackgroundPath = "ms-appx:///Assets/Images/b1.jpg";
        }
        public override Page ViewInstance { get; set; }
    }
}
