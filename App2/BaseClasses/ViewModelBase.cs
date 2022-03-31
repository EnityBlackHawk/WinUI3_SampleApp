using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App2.BaseClasses
{
    public abstract class ViewModelBase : App2.Tools.NewObservableObject
    {
        public abstract Page ViewInstance { get; set; }
        public virtual string CustomBackgroundPath { get; set; }
        public virtual int CustomBackgroundIndex { get; private set; }

        public virtual void RegisterBackgroundIndex(int index)
        {
            CustomBackgroundIndex = index;
        }
    }
}
