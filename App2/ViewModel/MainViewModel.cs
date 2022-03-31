using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using App2.BaseClasses;
using App2.Tools;
using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Media.Imaging;

namespace App2.ViewModel
{
    public class MainViewModel : NewObservableObject
    {

        private BitmapImage _background;

        public BitmapImage Background
        {
            get { return _background; }
            set { _background = value; OnPropertyChanged(); }
        }

        public Model.ImageLoader ImageLoaderInstance;

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value; OnPropertyChanged(); }
        }
        
        public MainWindow MainWindowInstance { get; set; }
        public HomeViewModel HomeViewModelInstance { get; set; }
        public SecondViewModel SecondViewModelInstance { get; set; }

        // Commands:
        public ButtonCommand HomeViewCommand { get; set; }
        public ButtonCommand SecondViewCommand { get; set; }

        private DispatcherQueue _dispatcher = DispatcherQueue.GetForCurrentThread();

        public MainViewModel()
        {

            HomeViewModelInstance = new HomeViewModel();
            SecondViewModelInstance = new SecondViewModel();

            ImageLoaderInstance = new Model.ImageLoader(HomeViewModelInstance, SecondViewModelInstance);
            
            Background = ImageLoaderInstance[0];
            CurrentView = HomeViewModelInstance.ViewInstance;

            HomeViewCommand = new ButtonCommand(async () => await ChangeView(HomeViewModelInstance));
            SecondViewCommand = new ButtonCommand(async() => await ChangeView(SecondViewModelInstance));

            MainWindowInstance = new MainWindow();
            MainWindowInstance.ViewModel = this;
            MainWindowInstance.Activate();
        }

        private async Task ChangeView(ViewModelBase viewModel)
        {
            if (viewModel.ViewInstance == null) return;
            if (viewModel.ViewInstance == (Page)CurrentView) return;
            await Task.Run(async () =>
            {
                
                MainWindowInstance.DispatcherQueue.TryEnqueue(() =>
                {
                    EventHandler<object> eventHandler = null;
                    eventHandler = (s, e) =>
                    {
                        CurrentView = viewModel.ViewInstance;
                        MainWindowInstance.FrameInAnimation.Begin();
                        MainWindowInstance.FrameOutAnimation.Completed -= eventHandler;
                    };
                    MainWindowInstance.FrameOutAnimation.Completed += eventHandler;
                    MainWindowInstance.FrameOutAnimation.Begin();
                });
                await Task.Delay(100);
                BackgroundAnimation(ImageLoaderInstance[viewModel.CustomBackgroundIndex]);
            });
        }



        public void BackgroundAnimation(BitmapImage newBackground)
        {
            _dispatcher.TryEnqueue(() =>
            {
                EventHandler<object> internalAction = null;
                internalAction = (s, e) =>
                {
                    Background = newBackground;
                    MainWindowInstance.BackgroundInAnimation.Begin();
                    MainWindowInstance.BackgroundOutAnimation.Completed -= internalAction;
                };
                MainWindowInstance.BackgroundOutAnimation.Completed += internalAction;
                MainWindowInstance.BackgroundOutAnimation.Begin();
            });
        }
    }
}
