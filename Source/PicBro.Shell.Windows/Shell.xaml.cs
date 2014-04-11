namespace PicBro.Shell.Windows
{
    using System;
    using System.Windows;
    using MahApps.Metro.Controls;
    using PicBro.Shell.Windows.ViewModels;
    using PicBro.Shell.Windows.Views;
    using PicBro.Shell.Windows.Views.About;
    using PicBro.Shell.Windows.Properties;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Shell : MetroWindow
    {
        public Shell()
        {
            InitializeComponent();
            this.Closing += Shell_Closing;
        }

        void Shell_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.IsLoadingForFirstTime = false;
            Settings.Default.Save();
        }
        public Shell(ShellViewModel viewModel)
            : this()
        {
            this.DataContext = viewModel;
        }
    }
}
