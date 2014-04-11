using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Events;
using PicBro.Shell.Windows.Views.Dialogs;

namespace PicBro.Shell.Windows.ViewModels
{
    public sealed class FolderListViewModel : ViewModelBase
    {
        private readonly IDataServiceProxy dataService;
        private bool isFavoriteDrop;
        private DelegateCommand<object> moveFolderUpCommand;
        private DelegateCommand<object> moveFolderDownCommand;
        private DelegateCommand selectAllCommand;
        private DelegateCommand<FolderModel> contextMenuOpenCommand;
        private DelegateCommand openFolderCommmand;
        private DelegateCommand propertisCommand;
        private DelegateCommand folderSelectedCommand;
        private DelegateCommand<object> dropCommand;
        private DelegateCommand<object> previewDropFavoriteCommand;
        private DelegateCommand<object> deleteCommand;
        private DelegateCommand<object> dropFavoriteCommand;
        private ObservableCollection<FolderModel> folders;
        private FolderModel selectedFolder;
        private ContextMenu contextMenuItems;

        public DelegateCommand<object> MoveFolderDownCommand
        {
            get { return this.moveFolderDownCommand; }
            private set { this.moveFolderDownCommand = value; }
        }
        public DelegateCommand<object> MoveFolderUpCommand
        {
            get { return this.moveFolderUpCommand; }
            private set { this.moveFolderUpCommand = value; }
        }
        public DelegateCommand FolderSelectedCommand
        {
            get { return this.folderSelectedCommand; }
            private set { this.folderSelectedCommand = value; }
        }
        public ObservableCollection<FolderModel> Folders
        {
            get { return folders; }
            set
            {
                folders = value;
                RaisePropertyChanged(() => this.Folders);
            }
        }

        public FolderModel SelectedFolder
        {
            get { return selectedFolder; }
            set
            {
                if (value != null)
                {
                    selectedFolder = value;
                    this.RaisePropertyChanged(() => this.SelectedFolder);
                    this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Publish(this.SelectedFolder.ID);
                }
            }
        }

        public ContextMenu ContextMenuItems
        {
            get { return this.contextMenuItems; }
            set
            {
                this.contextMenuItems = value;
                this.RaisePropertyChanged(() => this.ContextMenuItems);
            }
        }

        public DelegateCommand<object> DropCommand
        {
            get { return dropCommand; }
            private set { dropCommand = value; }
        }

        public DelegateCommand<object> DropFavoriteCommand
        {
            get { return dropFavoriteCommand; }
            private set { dropFavoriteCommand = value; }
        }

        public DelegateCommand<object> PreviewDropFavoriteCommand
        {
            get { return previewDropFavoriteCommand; }
            private set { previewDropFavoriteCommand = value; }
        }

        public DelegateCommand<object> DeleteCommand
        {
            get { return deleteCommand; }
            private set { deleteCommand = value; }
        }

        public DelegateCommand SelectAllCommand
        {
            get { return selectAllCommand; }
            private set { selectAllCommand = value; }
        }
        public DelegateCommand<FolderModel> ContextMenuOpenCommand
        {
            get { return this.contextMenuOpenCommand; }
            private set { this.contextMenuOpenCommand = value; }
        }

        public DelegateCommand OpenFolderCommand
        {
            get { return openFolderCommmand; }
            private set { openFolderCommmand = value; }
        }

        public DelegateCommand PropertiesCommand
        {
            get { return propertisCommand; }
            private set { propertisCommand = value; }
        }

        public FolderListViewModel(
            IDataServiceProxy dataService,
            INavigationService navigationService,
            IEventAggregator eventaggregator)
            : base(eventaggregator, navigationService)
        {
            this.dataService = dataService;
            this.InitializeCommands();
            this.SubscribeEvents();
            this.CreateContextMenuItems(null);
            InitializeData();
            this.SelectedFolder = this.Folders.FirstOrDefault();
        }

        private void InitializeCommands()
        {
            this.DropCommand = new DelegateCommand<object>(this.OnDrop);
            this.DropFavoriteCommand = new DelegateCommand<object>(this.OnDropFavorite);
            this.PreviewDropFavoriteCommand = new DelegateCommand<object>(this.OnPreviewDropFavorite);
            this.DeleteCommand = new DelegateCommand<object>(this.OnDelete);
            this.SelectAllCommand = new DelegateCommand(this.SelectAll);
            this.OpenFolderCommand = new DelegateCommand(this.OpenFolderLocation);
            this.PropertiesCommand = new DelegateCommand(this.OpenProperties);
            this.ContextMenuOpenCommand = new DelegateCommand<FolderModel>(this.OnContextMenuOpenCommandExecuted);
            this.FolderSelectedCommand = new DelegateCommand(this.OnFolderSelectedCommandExecute);
            this.MoveFolderDownCommand = new DelegateCommand<object>(this.OnMoveFolderDownCommandExecute, this.OnMoveFolderDownCommandCanExecute);
            this.MoveFolderUpCommand = new DelegateCommand<object>(this.OnMoveFolderUpCommandExecute, this.OnMoveFolderUpCommandCanExecute);
        }

        private bool OnMoveFolderUpCommandCanExecute(object arg)
        {
            FolderModel folderModel = arg as FolderModel;
            if (folderModel != null && !folderModel.ID.Equals(-1) && this.Folders.IndexOf(folderModel) > 1)
            {
                return true;
            }

            return false;
        }

        private bool OnMoveFolderDownCommandCanExecute(object arg)
        {
            FolderModel folderModel = arg as FolderModel;
            if (folderModel != null && !folderModel.ID.Equals(-1) && this.Folders.IndexOf(folderModel) < this.Folders.Count - 1)
            {
                return true;
            }

            return false;
        }

        private void OnMoveFolderUpCommandExecute(object param)
        {
            FolderModel folderModel = (FolderModel)param;
            int index = this.Folders.IndexOf(folderModel);
            this.Folders.Move(index, --index);
            this.SelectedFolder = folderModel;
            this.dataService.UpdateFolderSortOrderAsync(this.Folders);
        }

        private void OnMoveFolderDownCommandExecute(object param)
        {
            FolderModel folderModel = (FolderModel)param;
            int index = this.Folders.IndexOf(folderModel);
            this.Folders.Move(index, ++index);
            this.SelectedFolder = folderModel;
            this.dataService.UpdateFolderSortOrderAsync(this.Folders);
        }

        private void OnImageScanCompleted(object obj)
        {
            this.SelectedFolder = this.Folders.LastOrDefault();
        }

        private void OnFolderSelectedCommandExecute()
        {
            if (this.SelectedFolder != null)
            {
                this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Publish(SelectedFolder.ID);
            }
        }

        private void OnFolderExplorerSelctionRequestProcess(object obj)
        {
            IRegionManager regionManager = ((NavigationService)navigationService).RegionManager;
            UserControl view = (UserControl)regionManager.Regions[RegionNames.NavigationRegion].ActiveViews.FirstOrDefault();
            ListBox listBox = (ListBox)view.FindName("FolderListBox");
            ListBoxItem listboxItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(listBox.SelectedIndex);
            listboxItem.Focus();
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<FolderAddedEvent>().Subscribe(this.OnFolderAdded);
            this.eventAggregator.GetEvent<FolderRemovedEvent>().Subscribe(this.OnFolderRemoved);
            this.eventAggregator.GetEvent<ImageScanCompletedEvent>().Subscribe(this.OnImageScanCompleted);
            this.eventAggregator.GetEvent<FolderExplorerSelectionEvent>().Subscribe(this.OnFolderExplorerSelctionRequestProcess);
        }

        private void UnSubscribeEvents()
        {
            this.eventAggregator.GetEvent<FolderAddedEvent>().Unsubscribe(this.OnFolderAdded);
            this.eventAggregator.GetEvent<FolderRemovedEvent>().Unsubscribe(this.OnFolderRemoved);
            this.eventAggregator.GetEvent<ImageScanCompletedEvent>().Unsubscribe(this.OnImageScanCompleted);
            this.eventAggregator.GetEvent<FolderExplorerSelectionEvent>().Unsubscribe(this.OnFolderExplorerSelctionRequestProcess);
        }

        private void OnContextMenuOpenCommandExecuted(FolderModel param)
        {
            this.CreateContextMenuItems(param);
        }

        private void OnPreviewDropFavorite(object args)
        {
            FolderModel fm = args as FolderModel;
            if (fm != null)
            {
                if (fm.Name.Equals("favorites", StringComparison.InvariantCultureIgnoreCase))
                {
                    isFavoriteDrop = true;
                    return;
                }
            }
            isFavoriteDrop = false;
        }

        private void OnDropFavorite(object args)
        {
            if (isFavoriteDrop)
            {
                var dragData = (args as DragEventArgs).Data.GetData("DragDropItemsControl");
                IList<object> items = dragData as IList<object>;
                if (items != null)
                {
                    foreach (var item in items)
                    {
                        ImageModel img = item as ImageModel;
                        if (img != null)
                        {
                            if (!img.IsFavorite)
                            {
                                img.IsFavorite = true;
                                this.dataService.UpdateFavorite(img.ID, img.IsFavorite);
                            }
                        }
                    }
                }
            }
        }

        private void SelectAll()
        {
            if (this.SelectedFolder != null)
                this.eventAggregator.GetEvent<ListBoxSelectAllEvent>().Publish(null);
        }

        private void OpenFolderLocation()
        {
            Process.Start(SelectedFolder.Path);
        }

        private void OpenProperties()
        {
            FolderPropertiesDialog fp = new FolderPropertiesDialog();
            fp.Tag = this.SelectedFolder.Path;
            fp.Owner = Application.Current.MainWindow;
            fp.Show();
        }

        private async void OnDelete(object args)
        {
            await DeleteFolder();
        }
        private void OnDrop(object args)
        {
            DragEventArgs e = args as DragEventArgs;
            if (e != null)
            {
                string[] folders = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                this.eventAggregator.GetEvent<FolderDroppedEvent>().Publish(new FolderDroppedEventArgs() { DroppedFolders = folders });
            }
        }

        private async void OnFolderAdded(object obj)
        {
            await this.InitializeData();
        }

        private async void OnFolderRemoved(object obj)
        {
            await DeleteFolder();

        }

        private async Task DeleteFolder()
        {
            MetroWindow window = (MetroWindow)App.Current.MainWindow;
            var result = await window.ShowMessageAsync("Remove From Powerpic", "Do you really want to remove " + SelectedFolder.Name + " folder from PowerPic?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                await this.dataService.RemoveSelectedFolder(SelectedFolder.ID);
                this.Folders.Remove(this.SelectedFolder);
                await window.ShowMessageAsync("Removed", "Folder Removed From PowerPic Succcessfully", MessageDialogStyle.Affirmative);
                this.SelectedFolder = this.Folders.LastOrDefault();
            }
        }

        private async Task InitializeData()
        {
            var folders = await this.dataService.GetAllFolders();
            this.Folders = new ObservableCollection<FolderModel>(folders);
            this.Folders.Insert(0, new FolderModel { ID = -1, Name = "Favorites" });
            // this.SelectedFolder = this.Folders.LastOrDefault();
        }

        private void CreateContextMenuItems(FolderModel model)
        {
            this.ContextMenuItems = new ContextMenu();
            this.contextMenuItems.Items.Add(new MenuItem() { Header = "Select All", Command = SelectAllCommand });
            if (model != null && !model.ID.Equals(-1))
            {
                this.contextMenuItems.Items.Add(new MenuItem() { Header = "Open Folder Location", Command = OpenFolderCommand });
                this.contextMenuItems.Items.Add(new MenuItem() { Header = "Properties", Command = PropertiesCommand });
                this.contextMenuItems.Items.Add(new MenuItem() { Header = "Remove from Database", Command = DeleteCommand });
            }
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.UnSubscribeEvents();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.SubscribeEvents();
            if (Convert.ToBoolean(SessionService<string>.TryRequest(Constants.ReloadSelectedFolderContent)))
            {
                SessionService<string>.Remove(Constants.ReloadSelectedFolderContent);
                this.OnFolderSelectedCommandExecute();
            }
        }
    }
}
