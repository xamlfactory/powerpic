using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using PicBro.DAL.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Events;

namespace PicBro.Shell.Windows.ViewModels
{
    public sealed class ImageHeaderViewModel : HeaderViewModel
    {
        private bool enableSearchSort = true;
        private DelegateCommand backCommand;

        public bool EnableSearchSort
        {
            get
            {
                return enableSearchSort;
            }

            set
            {
                enableSearchSort = value;
                this.RaisePropertyChanged(() => this.EnableSearchSort);
            }
        }

        public DelegateCommand BackCommand
        {
            get { return backCommand; }
            private set { backCommand = value; }
        }


        public ImageHeaderViewModel(
            IDialogService dialogservice,
            IDataServiceProxy dataservice,
            IEventAggregator eventaggregator,
            INavigationService navigationservice,
            IThreadService threadservice) :
            base(dialogservice, dataservice, eventaggregator, threadservice, navigationservice)
        {
            this.InitializeCommands();
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<ImageFullViewNavigatedEvent>().Subscribe(FullViewNavigated);
            this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Subscribe(this.OnFolderSelected);
            this.eventAggregator.GetEvent<OEMCommandEvent>().Subscribe(this.OnOEMCommandExecuted);
        }

        private void UnSubscribeEvents()
        {
            this.eventAggregator.GetEvent<ImageFullViewNavigatedEvent>().Unsubscribe(FullViewNavigated);
            this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Unsubscribe(this.OnFolderSelected);
            this.eventAggregator.GetEvent<OEMCommandEvent>().Unsubscribe(this.OnOEMCommandExecuted);
        }

        private void InitializeCommands()
        {
            this.BackCommand = new DelegateCommand(this.OnBack);
        }
        private void FullViewNavigated(ImageFullViewNavigatedEventArgs args)
        {
            EnableSearchSort = false;
        }

        private void OnBack()
        {
            this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.FolderListView);
            this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.MenuBarView);
            this.navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.ImageListView);
            this.SearchText = string.Empty;
            EnableSearchSort = true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.UnSubscribeEvents();
        }
        public async override void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.SubscribeEvents();
            this.SearchText = await Task.FromResult<string>(string.Empty);
        }
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }
    }
}
