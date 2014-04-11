using MahApps.Metro.Controls;
using System;
using System.Windows;
using System.Windows.Input;

namespace PicBro.Shell.Windows.Views.About
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog : MetroWindow
    {
        public AboutDialog()
        {
            InitializeComponent();
            this.Loaded += AboutDialog_Loaded;
            this.Deactivated += AboutDialog_Deactivated;
        }

        void AboutDialog_Deactivated(object sender, EventArgs e)
        {
            if (this.IsLoaded && this.IsVisible)
            {
                App.Current.MainWindow.Activate();
                this.Close();
            }
        }       

        void AboutDialog_Loaded(object sender, RoutedEventArgs e)
        {           
            EventManager.RegisterClassHandler(typeof(AboutDialog), Keyboard.PreviewKeyDownEvent, new KeyEventHandler(OnKeyDown), true);
        }     
        private void OnKeyDown(object sender,KeyEventArgs args)
        {
            if (args.Key == Key.Escape && this.IsLoaded && this.IsActive)
            {
                args.Handled = true;
                this.Close();
            }
        }      

        private void onClose(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
