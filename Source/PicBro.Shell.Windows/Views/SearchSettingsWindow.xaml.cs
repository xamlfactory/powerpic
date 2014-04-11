namespace PicBro.Shell.Windows.Views
{
    using System.Windows;
    using System.Windows.Input;
    using MahApps.Metro.Controls;
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SearchSettingsWindow : MetroWindow
    {       
        public SearchSettingsWindow()
        {
            InitializeComponent();
            this.Closing += SearchSettingsWindow_Closing;
            EventManager.RegisterClassHandler(typeof(SearchSettingsWindow), Keyboard.PreviewKeyDownEvent, new KeyEventHandler(OnKeyDown), true);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && this.IsLoaded && this.IsActive)
            {
                e.Handled = true;
                this.Close();
            }
        }

        void SearchSettingsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
