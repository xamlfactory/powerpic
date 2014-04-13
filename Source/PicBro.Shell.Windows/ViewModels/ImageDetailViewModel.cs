using System;
using System.Windows;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.ViewModel;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Foundation.Windows.Utils;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Events;
using PicBro.Shell.Windows.Properties;

namespace PicBro.Shell.Windows.ViewModels
{
    public sealed class ImageDetailViewModel : ViewModelBase
    {
        private readonly IDataServiceProxy dataService;
        private DelegateCommand<object> removeTagCommand;
        private DelegateCommand<object> editDescriptionCommand;
        private DelegateCommand<object> saveDescriptionCommand;
        private DelegateCommand<object> clearTagsCommand;
        private DelegateCommand<object> dropCommand;
        private DelegateCommand favoriteCommand;
        private DelegateCommand clearDescriptionCommand;
        private DelegateCommand<object> addTagCommand;
        private string newTag;
        private bool isDecriptionDisplay = true;
        private bool isTagsAvailable;
        private ImageModel image;
        private bool isDecriptionEdit;

        private bool OnEscapeCanExecute(object args)
        {
            return true;
        }

        public DelegateCommand<object> RemoveTagCommand
        {
            get { return removeTagCommand; }
            private set { removeTagCommand = value; }
        }

        public DelegateCommand<object> EditDescriptionCommand
        {
            get { return editDescriptionCommand; }
            private set { editDescriptionCommand = value; }
        }

        public DelegateCommand<object> SaveDescriptionCommand
        {
            get { return saveDescriptionCommand; }
            private set { saveDescriptionCommand = value; }
        }

        public DelegateCommand<object> ClearTagsCommand
        {
            get { return clearTagsCommand; }
            private set { clearTagsCommand = value; }
        }

        public bool IsDescriptionEdit
        {
            get { return isDecriptionEdit; }
            set
            {
                isDecriptionEdit = value;
                IsDescriptionDisplay = !value;
                this.RaisePropertyChanged(() => this.IsDescriptionEdit);
            }
        }

        public bool ShowTagsOnLeft
        {
            get
            {
                return Settings.Default.ShowTagsOnLeft;
            }
        }
        public bool IsDescriptionDisplay
        {
            get { return isDecriptionDisplay; }
            set
            {
                isDecriptionDisplay = value;
                this.RaisePropertyChanged(() => this.IsDescriptionDisplay);
            }
        }

        public bool IsTagsAvailable
        {
            get { return  this.Image != null && this.Image.Tags.Count > 0; }
        }
        public ImageModel Image
        {
            get { return image; }
            set
            {
                this.image = value;
                this.RaisePropertyChanged(() => this.Image);
                this.SetTagsForImage();
                this.SetDescriptionForImage();
            }
        }
        public DelegateCommand<object> DropCommand
        {
            get { return dropCommand; }
            private set { dropCommand = value; }
        }
        public DelegateCommand FavoriteCommand
        {
            get { return favoriteCommand; }
            private set { favoriteCommand = value; }
        }
        public DelegateCommand ClearDescriptionCommand
        {
            get { return clearDescriptionCommand; }
            private set { clearDescriptionCommand = value; }
        }
     
        public string NewTag
        {
            get { return newTag; }
            set
            {
                newTag = value;
                this.RaisePropertyChanged(() => this.NewTag);
                if (NewTag != null)
                {
                    AddTagCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public DelegateCommand<object> AddTagCommand
        {
            get { return addTagCommand; }
            private set { addTagCommand = value; }
        }

        public ImageDetailViewModel(
            IEventAggregator eventaggregator,
            IDataServiceProxy dataservice,
            INavigationService navigationService)
            : base(eventaggregator, navigationService)
        {
            this.dataService = dataservice;

            this.InitializeCommands();
        }

        private void InitializeCommands()
        {
            this.DropCommand = new DelegateCommand<object>(this.OnDrop);
            this.FavoriteCommand = new DelegateCommand(this.OnFavoriteCommandExecuted);
            this.AddTagCommand = new DelegateCommand<object>(this.OnAddTagExecute, this.OnAddTagCanExecute);
            this.RemoveTagCommand = new DelegateCommand<object>(this.OnRemoveTagExecute);
            this.EditDescriptionCommand = new DelegateCommand<object>(this.OnEditDescriptionExecute);
            this.SaveDescriptionCommand = new DelegateCommand<object>(this.OnSaveDescriptionExecute);
            this.ClearTagsCommand = new DelegateCommand<object>(this.OnClearTagsExecute, this.OnClearTagsCanExecute);
            this.ClearDescriptionCommand = new DelegateCommand(this.OnClearDescription);
        }

        private void OnClearDescription()
        {
            this.Image.Description = String.Empty;
        }

        private void OnFavoriteCommandExecuted()
        {
            this.dataService.UpdateFavorite(this.Image.ID, this.Image.IsFavorite);
        }
        private void OnEditDescriptionExecute(object args)
        {
            IsDescriptionEdit = true;
        }

        private async void OnSaveDescriptionExecute(object args)
        {
            try
            {
                if (this.Image != null)
                    await this.dataService.UpdateDescription(this.Image.ID, this.Image.Description);
            }
            catch { }

            IsDescriptionEdit = false;
        }

        private void OnAddTagExecute(object args)
        {
            if (NewTag.Trim() != string.Empty)
            {
                this.Image.Tags.Add(NewTag);
                this.RaisePropertyChanged(() => this.IsTagsAvailable);
                try
                {
                    this.dataService.InsertTag(NewTag, this.Image.ID);
                    NewTag = string.Empty;
                }
                catch
                {

                }
            }
        }

        private bool OnAddTagCanExecute(object args)
        {
            if (NewTag != null && NewTag.Trim() != string.Empty)
                return true;
            else
                return false;
        }
        private async void OnRemoveTagExecute(object args)
        {
            try
            {
                if (args != null && this.Image != null)
                {
                    this.Image.Tags.Remove(args.ToString());
                    this.RaisePropertyChanged(() => this.IsTagsAvailable);
                    await this.dataService.RemoveTagForImage(this.Image.ID, args.ToString());
                }
            }
            catch
            {

            }
        }

        private async void OnClearTagsExecute(object args)
        {
            try
            {
                if (this.Image != null)
                {
                    this.Image.Tags.Clear(); 
                    this.RaisePropertyChanged(() => this.IsTagsAvailable);
                    await this.dataService.RemoveAllTags(this.Image.ID);
                }
            }
            catch
            {

            }
        }

        private bool OnClearTagsCanExecute(object args)
        {
            return true;
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


        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.Image = (ImageModel)SessionService<string>.Request(Constants.SelectedImage);
            this.RaisePropertyChanged("ShowTagsOnLeft");
        }

        public async void SetTagsForImage()
        {
            try
            {
                if (this.Image != null && this.Image.Tags == null)
                {
                    string tags = await this.dataService.GetTagsForImage(this.Image.ID);
                    string[] tagsSplited = tags.Split(',');
                    this.Image.Tags = tagsSplited.ToObservableCollection<string>();
                    this.RaisePropertyChanged(() => this.IsTagsAvailable);
                }
            }
            catch (Exception)
            {

            }
        }

        public async void SetDescriptionForImage()
        {
            try
            {
                if (this.Image != null && this.Image.Description == null)
                {
                    this.Image.Description = await this.dataService.GetDescriptionForImage(this.Image.ID);
                }
            }
            catch (Exception)
            {
                this.Image.Description = null;
            }
        }
    }
}
