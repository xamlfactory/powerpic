using Infralution.Localization.Wpf;
using MahApps.Metro;
using PicBro.DAL.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.Properties;
using PicBro.Shell.Windows.ViewModels;
using PicBro.Shell.Windows.Views;
using PicBro.Shell.Windows.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PicBro.Shell.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private AppSplashScreen screen = new AppSplashScreen();

        private AppSplashScreenViewModel viewModel = new AppSplashScreenViewModel();

        private ThreadService thread = new ThreadService();

        private DataServiceProxy dataservice = new DataServiceProxy();
                
        protected override void OnStartup(StartupEventArgs e)
        {
            if(Settings.Default.Language.Equals("English"))
            {
                CultureManager.UICulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                CultureManager.UICulture = new System.Globalization.CultureInfo("de-DE");
            }

            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            TaskScheduler.UnobservedTaskException += TaskScheduler_UnobservedTaskException;
            base.OnStartup(e);
            string accent = PicBro.Shell.Windows.Properties.Settings.Default.Accent;
            ThemeManager.ChangeTheme(App.Current, ThemeManager.DefaultAccents.Where(t => t.Name == accent).FirstOrDefault(), Theme.Light);
            
            screen.DataContext = viewModel;
            screen.Show();
            thread.DoBackgroundWork(async (s, args) =>
            {
                string path = PicBro.Shell.Windows.Properties.Settings.Default.DBFilePath;
               
                if(path == null || path.Trim() == string.Empty)
                {                    
                    path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)+ @"\Picbro\";
                    PicBro.Shell.Windows.Properties.Settings.Default.DBFilePath = path;
                    PicBro.Shell.Windows.Properties.Settings.Default.Save();
                }
               
                viewModel.Message = "Creating database";
                if (dataservice.InitializeDataBase(path))
                {

                    viewModel.Message = "Creating folders table.";
                    await dataservice.CreateFoldersTable();

                    viewModel.Message = "Creating images table.";
                    await dataservice.CreateImagesTable();

                    viewModel.Message = "Creating tags table.";
                    await dataservice.CreateTagsTable();

                    viewModel.Message = "Initializing app...";
                }

                int progress = 0;
                while (progress < 100)
                {
                    progress++;
                    viewModel.Progress = progress;
                    Thread.Sleep(5);
                }

                viewModel.Message = "Done";
                Logger.Log("application loaded.");
            }, (o, args) =>
            {
                var boostrapper = new Bootstrapper();
                boostrapper.Run();
                screen.Close();

                if (Settings.Default.IsLoadingForFirstTime)
                {
                    var dialog = new ConfirmationDialog();
                    if (dialog.ShowDialog().GetValueOrDefault())
                    {
                        new TutorialView().Show();
                    }
                    Settings.Default.IsLoadingForFirstTime = false;
                }
            }, null);
        }

        void TaskScheduler_UnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            Logger.Log(e.Exception.Message, e.Exception.StackTrace);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Logger.Log("App Domain unhandle exception. IsTerminating : " + e.IsTerminating.ToString());
        }

        void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Logger.Log(e.Exception.Message, e.Exception.StackTrace);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            PicBro.Shell.Windows.Properties.Settings.Default.Save();
            Logger.Log("Application exit");
            base.OnExit(e);
        }
    }
}
