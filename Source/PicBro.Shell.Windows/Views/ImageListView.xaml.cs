using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PicBro.Shell.Windows.ViewModels;
using PicBro.Shell.Windows.Properties;
using PicBro.DataModel.Windows;
using System.Windows.Threading;
using System;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for ImageListView.xaml
    /// </summary>
    public partial class ImageListView : UserControl
    {
        private ImageListViewModel viewmodel;

        public ImageListView()
        {
            InitializeComponent();
        }

        public ImageListView(ImageListViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;
            this.viewmodel = viewmodel;
            App.Current.MainWindow.PreviewKeyDown += MainWindow_PreviewKeyDown;
        }

        void MainWindow_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.OemPlus)
                {
                    if (this.viewmodel.ImageTileSize < 75)
                    {
                        ToggleThumbSize(this.viewmodel.ImageTileSize + Settings.Default.SliderIncrement);
                    }
                }

                if (e.Key == Key.OemMinus)
                {
                    if (this.viewmodel.ImageTileSize > 0)
                    {
                        ToggleThumbSize(this.viewmodel.ImageTileSize - Settings.Default.SliderIncrement);
                    }
                }
            }
        }

        private void ToggleThumbSize(int ImageTileSize)
        {
            int value = ImageTileSize / Settings.Default.SliderIncrement;
            ThumbSize thumbSize = default(ThumbSize);

            switch (value)
            {
                case 1:
                    thumbSize = ThumbSize.Small;
                    break;
                case 2:
                    thumbSize = ThumbSize.Medium;
                    break;
                case 3:
                    thumbSize = ThumbSize.Large;
                    break;
                case 4:
                    thumbSize = ThumbSize.ExtraLarge;
                    break;
                default:
                    break;
            }

            foreach (var item in this.viewmodel.Images)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    item.ImageThumbSize = thumbSize;
                }));
            }
        }

        private void Grid_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.list.SelectedItems.Count > 1 && Keyboard.Modifiers == ModifierKeys.None)
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
