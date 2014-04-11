using MahApps.Metro.Controls;
using PicBro.DataModel.Windows;
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

namespace PicBro.Shell.Windows.Views.Export
{
    /// <summary>
    /// Interaction logic for ExportDialog.xaml
    /// </summary>
    public partial class ExportDialog : MetroWindow
    {
        public ExportDialog()
        {
            InitializeComponent();
            EventManager.RegisterClassHandler(typeof(ExportDialog), Keyboard.PreviewKeyDownEvent, new KeyEventHandler(OnKeyDown), true);

            if(Properties.Settings.Default.LastExportedDirectoryPath == string.Empty)
            {
               Properties.Settings.Default.LastExportedDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            }

            string date = DateTime.Now.ToString("yyyyMMdd");
            Properties.Settings.Default.LastExportedCollectionName = date + "-exported";
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key== Key.Escape && this.IsLoaded && this.IsActive)
            {
                e.Handled = true;
                this.Close();
            }
        }
     
        private void FolderBrowserButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            string previousFolderPath = Properties.Settings.Default.LastExportedDirectoryPath;
            if (previousFolderPath != null && previousFolderPath != string.Empty) dialog.SelectedPath = previousFolderPath.Trim();
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryInfo info = new DirectoryInfo(dialog.SelectedPath);
                Properties.Settings.Default.LastExportedDirectoryPath = dialog.SelectedPath;
            }         
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.DialogResult = true;
            this.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Save();
            this.DialogResult = false;
            this.Close();
        }

        
    }
}
