using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicBro.Foundation.Windows.Utils;
using Microsoft.Practices.Prism.Events;
using PicBro.Shell.Windows.Events;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.Common;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace PicBro.Shell.Windows.ViewModels
{
    public class TagViewModel : ViewModelBase
    {
        #region Private Fields

        private IDataServiceProxy dataService;
        private IEventAggregator eventAggregator;
        private DelegateCommand<object> addTagCommand;
        private ImageModel image;
        private string newTag;
        private DelegateCommand<object> clearTagsCommand;
        private DelegateCommand<object> removeTagCommand;

        #endregion

        #region Ctor

        public TagViewModel(IDataServiceProxy dataservice,IEventAggregator eventaggregator)
        {
            this.dataService = dataservice;
            this.eventAggregator = eventaggregator;
            this.InitializeCommands();
            this.Image =SessionService<string>.Request(Constants.SelectedImage) as ImageModel;
        }

        #endregion

        #region Properties

        public DelegateCommand<object> RemoveTagCommand
        {
            get { return removeTagCommand; }
            private set { removeTagCommand = value; }
        }

        public DelegateCommand<object> AddTagCommand
        {
            get { return addTagCommand; }
            private set { addTagCommand = value; }
        }

        public DelegateCommand<object> ClearTagsCommand
        {
            get { return clearTagsCommand; }
            private set { clearTagsCommand = value; }
        }

        public bool IsTagsAvailable
        {
            get { return this.Image != null && this.Image.Tags.Count > 0; }
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

       

        public ImageModel Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                this.RaisePropertyChanged(() => this.Image);
                this.SetTagsForImage();
            }
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


        #endregion

        private void InitializeCommands()
        {
            this.AddTagCommand = new DelegateCommand<object>(this.OnAddTagExecute, this.OnAddTagCanExecute);
            this.ClearTagsCommand = new DelegateCommand<object>(this.OnClearTagsExecute, this.OnClearTagsCanExecute);
            this.RemoveTagCommand = new DelegateCommand<object>(this.OnRemoveTagExecute);
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

        private bool OnClearTagsCanExecute(object arg)
        {
            return true;
        }
        private async void OnClearTagsExecute(object args)
        {
            try
            {
                if (this.Image != null)
                {
                    var result = MessageBox.Show("Are you sure you want to delete all tags?", "Delete Tags", MessageBoxButton.YesNo);
                    if (result == MessageBoxResult.Yes)
                    {
                        this.Image.Tags.Clear();
                        this.RaisePropertyChanged(() => this.IsTagsAvailable);
                        await this.dataService.RemoveAllTags(this.Image.ID);
                    }
                }
            }
            catch
            {

            }
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


        public override bool IsNavigationTarget(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public override void OnNavigatedFrom(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            this.UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            this.eventAggregator.GetEvent<ImageChangedEvent>().Unsubscribe(null);
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            this.SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<ImageChangedEvent>().Subscribe(this.SetTagsForImage);
        }

        private void SetTagsForImage(ImageModel image)
        {
            this.Image = image;
        }
    }
}
