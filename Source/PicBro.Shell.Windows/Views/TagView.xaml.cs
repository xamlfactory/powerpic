using PicBro.Shell.Windows.ViewModels;
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
    /// Interaction logic for TagView.xaml
    /// </summary>
    public partial class TagView : UserControl
    {
        public TagView()
        {
            InitializeComponent();
        }

        public TagView(TagViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;
        }

        private void OnEscapeDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                ((Shell)App.Current.MainWindow).mainRegion.Focus();
                e.Handled = true;
            }
        }
    }
}
