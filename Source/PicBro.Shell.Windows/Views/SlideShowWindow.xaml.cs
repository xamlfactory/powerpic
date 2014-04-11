using System.Windows;
using PicBro.Shell.Windows.ViewModels;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for SlideShowWindow.xaml
    /// </summary>
    public partial class SlideShowWindow : Window
    {
        public SlideShowWindow()
            : this(null)
        {

        }

        public SlideShowWindow(SlideShowViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
        }
    }
}
