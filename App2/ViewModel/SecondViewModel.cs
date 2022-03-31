using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class SecondViewModel : BaseClasses.ViewModelBase
    {
        public SecondViewModel()
        {
            ViewInstance = new View.SecondView();
            CustomBackgroundPath = "ms-appx:///Assets/Images/b2.jpg";
        }

        public override Page ViewInstance { get; set; }
    }
}
