namespace PicBro.Shell.Windows.ViewModels
{
    using System.Windows.Forms;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using PicBro.Foundation.Windows.Infrastructure;
    public sealed class AddFolderViewModel : ViewModelBase
    {
        private string name;
        private string path;
        private double progress;
        private DelegateCommand okCommand;
        private readonly DelegateCommand folderBrowseCommand;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.RaisePropertyChanged(() => this.Name);
            }
        }

        public string Path
        {
            get { return this.path; }
            set
            {
                this.path = value;
                this.RaisePropertyChanged(() => this.Path);
            }
        }
        public double Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                this.RaisePropertyChanged(() => this.Progress);
            }
        }

        public DelegateCommand OKCommand
        {
            get { return this.okCommand; }
            private set { this.okCommand = value; }
        }

        public DelegateCommand FolderBrowseCommand
        {
            get { return this.folderBrowseCommand; }
        }
        public AddFolderViewModel(
            IEventAggregator eventaggregator,
            INavigationService navigationService)
            : base(eventaggregator, navigationService)
        {
            this.eventAggregator = eventaggregator;
            this.navigationService = navigationService;
            this.folderBrowseCommand = new DelegateCommand(this.OnFolderBrowseCommand);
        }

        private void OnFolderBrowseCommand()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                this.Path = dialog.SelectedPath;
            }
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }
    }
}
