using PicBro.DataModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Shell.Windows.Events
{
    public class ImageFullViewNavigatedEventArgs
    {
        public List<ImageModel> ImageList { get; set; }
    }
}
