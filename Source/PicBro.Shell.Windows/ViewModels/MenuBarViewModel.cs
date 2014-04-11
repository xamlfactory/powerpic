//-----------------------------------------------------------------------
// <copyright file="MenuBarViewModel.cs" company="XAML Factory">
//     All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace PicBro.Shell.Windows.ViewModels
{
    using System.IO;
    using System.Threading.Tasks;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;
    using PicBro.DAL.Windows;
    using PicBro.Foundation.Windows.Infrastructure;
    using PicBro.Shell.Windows.Events;

    /// <summary>
    /// MenuBarViewModel class
    /// </summary>
    public class MenuBarViewModel : HeaderViewModel
    {
        /// <summary>
        /// IsFocusSearch variable
        /// </summary>
        private bool isFocusSearch;

        /// <summary>
        /// Gets or sets a value indicating whether IsFocusSearch property is true or false
        /// </summary>
        public bool IsFocusSearch
        {
            get
            {
                return this.isFocusSearch;
            }

            set
            {
                this.isFocusSearch = value;
                this.RaisePropertyChanged(() => this.IsFocusSearch);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuBarViewModel"/> class.
        /// </summary>
        /// <param name="dialogservice">dialog service</param>
        /// <param name="container">container object</param>
        /// <param name="dataservice">data service</param>
        /// <param name="eventaggregator">event aggregator</param>
        /// <param name="navigationservice">navigation service</param>
        /// <param name="threadservice">thread service</param>
        public MenuBarViewModel(
            IDialogService dialogservice,
            IDataServiceProxy dataservice,
            IEventAggregator eventaggregator,
            INavigationService navigationservice,
            IThreadService threadservice) :
            base(dialogservice, dataservice, eventaggregator, threadservice, navigationservice)
        {
            this.SuscribeEvents();
        }

        private void SuscribeEvents()
        {
            this.eventAggregator.GetEvent<FolderDroppedEvent>().Subscribe(this.OnFolderDropped);
            this.eventAggregator.GetEvent<FocusSearchEvent>().Subscribe(this.OnSearchFocus);
            this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Subscribe(this.OnFolderSelected);
            this.eventAggregator.GetEvent<OEMCommandEvent>().Subscribe(this.OnOEMCommandExecuted);
        }

        private void UnSuscribeEvents()
        {
            this.eventAggregator.GetEvent<FolderDroppedEvent>().Unsubscribe(this.OnFolderDropped);
            this.eventAggregator.GetEvent<FocusSearchEvent>().Unsubscribe(this.OnSearchFocus);
            this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Unsubscribe(this.OnFolderSelected);
            this.eventAggregator.GetEvent<OEMCommandEvent>().Unsubscribe(this.OnOEMCommandExecuted);
        }

        /// <summary>
        /// this method used for Navigation from
        /// </summary>
        /// <param name="navigationContext">navigation context</param>
        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.UnSuscribeEvents();
        }

        /// <summary>
        /// this method used to Navigate
        /// </summary>
        /// <param name="navigationContext">navigation context type</param>
        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.SearchText = await Task.FromResult<string>(string.Empty);
            this.SuscribeEvents();
        }

        /// <summary>
        /// This method is used for Navigation target
        /// </summary>
        /// <param name="navigationContext">navigation context type</param>
        /// <returns>boolean type</returns>
        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        /// <summary>
        /// this method used for Folder Drop
        /// </summary>
        /// <param name="args">FolderDropped event args</param>
        private void OnFolderDropped(FolderDroppedEventArgs args)
        {
            if (args.DroppedFolders != null)
            {
                foreach (var folderpath in args.DroppedFolders)
                {
                    if (Directory.Exists(folderpath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(folderpath);
                        this.Scan(directoryInfo.Name, directoryInfo.FullName);
                    }
                }
            }
        }

        /// <summary>
        /// this method used to focus on search
        /// </summary>
        /// <param name="args">boolean type</param>
        private void OnSearchFocus(object args)
        {
            this.IsFocusSearch = true;
        }
    }
}
