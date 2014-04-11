using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PicBro.Shell.Windows.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for FolderProperties.xaml
    /// </summary>
    public partial class FolderPropertiesDialog : MetroWindow
    {
        public FolderPropertiesDialog()
        {
            InitializeComponent();
            this.Loaded += FolderProperties_Loaded;
        }

        void FolderProperties_Loaded(object sender, RoutedEventArgs args)
        {
            DirectoryInfo dinfo = new DirectoryInfo(Tag.ToString());
            this.Title = dinfo.Name;
            this.Dispatcher.BeginInvoke((Action) (()=>
            {
                var supported = Properties.Settings.Default.Supportedfiletypes;
                string filetypes = "";
                foreach (string str in supported)
                {
                    string str1 = str.Insert(0, "*");
                    string str2 = str1.Insert(str1.Length, "|");
                    filetypes += str2;
                }

                string[] MultipleFilters = filetypes.Split('|');

                int imgCount = 0;
                long size = 0L;
                foreach (string FileFilter in MultipleFilters)
                {
                    string[] images= Directory.GetFiles(Tag.ToString(), FileFilter, SearchOption.AllDirectories);
                    imgCount += images.Count();
               
                    foreach(var item in images)
                    {                        
                        FileInfo finfo = new FileInfo(item);
                        size += finfo.Length;
                    }                  

                }
                this.ImageCount.Text = imgCount.ToString();
                this.TotalSize.Text = ((size / 1024f) / 1014f).ToString("N2") + "MB";

            }));
        
            EventManager.RegisterClassHandler(typeof(FolderPropertiesDialog), Keyboard.PreviewKeyDownEvent, new KeyEventHandler(OnKeyDown), true);
        }
        private void OnKeyDown(object sender, KeyEventArgs args)
        {
            if (args.Key == Key.Escape && this.IsLoaded && this.IsActive)
            {
                args.Handled = true;
                this.Close();
            }
        }      
    }
}
