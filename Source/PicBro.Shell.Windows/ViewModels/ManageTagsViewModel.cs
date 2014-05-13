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
using PicBro.Foundation.Windows.Infrastructure;
using Microsoft.Practices.Prism.Events;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Events;
using System.Windows.Controls;
using System.ComponentModel;

namespace PicBro.Shell.Windows.ViewModels
{
    public class ManageTagsViewModel : ViewModelBase
    {
        private int max = 10;
        private int sortOption = 0;
        private bool isFiltered = false;
        private string sortColumn = "images";
        
        private readonly IDataServiceProxy dataService;
        private readonly IEventAggregator eventAggregator;
        private readonly INavigationService navigationService;
        private readonly IThreadService threadService;

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

        public DelegateCommand TagSearchCommand
        {
            get
            {
                return new DelegateCommand(this.OnTagSearch);
            }
        }


        public DelegateCommand CloseCommand
        {
            get
            {
                return new DelegateCommand(this.OnCloseCommand);
            }
        }

        public DelegateCommand<object> SortCommand
        {
            get
            {
                return new DelegateCommand<Object>(this.OnSorting);
            }
        }

       

        private void OnSorting(object obj)
        {
            var e = obj as DataGridSortingEventArgs;
            if (e != null)
            {
                this.Tags.Clear();
                ObservableCollection<ManageTagsModel> tagsModel;
                sortColumn = e.Column.SortMemberPath.ToLower();
                if (e.Column.SortDirection == null || e.Column.SortDirection == ListSortDirection.Descending)
                {
                    sortOption = 1;
                }
                else
                {
                    sortOption = 0;
                }
                tagsModel = isFiltered ? this.dataService.SearchTag(this.SearchText, this.tags.Count, max, sortOption, sortColumn).Result : this.dataService.GetTags(this.Tags.Count, max, sortOption, sortColumn).Result;
                foreach (var item in tagsModel)
                {
                    this.Tags.Add(item);
                }
            }
        }
        private void OnCloseCommand()
        {
            this.eventAggregator.GetEvent<CloseWindowEvent>().Publish(null);
        }

        private void OnTagSearch()
        {         
            if (this.SelectedTag != null)
            {
                var messageBoxResult = MessageBox.Show("Do you want to view all images with the tag " + this.SelectedTag.Tag.Trim() + "?", "Show Images", MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    if (!string.IsNullOrEmpty(this.SelectedTag.Tag.Trim()))
                    {
                        this.threadService.DoBackgroundWork(async (o, e) =>
                        {
                            e.Result = await this.dataService.GetAllImages(this.SelectedTag.Tag.Trim(), Properties.Settings.Default.IsTagSearchEnabled, Properties.Settings.Default.IsDescriptionSearchEnabled, Properties.Settings.Default.IsFavoritesOnly);
                        },
                        (o, e) =>
                        {
                            SessionService<string>.Save(Constants.ReloadSelectedFolderContent, true);
                            this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.ImageHeaderView);
                            this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.SearchDetailView);
                            this.navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.ImageListView);
                            List<ImageModel> list = e.Result as List<ImageModel>;
                            this.eventAggregator.GetEvent<SearchEvent>().Publish(list);
                        });
                    }
                    this.eventAggregator.GetEvent<CloseWindowEvent>().Publish(null);
                }               
            }
            
        }


        public DelegateCommand DeleteCommand
        {
            get
            {
                return new DelegateCommand(this.OnDelete);
            }
        }

        public ManageTagsViewModel(IDataServiceProxy dataservice, IThreadService threadservice, IEventAggregator eventaggregator, INavigationService navigationservice)
        {
            this.dataService = dataservice;
            this.navigationService = navigationservice;
            this.threadService = threadservice;
            this.eventAggregator = eventaggregator;
            this.PropertyChanged += ManageTagsViewModel_PropertyChanged;
        }

        async void ManageTagsViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SearchText")
            {
                if (!String.IsNullOrEmpty(SearchText))
                {
                    this.isFiltered = true;
                    var tags = this.dataService.SearchTag(this.SearchText, 0, max, this.sortOption, sortColumn);
                    this.Tags = new ObservableCollection<ManageTagsModel>(tags.Result.OrderByDescending(tag => tag.Images));
                }
                else
                {
                    this.isFiltered = false;
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
            var tags = await this.dataService.GetTags(this.Tags.Count, max, sortOption, sortColumn);
            this.Tags = tags;
        }


        internal async void RequestTags()
        {
            ObservableCollection<ManageTagsModel> tags;
            if (isFiltered)
            {
                tags = await this.dataService.SearchTag(this.SearchText, this.Tags.Count, max, sortOption, sortColumn);
            }
            else
            {
                tags = await this.dataService.GetTags(this.Tags.Count, max, sortOption, sortColumn);
            }

            foreach (var tag in tags)
            {
                this.Tags.Add(tag);
            }
        }


    }
}
