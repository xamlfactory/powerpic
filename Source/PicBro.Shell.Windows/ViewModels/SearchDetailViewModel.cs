using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using PicBro.DataModel.Windows;
using PicBro.Shell.Windows.Events;

namespace PicBro.Shell.Windows.ViewModels
{
    public sealed class SearchDetailViewModel : ViewModelBase
    {
        private int resultCount;

        public int ResultCount
        {
            get { return resultCount; }
            set
            {
                this.resultCount = value;
                this.RaisePropertyChanged(() => this.ResultCount);
            }
        }
        public SearchDetailViewModel(IEventAggregator eventaggregator)
            : base(eventaggregator, null)
        {
            this.eventAggregator.GetEvent<SearchEvent>().Subscribe(this.OnSearch);
        }

        private void OnSearch(List<ImageModel> obj)
        {
            if (obj != null)
            {
                ResultCount = obj.Count;
            }
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.eventAggregator.GetEvent<SearchEvent>().Unsubscribe(this.OnSearch);
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.eventAggregator.GetEvent<SearchEvent>().Subscribe(this.OnSearch);
        }
    }
}
