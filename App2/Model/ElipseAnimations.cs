using Microsoft.UI.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.Model
{
    public class ElipseAnimations : App2.Tools.NewObservableObject
    {
        private double _rotation1;

        public double Rotation1
        {
            get { return _rotation1; }
            set { _rotation1 = value; OnPropertyChanged(); }
        }

        private double _rotation2;

        public double Rotation2
        {
            get { return _rotation2; }
            set { _rotation2 = value; OnPropertyChanged(); }
        }

        private double _rotation3;

        public double Rotation3
        {
            get { return _rotation3; }
            set { _rotation3 = value; OnPropertyChanged(); }
        }

        private DispatcherTimer _timer;

        public ElipseAnimations()
        {

            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0, 0, 0, 0, 1);

            Rotation1 = 1;
            Rotation2 = 90;
            Rotation3 = 180;

            _timer.Tick += _timer_Elapsed;
            _timer.Start();

        }

        private void _timer_Elapsed(object sender, object e)
        {

            Rotation1 = Rotation1 >= 360 ? 1 : Rotation1 + 3;
            Rotation2 = Rotation2 >= 360 ? 1 : Rotation2 + 3;
            Rotation3 = Rotation3 >= 360 ? 1 : Rotation3 + 3;

        }
    }
}
