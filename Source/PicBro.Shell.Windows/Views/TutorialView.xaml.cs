using System;
using System.IO;
using System.Windows;

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for TutorialView.xaml
    /// </summary>
    public partial class TutorialView : Window
    {
        public TutorialView()
        {
            InitializeComponent();
            this.webBrowser.Loaded += webBrowser_Loaded;
        }

        void webBrowser_Loaded(object sender, RoutedEventArgs e)
        {
            var myAssembly = System.Reflection.Assembly.GetEntryAssembly();
            var myAssemblyLocation = System.IO.Path.GetDirectoryName(myAssembly.Location);
            var myHtmlPath = Path.Combine(myAssemblyLocation, @"Help/help.html");
            webBrowser.Source = new Uri(myHtmlPath);
        }
    }
}
