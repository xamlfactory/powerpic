using PicBro.Shell.Windows.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for ImageView.xaml
    /// </summary>
    public partial class ImageView : UserControl
    {
        public ImageView()
        {   
            InitializeComponent();
            this.Loaded += ImageView_Loaded;
        }

        void ImageView_Loaded(object sender, RoutedEventArgs e)
        {
            Keyboard.Focus(this);
        }
     
        public ImageView(ImageViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;
        }
        
    }
}
