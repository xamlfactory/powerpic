using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.Practices.Prism.Events;
using PicBro.DataModel.Windows;
using PicBro.Shell.Windows.Events;

namespace PicBro.Shell.Windows.ViewModels
{
    using System.Diagnostics;
    using System.IO;
    using System.Windows;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using PicBro.DAL.Windows;
    using PicBro.Foundation.Windows.Infrastructure;
    using PicBro.Shell.Windows.Common;
    using PicBro.Shell.Windows.Views;
    using PicBro.Shell.Windows.Views.Export;

    public sealed class FooterViewModel : ViewModelBase
    {
        private readonly IEMailService eMailService;
        private readonly IZipService zipService;
        private readonly IDataServiceProxy dataService;
        private bool showProgress;
        private int progressValue;
        private string progressText;
        private bool isDropListEmpty = true;
        private byte[] data;
        private ObservableCollection<ImageModel> images;
        private ImageModel selectedImage;
        private double progress;
        private DelegateCommand<object> openCommand;
        private DelegateCommand<object> emailCommand;
        private DelegateCommand<object> exportCommand;
        private DelegateCommand<object> deleteCommand;
        private DelegateCommand<object> slideShowCommand;

        public DelegateCommand<object> OpenCommand
        {
            get { return openCommand; }
            private set { openCommand = value; }
        }

        public DelegateCommand<object> EmailCommand
        {
            get { return emailCommand; }
            private set { emailCommand = value; }
        }

        public bool ShowProgress
        {
            get { return showProgress; }
            set
            {
                this.showProgress = value;
                this.RaisePropertyChanged(() => this.ShowProgress);
            }
        }

        public DelegateCommand<object> ExportCommand
        {
            get { return exportCommand; }
            private set { exportCommand = value; }
        }

        public DelegateCommand<object> DeleteCommand
        {
            get { return deleteCommand; }
            private set { deleteCommand = value; }
        }

        public DelegateCommand<object> SlideShowCommand
        {
            get { return slideShowCommand; }
            private set { slideShowCommand = value; }
        }
        public ObservableCollection<ImageModel> Images
        {
            get { return images; }
            set
            {
                images = value;
                this.RaisePropertyChanged(() => this.Images);
            }
        }

        public ImageModel SelectedImage
        {
            get { return selectedImage; }
            set
            {
                selectedImage = value;
                this.RaisePropertyChanged(() => this.SelectedImage);
            }
        }

        public double Progress
        {
            get { return progress; }
            set
            {
                progress = value;
                this.RaisePropertyChanged(() => this.Progress);
            }
        }

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                this.RaisePropertyChanged(() => this.ProgressValue);
            }
        }

        public string ProgressText
        {
            get { return progressText; }
            set
            {
                progressText = value;
                this.RaisePropertyChanged(() => this.ProgressText);
            }
        }

        public byte[] Data
        {
            get { return data; }
            set
            {
                data = value;
                this.RaisePropertyChanged(() => this.Data);
            }
        }

        public bool IsDropListEmpty
        {
            get { return isDropListEmpty; }
            set
            {
                isDropListEmpty = value;
                this.RaisePropertyChanged(() => this.IsDropListEmpty);

                if (EmailCommand != null)
                    EmailCommand.RaiseCanExecuteChanged();
                if (ExportCommand != null)
                    ExportCommand.RaiseCanExecuteChanged();
                if (SlideShowCommand != null)
                    SlideShowCommand.RaiseCanExecuteChanged();
            }
        }

        public FooterViewModel(INavigationService navigationservice,
            IEventAggregator eventaggregator,
            IEMailService emailservice,
            IDataServiceProxy dataservice,
            IDialogService dialogservice,
            IThreadService threadservice,
            IZipService zipservice)
            : base(eventaggregator, navigationservice, dialogservice, threadservice)
        {
            this.eMailService = emailservice;
            this.zipService = zipservice;
            this.dataService = dataservice;

            images = new ObservableCollection<ImageModel>();
            Images.CollectionChanged += Images_CollectionChanged;
            this.InitializeCommands();
            this.SubscribeEvents();
        }

        private void InitializeCommands()
        {
            this.OpenCommand = new DelegateCommand<object>(this.OnOpenCommand);
            this.EmailCommand = new DelegateCommand<object>(this.OnEmailExecute, this.OnEmailCanExecute);
            this.ExportCommand = new DelegateCommand<object>(this.OnExportExecute, this.OnExportCanExecute);
            this.SlideShowCommand = new DelegateCommand<object>(this.OnSlideShowCommandExecute, this.OnSlideShowCommandCanExecute);
            this.DeleteCommand = new DelegateCommand<object>(this.OnDeleteExecute);
        }

        private void OnOpenCommand(object item)
        {
            if (this.SelectedImage != null)
            {
                SessionService<string>.Save(Constants.SelectedImage, this.SelectedImage);
                this.navigationService.NavigateTo(RegionNames.MainContentRegion, ViewNames.ImageView);
                this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.ImageDetailView);
                this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.ImageHeaderView);
                this.eventAggregator.GetEvent<ImageFullViewNavigatedEvent>().Publish(new ImageFullViewNavigatedEventArgs() { ImageList = Images.ToList() });
            }
        }

        private void OnEmailExecute(object obj)
        {
            List<string> filePaths = new List<string>();
            foreach (var imageModel in Images)
            {
                filePaths.Add(imageModel.Path);
            }
            string zipFile = this.zipService.GetZipFile(filePaths);
            this.eMailService.OpenStandardEmailClient(zipFile);
        }
        private bool OnEmailCanExecute(object obj)
        {
            return !IsDropListEmpty;
        }
        private async void OnExportExecute(object obj)
        {
            ExportDialog exdia = new ExportDialog();
            if (exdia.ShowDialog() == true)
            {
                this.threadService.DoBackgroundWork(async (o, e) =>
                {
                    int cntLength = Images.Count.ToString().Length;
                    for (int i = 0; i < Images.Count; i++)
                    {
                        FileInfo fileInfo = new FileInfo(Images[i].Path);
                        string fileName = fileInfo.Name;
                        if (Properties.Settings.Default.IsPreserveOrderOnExport)
                        {
                            int cnt = cntLength - (i + 1).ToString().Length;
                            string prefix = string.Empty;
                            for (int j = 0; j < cnt; j++)
                            {
                                prefix = "0" + prefix;
                            }
                            fileName = prefix + (i + 1).ToString() + "-" + fileName;
                        }
                        string directoryPath = Properties.Settings.Default.LastExportedDirectoryPath + "\\" + Properties.Settings.Default.LastExportedCollectionName;
                        if (!Directory.Exists(directoryPath))
                        {
                            Directory.CreateDirectory(directoryPath);
                        }

                        string filePath = directoryPath + @"\" + fileName;
                        int c = 1;
                        while (File.Exists(filePath))
                        {
                            filePath = directoryPath + @"\" + fileName.Remove(fileName.LastIndexOf(fileInfo.Extension), fileInfo.Extension.Length) + "-" + c.ToString() + fileInfo.Extension;
                            if (c > 1000)
                                break;
                            c++;
                        }
                        if (File.Exists(fileInfo.FullName))
                        {
                            File.Copy(fileInfo.FullName, filePath, true);
                            await this.dataService.UpdatePopularity(Images[i].ID);
                            this.Images[i].Popularity++;
                        }
                        double ExportProgress = ((double)(i + 1.0) / (double)Images.Count) * 100.0;
                        this.eventAggregator.GetEvent<ScanProgressChanged>().Publish(new ScanProgressChangedArgs { Progress = ExportProgress, Data = Images[i].ThumbDataSmall, ProgressText = "Exporting." });

                    }

                }, (o, e) =>
                {
                    this.dialogService.CloseDialog();
                    Process.Start(Properties.Settings.Default.LastExportedDirectoryPath + "\\" + Properties.Settings.Default.LastExportedCollectionName);

                });
            }
        }
        private bool OnExportCanExecute(object obj)
        {
            return !IsDropListEmpty;
        }

        private void OnSlideShowCommandExecute(object obj)
        {
            var value = SessionService<string>.Request(Constants.SlideShowWindow);
            if (value != null)
            {
                (value as Window).Activate();
            }
            else
            {
                SlideShowWindow window = new SlideShowWindow();
                SlideShowViewModel viewModel = new SlideShowViewModel(window, this.Images.ToList());
                window.DataContext = viewModel;
                SessionService<string>.Save(Constants.SlideShowWindow, window);
                window.Show();
            }
        }

        private bool OnSlideShowCommandCanExecute(object obj)
        {
            return !IsDropListEmpty;
        }

        private void OnDeleteExecute(object obj)
        {
            this.Images.Remove(obj as ImageModel);
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<ScanProgressChanged>().Subscribe(this.OnScanProgressChanged);
            this.eventAggregator.GetEvent<AddImgesToFlimStripEvent>().Subscribe(this.AddImagesToFlimStrip);
        }

        private void UnSubscribeEvents()
        {
            this.eventAggregator.GetEvent<ScanProgressChanged>().Unsubscribe(this.OnScanProgressChanged);
            this.eventAggregator.GetEvent<AddImgesToFlimStripEvent>().Unsubscribe(this.AddImagesToFlimStrip);
        }

        void Images_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (Images.Count > 0)
                IsDropListEmpty = false;
            else
                IsDropListEmpty = true;
        }

        private void AddImagesToFlimStrip(AddImagesToFlimStripEventArgs args)
        {
            if (args.Images != null)
            {
                foreach (var item in args.Images)
                {
                    Images.Add(item as ImageModel);
                }
            }
        }

        private void OnScanProgressChanged(ScanProgressChangedArgs obj)
        {
            if (!this.ShowProgress)
            {
                this.ShowProgress = true;
            }
            this.Progress = obj.Progress;
            this.ProgressText = obj.ProgressText;
            this.ProgressValue = (int)this.Progress;
            this.Data = obj.Data;
            if (this.Progress == 100.0)
            {
                this.ShowProgress = false;
                this.Progress = 0.0;
            }
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            this.UnSubscribeEvents();
        }

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.SubscribeEvents();
        }
    }
}
