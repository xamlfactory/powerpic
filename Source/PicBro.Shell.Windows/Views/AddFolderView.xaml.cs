namespace PicBro.Shell.Windows.Views
{
    using PicBro.Shell.Windows.ViewModels;
    /// <summary>
    /// Interaction logic for AddFolderView.xaml
    /// </summary>
    public partial class AddFolderView : System.Windows.Controls.UserControl
    {
        public AddFolderView()
        {
            InitializeComponent();
        }

        public AddFolderView(AddFolderViewModel viewModel)
        {
            this.DataContext = viewModel;
        }
    }
}
