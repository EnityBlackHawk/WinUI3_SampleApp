using Microsoft.UI.Xaml.Media.Imaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.BaseClasses;

namespace App2.Model
{
    /// <summary>
    /// Load all the imagens used by the project
    /// </summary>
    public class ImageLoader
    {
        private List<BitmapImage> _list;

        /// <summary>
        /// Receves an array of paths
        /// </summary>
        /// <param name="paths">string path</param>
        public ImageLoader(params string[] paths)
        {
            _list = new List<BitmapImage>();
            foreach(string p in paths)
            {
                _list.Add(new BitmapImage(new Uri(p)));
            }
        }
        /// <summary>
        /// Receves an array of ViewModelBase and associates the index of the image
        /// </summary>
        /// <param name="viewModel">ViewModelBase abstract class</param>
        public ImageLoader(params ViewModelBase[] viewModel)
        {
            _list = new List<BitmapImage>();
            foreach(var x in viewModel)
            {
                if(x.CustomBackgroundPath != null)
                {
                    _list.Add(new BitmapImage(new Uri(x.CustomBackgroundPath)));
                    x.RegisterBackgroundIndex(_list.Count - 1);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="index">Index of the target image</param>
        /// <returns>The BitmapImage</returns>
        public BitmapImage this[int index]
        {
            get { return _list[index]; }
        }
        /// <summary>
        /// Add a BitmapImage in the current instance
        /// </summary>
        /// <param name="paths">string path</param>
        public void Add(params string[] paths)
        {
            foreach (string p in paths)
            {
                _list.Add(new BitmapImage(new Uri(p)));
            }
        }
        /// <summary>
        /// Add a BitmapImage in the current instance and associate the index of the image
        /// </summary>
        /// <param name="viewModel">A ViewModelBase abstract class</param>
        public void Add(params ViewModelBase[] viewModel)
        {
            foreach (var x in viewModel)
            {
                if (x.CustomBackgroundPath != null)
                {
                    _list.Add(new BitmapImage(new Uri(x.CustomBackgroundPath)));
                    x.RegisterBackgroundIndex(_list.Count - 1);
                }
            }
        }

    }
}
