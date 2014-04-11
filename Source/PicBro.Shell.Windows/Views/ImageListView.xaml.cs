using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PicBro.Shell.Windows.ViewModels;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for ImageListView.xaml
    /// </summary>
    public partial class ImageListView : UserControl
    {
        public ImageListView()
        {
            InitializeComponent();
        }

        public ImageListView(ImageListViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;           
        }
         

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(this.list.SelectedItems.Count > 1  && Keyboard.Modifiers == ModifierKeys.None)
            {
                if (this.list.SelectedItems.Contains((sender as FrameworkElement).DataContext))
                {
                    e.Handled = true;
                }
            }
        }

        private void Grid_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (this.list.SelectedItems.Count > 1 && Keyboard.Modifiers == ModifierKeys.None)
            {
                this.list.SelectedItems.Clear();
                this.list.SelectedItem = (sender as FrameworkElement).DataContext;
            }
        }

        private void ManipulationStarting(object sender, ManipulationStartingEventArgs e)
        {
            e.ManipulationContainer = this;
        }
    }
}
