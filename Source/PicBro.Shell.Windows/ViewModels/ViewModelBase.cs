namespace PicBro.Shell.Windows.ViewModels
{
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Prism.ViewModel;
    using PicBro.Foundation.Windows.Infrastructure;
    using PicBro.Shell.Windows.Common;
    using PicBro.Shell.Windows.Events;
    public abstract class ViewModelBase : NotificationObject, INavigationAware
    {
        private DelegateCommand escapeCommand;
        private DelegateCommand focusSearchCommand;
        private DelegateCommand<object> oemCommand;
        private DelegateCommand folderExplorerSelectionCommand;
        protected IEventAggregator eventAggregator;
        protected INavigationService navigationService;
        protected IDialogService dialogService;
        protected IThreadService threadService;

        public DelegateCommand FolderExplorerSelectionCommand
        {
            get { return this.folderExplorerSelectionCommand ;}
            private set { this.folderExplorerSelectionCommand = value;}
        }
        public DelegateCommand FocusSearchCommand
        {
            get { return focusSearchCommand; }
            private set { focusSearchCommand = value; }
        }
        public DelegateCommand EscapeCommand
        {
            get { return this.escapeCommand; }
            private set { this.escapeCommand = value; }
        }

        public virtual DelegateCommand<object> OEMCommand
        {
            get { return this.oemCommand; }
            set { this.oemCommand = value; }
        }

        public ViewModelBase() : this(null, null) { }

        public ViewModelBase(
            IEventAggregator eventAggregator,
            INavigationService navigationService)
            : this(eventAggregator, navigationService, null) { }

        public ViewModelBase(
            IEventAggregator eventAggregator,
            INavigationService navigationService,
            IDialogService dialogService)
            : this(eventAggregator, navigationService, dialogService, null) { }

        public ViewModelBase(
            IEventAggregator eventAggregator,
            INavigationService navigationService,
            IDialogService dialogService,
            IThreadService threadService)
        {
            this.eventAggregator = eventAggregator;
            this.navigationService = navigationService;
            this.dialogService = dialogService;
            this.threadService = threadService;
            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            this.EscapeCommand = new DelegateCommand(OnEscapeCommandExecuted);
            this.OEMCommand = new DelegateCommand<object>(this.OnOEMCommandReceivedExecuted);
            this.FocusSearchCommand = new DelegateCommand(this.OnFocusSearchCommand);
            this.FolderExplorerSelectionCommand = new DelegateCommand(this.OnFolderExplorerSelectionCommandExecute);
        }

        private void OnFolderExplorerSelectionCommandExecute()
        {
            this.eventAggregator.GetEvent<FolderExplorerSelectionEvent>().Publish(null);
        }
        private void OnFocusSearchCommand()
        {
            this.eventAggregator.GetEvent<FocusSearchEvent>().Publish(null);
        }
        private void OnOEMCommandReceivedExecuted(object obj)
        {
            this.eventAggregator.GetEvent<OEMCommandEvent>().Publish(obj);
        }
        public virtual void OnEscapeCommandExecuted()
        {           
            this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.FolderListView);
            this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.MenuBarView);
            this.navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.ImageListView);           
        }
        public abstract bool IsNavigationTarget(NavigationContext navigationContext);
        public abstract void OnNavigatedFrom(NavigationContext navigationContext);
        public abstract void OnNavigatedTo(NavigationContext navigationContext);
    }
}
