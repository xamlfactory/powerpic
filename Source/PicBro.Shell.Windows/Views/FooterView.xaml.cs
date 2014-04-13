using System.Windows.Controls;
using PicBro.Shell.Windows.ViewModels;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for FooterView.xaml
    /// </summary>
    public partial class FooterView : UserControl
    {
        public FooterView()
        {
            InitializeComponent();
        }

        public FooterView(FooterViewModel viewmodel)
            : this()
        {
            this.DataContext = viewmodel;
        }

        private void FooterImageListBox_Drop(object sender, System.Windows.DragEventArgs e)
        {

        }
    }
}
