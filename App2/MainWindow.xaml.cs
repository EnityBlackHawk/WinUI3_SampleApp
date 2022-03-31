using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace App2
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public App2.ViewModel.MainViewModel ViewModel { get; set; }

        public Storyboard BackgroundOutAnimation;
        public Storyboard BackgroundInAnimation;

        public Storyboard FrameOutAnimation;
        public Storyboard FrameInAnimation;

        public MainWindow()
        {
            this.InitializeComponent();
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(titleBar);

            BackgroundOutAnimation = cBackgroundImage.Resources["an_out"] as Storyboard;
            BackgroundInAnimation = cBackgroundImage.Resources["an_in"] as Storyboard;

            FrameOutAnimation = cFrame.Resources["an_out"] as Storyboard;
            FrameInAnimation = cFrame.Resources["an_in"] as Storyboard;

        }
    }
}
