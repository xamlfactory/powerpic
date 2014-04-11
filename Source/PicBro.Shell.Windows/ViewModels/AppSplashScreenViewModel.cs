namespace PicBro.Shell.Windows.ViewModels
{
    using Microsoft.Practices.Prism.ViewModel;
    public sealed class AppSplashScreenViewModel : NotificationObject
    {
        private int progress;
        private string message;

        public int Progress
        {
            get { return this.progress; }
            set
            {
                this.progress = value;
                this.RaisePropertyChanged(() => this.Progress);
            }
        }

        public string Message
        {
            get { return this.message; }
            set
            {
                this.message = value;
                this.RaisePropertyChanged(() => this.Message);
            }
        }

    }
}
