using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.ViewModel
{
    public class MainViewAnimations : Tools.NewObservableObject
    {
        private double _frameOpacity;

        public double FrameOpacity
        {
            get { return _frameOpacity; }
            set { _frameOpacity = value; OnPropertyChanged(); }
        }

        public MainViewAnimations()
        {
            FrameOpacity = 1;
        }
    }
}
