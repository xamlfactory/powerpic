using PicBro.DataModel.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Commands;
using PicBro.DAL.Windows;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows;

namespace PicBro.Shell.Windows.ViewModels
{
    public class ManageTagsViewModel : ViewModelBase
    {
        private int max = 10;

        private readonly IDataServiceProxy dataService;

        private ObservableCollection<ManageTagsModel> tags;

        public ObservableCollection<ManageTagsModel> Tags
        {
            get { return tags; }
            set { tags = value; RaisePropertyChanged("Tags"); }
        }

        private ManageTagsModel selectedTag;

        public ManageTagsModel SelectedTag
        {
            get { return selectedTag; }
            set { selectedTag = value; RaisePropertyChanged("SelectedTag"); }
        }


        private string searchText;

        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; RaisePropertyChanged("SearchText"); }
        }

        public DelegateCommand DeleteCommand
        {
            get
            {
                return new DelegateCommand(this.OnDelete);
            }
        }

        public ManageTagsViewModel(IDataServiceProxy dataservice)
        {
            this.dataService = dataservice;
            this.PropertyChanged += ManageTagsViewModel_PropertyChanged;
        }

        async void ManageTagsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName == "SearchText")
            {
                if (!String.IsNullOrEmpty(SearchText))
                {
                    var tags = this.dataService.SearchTag(this.SearchText);
                    this.Tags = new ObservableCollection<ManageTagsModel>(tags.Result.OrderByDescending(tag => tag.Images));
                }
                else
                {
                    await InitializeTags();
                }
            }
        }

        private async void OnDelete()
        {
            var result = MessageBox.Show("Are you sure to delete the Selected Tag?", "Delete Tag", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                bool isSuccess = await this.dataService.RemoveTag(this.SelectedTag.Tag);
                if (isSuccess)
                {
                    this.Tags.Remove(this.Tags.FirstOrDefault(tag => tag.Tag == this.SelectedTag.Tag));
                }
            }
        }

        public override bool IsNavigationTarget(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            
        }

        public override async void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            await InitializeTags();
        }

        private async Task InitializeTags()
        {
            this.Tags = new ObservableCollection<ManageTagsModel>();
            var tags = await this.dataService.GetTags(this.Tags.Count, max);
            this.Tags = new ObservableCollection<ManageTagsModel>(tags.OrderByDescending(tag => tag.Images));
        }


        internal async void RequestTags()
        {
            var tags = await this.dataService.GetTags(this.Tags.Count, max);
            foreach (var tag in tags)
            {
                this.Tags.Add(tag);
            }
        }
    }
}
