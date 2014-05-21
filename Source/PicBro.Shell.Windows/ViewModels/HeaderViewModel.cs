using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Events;
using PicBro.Shell.Windows.Views;

namespace PicBro.Shell.Windows.ViewModels
{
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Text;
    using System.Windows.Input;
    using MahApps.Metro.Controls.Dialogs;

    public abstract class HeaderViewModel : ViewModelBase
    {
        private double progress;
        private string searchText;
        private int selectedFolderId = -1;
        private DelegateCommand addFolderCommand;
        private DelegateCommand removeFolderFromDBCommand;
        private DelegateCommand exitCommand;
        private DelegateCommand aboutCommand;
        private DelegateCommand searchCommand;
        private DelegateCommand resetCommand;
        private DelegateCommand searchSettingsCommand;
        private DelegateCommand launchTutorialCommand;
        private DelegateCommand<object> sortCommand;
        private readonly IDataServiceProxy dataService;
        private Window manageWindow;


        public DelegateCommand LaunchTutorialCommand
        {
            get { return this.launchTutorialCommand; }
            private set { this.launchTutorialCommand = value; }
        }

        /// <summary>
        /// Gets or sets SortCommand property
        /// </summary>
        public DelegateCommand<object> SortCommand
        {
            get { return this.sortCommand; }
            private set { this.sortCommand = value; }
        }

        public string SearchText
        {
            get { return searchText; }
            set
            {
                searchText = value;
                this.RaisePropertyChanged(() => this.SearchText);
            }
        }

        public DelegateCommand AboutCommand
        {
            get { return aboutCommand; }
            private set { aboutCommand = value; }
        }

        public DelegateCommand ExitCommand
        {
            get { return exitCommand; }
            private set { exitCommand = value; }
        }

        public DelegateCommand AddFolderCommand
        {
            get { return addFolderCommand; }
            private set { addFolderCommand = value; }
        }

        public DelegateCommand RemoveFolderFromDBCommand
        {
            get { return removeFolderFromDBCommand; }
            private set { removeFolderFromDBCommand = value; }
        }

        public DelegateCommand SearchCommand
        {
            get { return searchCommand; }
            private set { searchCommand = value; }
        }

        public DelegateCommand ResetCommand
        {
            get { return resetCommand; }
            private set { resetCommand = value; }
        }

        public DelegateCommand SearchSettingsCommand
        {
            get { return searchSettingsCommand; }
            private set { searchSettingsCommand = value; }
        }

        private DelegateCommand manageTagsCommand;

        public DelegateCommand ManageTagsCommand
        {
            get { return manageTagsCommand; }
            set { manageTagsCommand = value; }
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

        /// <summary>
        /// Gets or sets sort by property
        /// </summary>
        public string SortBy
        {
            get { return Properties.Settings.Default.SortBy; }
            set { Properties.Settings.Default.SortBy = value; }
        }

        /// <summary>
        /// Gets or sets Thumb Size property
        /// </summary>
        public int ThumbSize
        {
            get
            {
                return Properties.Settings.Default.ImageTileSize;
            }

            set
            {
                Properties.Settings.Default.ImageTileSize = value;
                this.RaisePropertyChanged(() => this.ThumbSize);
                this.eventAggregator.GetEvent<ThumbSizeChangedEvent>().Publish(value);
            }
        }

        public int MinimumSliderValue
        {
            get { return Properties.Settings.Default.MinimumSliderValue; }
        }
        public int MaximumSliderValue
        {
            get { return Properties.Settings.Default.MaximumSliderValue; }
        }
        public int SliderIncrement
        {
            get { return Properties.Settings.Default.SliderIncrement; }
        }

        public HeaderViewModel(
            IDialogService dialogservice,
            IDataServiceProxy dataservice,
            IEventAggregator eventaggregator,
            IThreadService threadservice,
            INavigationService navigationservice)
            : base(eventaggregator, navigationservice, dialogservice, threadservice)
        {
            this.dataService = dataservice;
            this.SearchText = string.Empty;
            this.InitializeCommands();
            this.SubscribeEvents();
        }

        private void InitializeCommands()
        {
            this.AddFolderCommand = new DelegateCommand(OnAddFolderExecuted);
            this.RemoveFolderFromDBCommand = new DelegateCommand(this.OnRemoveFromDBExecute, this.OnRemoveFromDBCanExecute);
            this.SearchCommand = new DelegateCommand(this.OnSearchExecuted);
            this.ResetCommand = new DelegateCommand(this.OnReset);
            this.ExitCommand = new DelegateCommand(this.OnExit);
            this.SearchSettingsCommand = new DelegateCommand(this.OnSearchSettingsExecute);
            this.SortCommand = new DelegateCommand<object>(this.OnSortCommandExecuted);
            this.LaunchTutorialCommand = new DelegateCommand(this.OnLauchTutorialCommandExecuted);
            this.ManageTagsCommand = new DelegateCommand(this.OnManageTages);
        }

        private void OnManageTages()
        {
            this.manageWindow = new ManageTagsWindow(this.dataService, this.threadService, this.eventAggregator, this.navigationService) { Owner = App.Current.MainWindow };
            this.manageWindow.Show();
        }

        private void OnLauchTutorialCommandExecuted()
        {
            new TutorialView().Show();
        }

        protected virtual void OnOEMCommandExecuted(object obj)
        {
            if (obj != null)
            {
                string value = obj.ToString();
                if (value.Equals(Key.OemPlus.ToString()) && !(this.ThumbSize >= this.MaximumSliderValue))
                {
                    this.ThumbSize += this.SliderIncrement;
                }
                else if (value.Equals(Key.OemMinus.ToString()) && !(this.ThumbSize <= this.MinimumSliderValue))
                {
                    this.ThumbSize -= this.SliderIncrement;
                }
            }
        }

        /// <summary>
        /// This method used to sort images
        /// </summary>
        /// <param name="menuItem">menu item type</param>
        public void OnSortCommandExecuted(object menuItem)
        {
            System.Windows.Controls.MenuItem menu = menuItem as System.Windows.Controls.MenuItem;
            if (menu != null)
            {
                this.SortBy = menu.Header.ToString();
                ((System.Windows.Controls.RadioButton)menu.Icon).IsChecked = !((System.Windows.Controls.RadioButton)menu.Icon).IsChecked;
                this.eventAggregator.GetEvent<ImagesSortedEvent>().Publish(menu.Header.ToString());
            }
        }

        private async void OnReset()
        {
            MetroWindow window = (MetroWindow)App.Current.MainWindow;
            var result = await window.ShowMessageAsync("Reset Powerpic", "Do you really want to reset the data?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                await this.dataService.DeleteAll();
                await window.ShowMessageAsync("Restart", "All data have been deleted successfully. The application will restart now.", MessageDialogStyle.Affirmative);
                System.Diagnostics.Process.Start(App.ResourceAssembly.Location);
                App.Current.Shutdown();
            }
        }
        private void OnExit()
        {
            Application.Current.Shutdown();
        }

        private void OnSearchExecuted()
        {
            if (!string.IsNullOrEmpty(this.SearchText.Trim()))
            {
                this.threadService.DoBackgroundWork(async (o, e) =>
                {
                    e.Result = await this.dataService.GetAllImages(this.SearchText, Properties.Settings.Default.IsTagSearchEnabled, Properties.Settings.Default.IsDescriptionSearchEnabled, Properties.Settings.Default.IsFavoritesOnly);
                },
                (o, e) =>
                {
                    SessionService<string>.Save(Constants.ReloadSelectedFolderContent, true);
                    this.navigationService.NavigateTo(RegionNames.MenuBarRegion, ViewNames.ImageHeaderView);
                    this.navigationService.NavigateTo(RegionNames.NavigationRegion, ViewNames.SearchDetailView);
                    List<ImageModel> list = e.Result as List<ImageModel>;
                    this.eventAggregator.GetEvent<SearchEvent>().Publish(list);
                });
            }
        }

        private void OnAddFolderExecuted()
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            string previousFolderPath = Properties.Settings.Default.LastImportedDirectoryPath;
            if (previousFolderPath != null && previousFolderPath != string.Empty) dialog.SelectedPath = previousFolderPath.Trim();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo info = new DirectoryInfo(dialog.SelectedPath);
                Properties.Settings.Default.LastImportedDirectoryPath = dialog.SelectedPath;
                this.Scan(info.Name, info.FullName);
            }
        }

        private void OnRemoveFromDBExecute()
        {
            this.eventAggregator.GetEvent<FolderRemovedEvent>().Publish(selectedFolderId);
        }
        private bool OnRemoveFromDBCanExecute()
        {
            if (selectedFolderId > 0) return true;
            else return false;
        }

        protected virtual void OnFolderSelected(int id)
        {
            selectedFolderId = id;
            if (RemoveFolderFromDBCommand != null)
            {
                this.RemoveFolderFromDBCommand.RaiseCanExecuteChanged();
            }
        }

        private string[] GetFiles(string SourceFolder, string Filter, System.IO.SearchOption searchOption)
        {
            // ArrayList will hold all file names
            ArrayList alFiles = new ArrayList();

            // Create an array of filter string
            string[] MultipleFilters = Filter.Split('|');

            // for each filter find mathing file names
            foreach (string FileFilter in MultipleFilters)
            {
                // add found file names to array list
                alFiles.AddRange(Directory.GetFiles(SourceFolder, FileFilter, searchOption));
            }

            // returns string array of relevant file names
            return (string[])alFiles.ToArray(typeof(string));
        }

        public void Scan(string name, string path)
        {
            this.threadService.DoBackgroundWork(async (o, e) =>
            {
                int lastrow = 0;
                int progressValue = 0;
                var imageFolders = await dataService.GetAllFolders();
                List<string> existingFolderList = imageFolders.Select(f => f.Name).ToList();
                var supportedFileTypes = Properties.Settings.Default.Supportedfiletypes;
                List<string> importFolders = new List<string>();
                importFolders.Add(path);
                foreach (var item in Directory.EnumerateDirectories(path, "*", SearchOption.AllDirectories))
                {
                    importFolders.Add(item);
                }

                StringBuilder fileTypes = new StringBuilder();

                foreach (string str in supportedFileTypes)
                {
                    fileTypes.Append(string.Format("*{0}|", str));
                }

                int totalImagesCount = this.GetFiles(path, fileTypes.ToString(), SearchOption.AllDirectories).Count();

                foreach (string folder in importFolders)
                {
                    string[] images = this.GetFiles(folder, fileTypes.ToString(), SearchOption.TopDirectoryOnly);
                    if (images.Count() > 0)
                    {
                        DirectoryInfo imageFolderInfo = new DirectoryInfo(folder);
                        string folderName = imageFolderInfo.Name;
                        int count = existingFolderList.Count((f) =>
                        {
                            if (f.IndexOf("_") >= 0)
                            {
                                if (f.Remove(f.IndexOf("_")).Trim().Equals(folderName))
                                {
                                    return true;
                                }
                            }
                            else if (f.Equals(folderName))
                            {
                                return true;
                            }

                            return false;
                        });


                        if (count > 0)
                        {
                            folderName = string.Format("{0}_{1}", folderName, count);
                        }

                        lastrow = await dataService.InsertFolder(folderName, imageFolderInfo.FullName);
                        if (lastrow <= 0)
                        {
                            break;
                        }

                        existingFolderList.Add(folderName);
                        this.eventAggregator.GetEvent<FolderAddedEvent>().Publish(null);
                    }

                    foreach (string image in images)
                    {
                        FileInfo fileInfo = new FileInfo(image);
                        byte[] originalimage = File.ReadAllBytes(fileInfo.FullName);
                        byte[] smalldata = this.CreateThumbnailBytes(originalimage, 120);
                        byte[] mediumdata = this.CreateThumbnailBytes(originalimage, 180);
                        byte[] largedata = this.CreateThumbnailBytes(originalimage, 240);
                        byte[] extraLargeData = this.CreateThumbnailBytes(originalimage, 360);
                        int imageID = await dataService.InsertImage(lastrow, fileInfo.FullName, smalldata, mediumdata, largedata, extraLargeData);
                        await dataService.InsertTag(System.IO.Path.GetFileNameWithoutExtension(fileInfo.FullName), imageID);
                        this.Progress = ((double)(progressValue + 1.0) / (double)totalImagesCount) * 100.0;
                        this.eventAggregator.GetEvent<ScanProgressChanged>().Publish(new ScanProgressChangedArgs { Progress = progress, Data = smalldata, ProgressText = "Scanning..." });
                        progressValue++;
                    }

                    this.eventAggregator.GetEvent<ImageScanCompletedEvent>().Publish(null);
                }
            }, (o, e) =>
            {
                this.dialogService.CloseDialog();
            });
        }

        private byte[] CreateThumbnailBytes(byte[] originalImage, int desiredWidth)
        {
            Image thumbnail = null;
            Image tempImage = Image.FromStream(new MemoryStream(originalImage));
            int newPixelWidth = tempImage.Width;
            int newPixelHeight = tempImage.Height;

            if (newPixelWidth > desiredWidth)
            {
                float resizePercent = 0F;

                if (newPixelHeight > newPixelWidth)
                {
                    resizePercent = ((float)desiredWidth / (float)tempImage.Height);
                }
                else
                {
                    resizePercent = ((float)desiredWidth / (float)tempImage.Width);
                }

                newPixelWidth = (int)(tempImage.Width * resizePercent) + 1;
                newPixelHeight = (int)(tempImage.Height * resizePercent) + 1;
            }

            Bitmap bitmap = new Bitmap(newPixelWidth, newPixelHeight);

            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(tempImage, 0, 0, newPixelWidth, newPixelHeight);
            }

            thumbnail = (Image)bitmap;
            MemoryStream ms = new MemoryStream();
            thumbnail.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

        private void OnSearchSettingsExecute()
        {
            new SearchSettingsWindow() { Owner = Application.Current.MainWindow }.ShowDialog();
        }

        public override bool IsNavigationTarget(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            throw new System.NotImplementedException();
        }

        public override void OnNavigatedFrom(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            this.UnubscribeEvents();
        }

        public override void OnNavigatedTo(Microsoft.Practices.Prism.Regions.NavigationContext navigationContext)
        {
            this.SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            this.eventAggregator.GetEvent<CloseWindowEvent>().Subscribe(this.OnCloseWindow);
        }
        private void UnubscribeEvents()
        {
            this.eventAggregator.GetEvent<CloseWindowEvent>().Unsubscribe(this.OnCloseWindow);
        }

        private void OnCloseWindow(object obj)
        {
            if (this.manageWindow != null)
            {
                this.manageWindow.Owner.Activate();
                if (this.manageWindow.IsVisible)
                {
                    this.manageWindow.Close();
                }
            }
        }
    }
}
