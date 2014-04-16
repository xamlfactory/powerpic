using System.Drawing;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using PicBro.DAL.Windows;
using PicBro.Shell.Windows.Properties;
using Infralution.Localization.Wpf;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : MetroWindow
    {
        private string accent;
        private string dbpath;
        public SettingsWindow()
        {
            InitializeComponent();
            this.Loaded += SettingsWindow_Loaded;
            this.BackgroundList.SelectionChanged += BackgroundList_SelectionChanged;
        }

        private void BackgroundList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.BackgroundList.SelectedItem.Equals("Light"))
            {
                Properties.Settings.Default.MainBackground = Color.White.Name;
                Properties.Settings.Default.FooterBackground = "#DCD9DF";
                Properties.Settings.Default.MenuBackground = Color.White.Name;
                Properties.Settings.Default.BackgroundTextColor = Color.DarkGray.Name;
            }
            else
            {
                Properties.Settings.Default.MainBackground = "#FFE0E0E0";
                Properties.Settings.Default.FooterBackground = Color.DarkGray.Name;
                Properties.Settings.Default.MenuBackground = Color.LightGray.Name;
                Properties.Settings.Default.BackgroundTextColor = Color.LightGray.Name;
            }
        }

        private void OnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Escape && this.IsLoaded && this.IsActive)
            {
                args.Handled = true;
                Properties.Settings.Default.Reload();
                this.Close();
            }
        }
        private void SettingsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            EventManager.RegisterClassHandler(typeof(SettingsWindow), Keyboard.PreviewKeyDownEvent, new KeyEventHandler(OnKeyDown), true);
            this.DBLocationPath.Text = Properties.Settings.Default.DBFilePath;
            dbpath = this.DBLocationPath.Text;
            this.PopulateImageTypes();
            this.PopulateAccent();
            this.PopulateBackgrounds();
            this.PopulateTagPaneItems();
            this.LanguagesList.Items.Add("English");
            this.LanguagesList.Items.Add("German");
            this.LanguagesList.SelectedItem = Settings.Default.Language;
        }

        private void PopulateTagPaneItems()
        {
            this.TagPaneList.Items.Add("Left(smaller screens)");
            this.TagPaneList.Items.Add("Right");
            if (Settings.Default.ShowTagsOnLeft)
            {
                this.TagPaneList.SelectedItem = this.TagPaneList.Items[0];
            }
            else
            {
                this.TagPaneList.SelectedItem = this.TagPaneList.Items[1];
            }
        }

        private void PopulateAccent()
        {
            accent = Properties.Settings.Default.Accent;
            foreach (var _accent in ThemeManager.DefaultAccents)
            {
                accentlist.Items.Add(_accent);
                if (_accent.Name == accent)
                {
                    accentlist.SelectedItem = _accent;
                }
            }
        }

        private void PopulateBackgrounds()
        {
            this.BackgroundList.Items.Add("Light");
            this.BackgroundList.Items.Add("Dark");
            if (Properties.Settings.Default.MainBackground.Equals(Color.White.ToString()))
            {
                this.BackgroundList.SelectedItem = this.BackgroundList.Items[0].ToString();
            }
            else
            {
                this.BackgroundList.SelectedItem = this.BackgroundList.Items[1].ToString();
            }
        }
        private void PopulateImageTypes()
        {
            list.Items.Add(".jpg");
            list.Items.Add(".png");
            list.Items.Add(".gif");
            list.Items.Add(".bmp");
            list.Items.Add(".tif");
            list.Items.Add(".jpeg");
            list.Items.Add(".tiff");

            var supportedtypes = Properties.Settings.Default.Supportedfiletypes;
            foreach (var item in supportedtypes)
            {
                list.SelectedItems.Add(item);
            }
        }

        private async void OnSave(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Accent = ((Accent)accentlist.SelectedItem).Name;
            foreach (string str in list.SelectedItems)
            {
                if (!Properties.Settings.Default.Supportedfiletypes.Contains(str))
                {
                    Properties.Settings.Default.Supportedfiletypes.Add(str);
                }
            }

            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            this.Close();

            if (Properties.Settings.Default.Accent != accent || this.DBLocationPath.Text != dbpath)
            {
                MetroWindow window = (MetroWindow)App.Current.MainWindow;
                var result = await window.ShowMessageAsync("Reset Powerpic", "Theme / DB Path changes need app restart. Do you really want to restart the app?", MessageDialogStyle.AffirmativeAndNegative);
                if (result == MessageDialogResult.Affirmative)
                {
                    System.Diagnostics.Process.Start(App.ResourceAssembly.Location);
                    App.Current.Shutdown();
                }
            }
        }

        private async void OnReset(object sender, RoutedEventArgs e)
        {
            this.Close();
            MetroWindow window = (MetroWindow)App.Current.MainWindow;

            var result = await window.ShowMessageAsync("Reset Powerpic", "Do you really want to reset the data?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                await new DataServiceProxy().DeleteAll();
                await window.ShowMessageAsync("Restart", "All data have been deleted successfully. The application will restart now.", MessageDialogStyle.Affirmative);
                System.Diagnostics.Process.Start(App.ResourceAssembly.Location);
                App.Current.Shutdown();
            }
        }

        private async void OnResetSettings(object sender, RoutedEventArgs e)
        {
            this.Close();
            MetroWindow window = (MetroWindow)App.Current.MainWindow;
            var result = await window.ShowMessageAsync("Reset Powerpic", "Do you want all settings to reset? The app will restart.", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                Properties.Settings.Default.Reset();
                System.Diagnostics.Process.Start(App.ResourceAssembly.Location);
                App.Current.Shutdown();
            }
        }

        private void DBLocationBrowse_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fdialog = new System.Windows.Forms.FolderBrowserDialog();
            fdialog.ShowNewFolderButton = true;

            if (fdialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string folderPath = fdialog.SelectedPath;
                this.DBLocationPath.Text = folderPath;
                Properties.Settings.Default.DBFilePath = folderPath;
                PicBro.Shell.Windows.Properties.Settings.Default.Save();
            }
        }

        private async void CleanupDatabase_Click(object sender, RoutedEventArgs e)
        {
            IDataServiceProxy idataServiceProxy = new DataServiceProxy();
            this.CleanupDatabase.Content = "CLEANUP DATABASE (Cleaning...Please wait.)";
            await idataServiceProxy.CleanupDataBase();
            this.CleanupDatabase.Content = "CLEANUP DATABASE";
            PicBro.Shell.Windows.Properties.Settings.Default.Save();
            this.Close();
            MetroWindow window = (MetroWindow)App.Current.MainWindow;
            var result = await window.ShowMessageAsync("Reset Powerpic", "Cleanup Database need app restart. Do you really want to restart the app?", MessageDialogStyle.AffirmativeAndNegative);
            if (result == MessageDialogResult.Affirmative)
            {
                System.Diagnostics.Process.Start(App.ResourceAssembly.Location);
                App.Current.Shutdown();
            }
        }

        private void TagPaneList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (this.TagPaneList.SelectedItem == this.TagPaneList.Items[0])
            {
                Settings.Default.ShowTagsOnLeft = true;
            }
            else
            {
                Settings.Default.ShowTagsOnLeft = false;
            }
        }

        private void Languages_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (LanguagesList.SelectedItem.Equals("English"))
            {
                CultureManager.UICulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                CultureManager.UICulture = new System.Globalization.CultureInfo("de-DE");
            }
            Settings.Default.Language = LanguagesList.SelectedItem.ToString();
        }
    }
}
