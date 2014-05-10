using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Foundation.Windows.Utils;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Events;
using PicBro.Shell.Windows.Properties;
using Microsoft.Practices.ServiceLocation;
using System.Windows.Input;

namespace PicBro.Shell.Windows.ViewModels
{
    public sealed class ImageListViewModel : ViewModelBase
    {
        private readonly IDataServiceProxy dataService;
        private readonly IEventAggregator eventAggregator;
        private DelegateCommand<object> openCommand;
        private DelegateCommand<object> addToFlimStripCommand;
        private DelegateCommand<object> dropCommand;
        private DelegateCommand<object> loadedCommand;
        private bool isSelectAll;
        private bool isFocusList;
        private int selectedIndex = -1;
        private List<ImageModel> images;
        private ImageModel selectedImage;
        private bool isLeftKeyPressed = false;
        public int ImageTileSize
        {
            get { return Properties.Settings.Default.ImageTileSize; }
        }

        public string SortBy
        {
            get { return Properties.Settings.Default.SortBy; }
        }
        public List<ImageModel> Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;
                this.RaisePropertyChanged(() => this.Images);
                this.HandleImagesChanged();
            }
        }

        private void HandleImagesChanged()
        {
            Dispatcher.CurrentDispatcher.BeginInvoke(new Action(() =>
                {
                    if (this.isLeftKeyPressed)
                    {
                        this.SelectedIndex = this.Images.Count - 1;
                        isLeftKeyPressed = false;
                        IRegionManager regionManager = ((NavigationService)navigationService).RegionManager;
                        UserControl view = (UserControl)regionManager.Regions[RegionNames.MainContentRegion].ActiveViews.FirstOrDefault();
                        ListBox listBox = (ListBox)view.FindName("list");
                        ListBoxItem listboxItem = (ListBoxItem)listBox.ItemContainerGenerator.ContainerFromIndex(this.SelectedIndex);
                        if (listboxItem != null)
                        {
                           listboxItem.Focus();
                        }                       
                        
                    }
                }), DispatcherPriority.ContextIdle, null);
        }
        public ImageModel SelectedImage
        {
            get { return selectedImage; }
            set
            {
                this.selectedImage = value;
                this.RaisePropertyChanged(() => this.SelectedImage);
            }
        }

        public DelegateCommand<object> OpenCommand
        {
            get { return openCommand; }
            private set { openCommand = value; }
        }

        public DelegateCommand<object> LoadedCommand
        {
            get { return this.loadedCommand; }
            private set { this.loadedCommand = value; }
        }


        private DelegateCommand<object> keyPressCommand;

        public DelegateCommand<object> KeyPressCommand
        {
            get { return keyPressCommand; }
            set { keyPressCommand = value; }
        }

        private DelegateCommand<object> addTagsCommand;

        public DelegateCommand<object> AddTagsCommand
        {
            get { return addTagsCommand; }
            set { addTagsCommand = value; }
        }


        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                this.selectedIndex = value;
                this.RaisePropertyChanged(() => this.SelectedIndex);
            }
        }



        public DelegateCommand<object> AddToFlimStripCommand
        {
            get { return addToFlimStripCommand; }
            private set { addToFlimStripCommand = value; }
        }

        public DelegateCommand<object> DropCommand
        {
            get { return dropCommand; }
            private set { dropCommand = value; }
        }
        public bool IsFocusList
        {
            get { return isFocusList; }
            set
            {
                this.isFocusList = value;
                this.RaisePropertyChanged(() => this.IsFocusList);
            }
        }
        public bool IsSelectAll
        {
            get { return isSelectAll; }
            set
            {
                this.isSelectAll = value;
                this.RaisePropertyChanged(() => this.IsSelectAll);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageListViewModel"/> class.
        /// </summary>
        /// <param name="dataservice">The dataservice.</param>
        public ImageListViewModel(
            IDataServiceProxy dataservice,
            IEventAggregator eventaggregator,
            INavigationService navigationservice)
            : base(eventaggregator, navigationservice)
        {
            this.dataService = dataservice;
            this.eventAggregator = eventaggregator;
            this.InitializeCommands();
            this.SubscribeEvents();

        }

        private void InitializeCommands()
        {
            this.OpenCommand = new DelegateCommand<object>(this.OnOpenCommand);
            this.DropCommand = new DelegateCommand<object>(this.OnDrop);
            this.LoadedCommand = new DelegateCommand<object>(this.OnLoadedCommandExecute);
            this.AddToFlimStripCommand = new DelegateCommand<object>(this.OnAddToFlimStripCommandExecute);
            this.KeyPressCommand = new DelegateCommand<object>(this.HandleKeyPress);
            this.AddTagsCommand = new DelegateCommand<object>(this.OnAddTagsCommand);
        }

        private void OnAddTagsCommand(object obj)
        {
            new PicBro.Shell.Windows.Views.AddTagsWindow(this.eventAggregator, this.dataService, obj) { Owner = App.Current.MainWindow }.ShowDialog();
        }

        private void HandleKeyPress(object obj)
        {
            var keyEventArgs = obj as KeyEventArgs;
            if (keyEventArgs != null)
            {
                if (this.SelectedIndex == 0)
                {
                    if (keyEventArgs.Key == Key.Left)
                    {
                        this.isLeftKeyPressed = true;
                        this.eventAggregator.GetEvent<MoveBackwardFolderEvent>().Publish(null);                       
                    }
                }
                else
                {
                    if (this.SelectedIndex == this.Images.Count - 1)
                    {
                        if (keyEventArgs.Key == Key.Right)
                        {
                            this.eventAggregator.GetEvent<MoveForwardFolderEvent>().Publish(null);
                           
                        }
                    }
                }
            }
        }

        private void OnLoadedCommandExecute(object obj)
        {
            UserControl control = (UserControl)obj;
            ListBox listBox = control.FindName("list") as ListBox;
            if (listBox.SelectedIndex >= 0)
            {
                ContentControl contentControl = (ContentControl)listBox.ItemContainerGenerator.ContainerFromIndex(listBox.SelectedIndex);
                contentControl.Focus();
            }
        }

        private void OnThumbSizeChange(object args)
        {
            int ImageTileSize = int.Parse(args.ToString());
            if (!this.Images.IsNullOrEmpty())
            {
                ToggleThumbSize(ImageTileSize);
            }
        }

        private void ToggleThumbSize(int ImageTileSize)
        {
            int value = ImageTileSize / Settings.Default.SliderIncrement;
            ThumbSize thumbSize = default(ThumbSize);

            switch (value)
            {
                case 1:
                    thumbSize = ThumbSize.Small;
                    break;
                case 2:
                    thumbSize = ThumbSize.Medium;
                    break;
                case 3:
                    thumbSize = ThumbSize.Large;
                    break;
                case 4:
                    thumbSize = ThumbSize.ExtraLarge;
                    break;
                default:
                    break;
            }

            foreach (var item in this.Images)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
                {
                    item.ImageThumbSize = thumbSize;
                }));
            }
        }

        private void ListBoxSelectAll(object obj)
        {
            IsSelectAll = true;
        }

        private void OnAddToFlimStripCommandExecute(object args)
        {
            IList<object> images = args as IList<object>;
            if (images != null)
                this.eventAggregator.GetEvent<AddImgesToFlimStripEvent>().Publish(new AddImagesToFlimStripEventArgs() { Images = images });
            this.SelectedIndex = -1;
        }

        private void OnSort(string obj)
        {
            if (!this.Images.IsNullOrEmpty())
            {
                string SortBy = obj.ToString();
                switch (SortBy)
                {
                    case "Name":
                        this.Images = this.Images.OrderBy(t => t.Name).ToList();
                        break;
                    case "Date Modified":
                        this.Images = this.Images.OrderBy(t => t.LastModifiedDate).ToList();
                        break;
                    case "Type":
                        this.Images = this.Images.OrderBy(t => Path.GetExtension(t.Path)).ToList();
                        break;
                    case "Size":
                        this.Images = this.Images.OrderBy(t => t.Size).ToList();
                        break;
                    case "Popularity":
                        this.Images = this.Images.OrderByDescending(t => t.Popularity).ToList();
                        break;
                }
            }
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

        private void OnSearch(List<ImageModel> obj)
        {
            this.Images = obj;
            IsFocusList = true;
            this.OnThumbSizeChange(this.ImageTileSize);
            this.OnSort(this.SortBy);
        }

        private void OnOpenCommand(object item)
        {
            if (this.SelectedImage != null)
            {
                SessionService<string>.Save(Constants.SelectedImage, this.SelectedImage);
                this.navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.ImageView);
                this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.ImageHeaderView);
                this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.ImageDetailView);
                if (!Settings.Default.ShowTagsOnLeft)
                {
                    this.navigationService.NavigateTo(RegionNames.RightNavigationRegion, ViewNames.TagView);
                }              
                this.eventAggregator.GetEvent<ImageFullViewNavigatedEvent>().Publish(new ImageFullViewNavigatedEventArgs() { ImageList = Images });
            }
        }

        private async void OnSelectedFolderChanged(int folderID)
        {
            this.Images = await this.dataService.GetAllImages(folderID);
            this.OnThumbSizeChange(Properties.Settings.Default.ImageTileSize);
            this.OnSort(Properties.Settings.Default.SortBy);
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Subscribe(this.OnSelectedFolderChanged);
            this.eventAggregator.GetEvent<SearchEvent>().Subscribe(this.OnSearch);
            this.eventAggregator.GetEvent<ImagesSortedEvent>().Subscribe(this.OnSort);
            this.eventAggregator.GetEvent<ListBoxSelectAllEvent>().Subscribe(this.ListBoxSelectAll);
            this.eventAggregator.GetEvent<ThumbSizeChangedEvent>().Subscribe(this.OnThumbSizeChange);
        }



        private void UnSubscribeEvents()
        {
            this.eventAggregator.GetEvent<SelectedFolderChangedEvent>().Unsubscribe(this.OnSelectedFolderChanged);
            this.eventAggregator.GetEvent<SearchEvent>().Unsubscribe(this.OnSearch);
            this.eventAggregator.GetEvent<ImagesSortedEvent>().Unsubscribe(this.OnSort);
            this.eventAggregator.GetEvent<ListBoxSelectAllEvent>().Unsubscribe(this.ListBoxSelectAll);
            this.eventAggregator.GetEvent<ThumbSizeChangedEvent>().Unsubscribe(this.OnThumbSizeChange);
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add("ID", string.Empty);
            this.UnSubscribeEvents();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.navigationService.ClearViews(RegionNames.RightNavigationRegion);
            this.SubscribeEvents();
        }
    }
}


