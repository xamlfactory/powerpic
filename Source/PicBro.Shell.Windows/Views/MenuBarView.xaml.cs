using PicBro.Shell.Windows.ViewModels;
using PicBro.Shell.Windows.Views.About;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MenuBarView.xaml
    /// </summary>
    public partial class MenuBarView : UserControl
    {
        public MenuBarView()
        {
            InitializeComponent();
        }

        public MenuBarView(MenuBarViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;
        }

        private void OnAbout(object sender, RoutedEventArgs e)
        {
            new AboutDialog { Owner = App.Current.MainWindow }.Show();
        }
    }
}
