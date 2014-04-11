using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using PicBro.DataModel.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.Common;

namespace PicBro.Shell.Windows.ViewModels
{
    using System.Threading;
    using System.Windows;
    using System.Windows.Threading;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using PicBro.Shell.Windows.Events;

    public sealed class ImageViewModel : ViewModelBase
    {
        private ImageModel imageModel;
        private DelegateCommand<object> addToFlimStripCommand;
        private List<ImageModel> imageList;
        private DelegateCommand<object> dropCommand;
        private object image;

        public DelegateCommand NextImageCommand { get; private set; }
        public DelegateCommand PreviousImageCommand { get; private set; }
        public DelegateCommand<object> DropCommand
        {
            get { return dropCommand; }
            private set { dropCommand = value; }
        }
        public object Image
        {
            get { return image; }
            set
            {
                image = value;
                this.RaisePropertyChanged(() => this.Image);
            }
        }
        public ImageModel ImageModel
        {
            get { return imageModel; }
            set
            {
                imageModel = value;
                SessionService<string>.Save(Constants.SelectedImage, value);
                this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.ImageDetailView);
                this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.ImageHeaderView);
                this.RaisePropertyChanged(() => this.ImageModel);
                this.RaisePropertyChanged(() => this.Image);
            }
        }
        public DelegateCommand<object> AddToFlimStripCommand
        {
            get { return addToFlimStripCommand; }
            private set { addToFlimStripCommand = value; }
        }

        public ImageViewModel(
            INavigationService navigationservice,
            IEventAggregator eventaggregator)
            : base(eventaggregator, navigationservice)
        {
            this.InitializeCommands();
            this.SubscribeEvents();
        }

        private void InitializeCommands()
        {
            this.NextImageCommand = new DelegateCommand(this.OnNextExecute, this.OnNextCanExecute);
            this.PreviousImageCommand = new DelegateCommand(this.OnPreviousExecute, this.OnPreviousCanExecute);
            this.DropCommand = new DelegateCommand<object>(this.OnDrop);
            this.AddToFlimStripCommand = new DelegateCommand<object>(this.OnAddToFlimStripCommandExecute);
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<ImageFullViewNavigatedEvent>().Subscribe(OnFullViewImageEvent);
        }

        private void UnSubscribeEvents()
        {
            this.eventAggregator.GetEvent<ImageFullViewNavigatedEvent>().Unsubscribe(OnFullViewImageEvent);
        }
        private void OnAddToFlimStripCommandExecute(object args)
        {
            IList<object> images = new List<object>();
            images.Add(this.ImageModel);
            if (images != null)
                this.eventAggregator.GetEvent<AddImgesToFlimStripEvent>().Publish(new AddImagesToFlimStripEventArgs() { Images = images });
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
        private void OnFullViewImageEvent(ImageFullViewNavigatedEventArgs args)
        {
            imageList = args.ImageList;
            NextImageCommand.RaiseCanExecuteChanged();
            PreviousImageCommand.RaiseCanExecuteChanged();
        }
        private async void OnNextExecute()
        {
            if (imageList != null)
            {
                int index = imageList.IndexOf(ImageModel);
                if (index < imageList.Count - 1)
                {
                    ImageModel = imageList[index + 1];
                    await this.SetDelayImage();
                }
                NextImageCommand.RaiseCanExecuteChanged();
                PreviousImageCommand.RaiseCanExecuteChanged();
            }
        }
        private bool OnNextCanExecute()
        {
            if (imageList != null)
            {
                int index = imageList.IndexOf(ImageModel);
                if (index < imageList.Count - 1) return true;
            }
            return false;
        }

        private async void OnPreviousExecute()
        {
            if (imageList != null)
            {
                int index = imageList.IndexOf(ImageModel);
                if (index > 0)
                {
                    ImageModel = imageList[index - 1];
                    await this.SetDelayImage();
                }
                PreviousImageCommand.RaiseCanExecuteChanged();
                NextImageCommand.RaiseCanExecuteChanged();
            }
        }
        private bool OnPreviousCanExecute()
        {
            if (imageList != null)
            {
                int index = imageList.IndexOf(ImageModel);
                if (index > 0) return true;
            }
            return false;
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.SubscribeEvents();
        }

        public override async void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ImageModel = (ImageModel)SessionService<string>.Request(Constants.SelectedImage);
            await SetDelayImage();
            this.UnSubscribeEvents();
        }

        private async Task SetDelayImage()
        {
            if (this.ImageModel != null)
            {
                this.Image = this.ImageModel.ThumbDataSmall;
                await Task.Factory.StartNew(new Action(() => Thread.Sleep(100)));
                await Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ContextIdle, new Action(() => { this.Image = this.ImageModel.Path; }));
            }
        }
    }
}
