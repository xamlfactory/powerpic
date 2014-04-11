namespace PicBro.Shell.Windows.ViewModels
{
    using System.Threading.Tasks;
    using MahApps.Metro.Controls;
    using MahApps.Metro.Controls.Dialogs;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using PicBro.Foundation.Windows.Infrastructure;
    using PicBro.Shell.Windows.Views;
    using PicBro.Shell.Windows.Views.About;
    public sealed class ShellViewModel : ViewModelBase
    {
        private DelegateCommand settingCommand;
        private DelegateCommand aboutCommand;
        private DelegateCommand launchTutorialCommand;
        public DelegateCommand LaunchTutorialCommand
        {
            get { return this.launchTutorialCommand; }
            private set { this.launchTutorialCommand = value; }
        }
        public DelegateCommand AboutCommand
        {
            get { return this.aboutCommand; }
            private set { this.aboutCommand = value; }
        }
        public DelegateCommand SettingCommand
        {
            get { return this.settingCommand; }
            private set { this.settingCommand = value; }
        }

        public ShellViewModel(
            IEventAggregator eventAggregator,
            INavigationService navigationService)
            : base(eventAggregator, navigationService)
        {
            this.SettingCommand = new DelegateCommand(this.OnSettingsCommandExecute);
            this.AboutCommand = new DelegateCommand(this.OnAboutCommandExecute);
            this.LaunchTutorialCommand = new DelegateCommand(this.OnLaunchTutorialCommandExecute);
        }

        private void OnLaunchTutorialCommandExecute()
        {
            new TutorialView().Show();
        }

        private void OnAboutCommandExecute()
        {
            new AboutDialog { Owner = App.Current.MainWindow }.Show();
        }
        private void OnSettingsCommandExecute()
        {
            new SettingsWindow { Owner = App.Current.MainWindow }.ShowDialog();
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
            
        }
    }
}
