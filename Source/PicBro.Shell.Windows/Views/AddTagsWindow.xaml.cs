using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Events;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using PicBro.Shell.Windows.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
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

namespace PicBro.Shell.Windows.Views
{
    /// <summary>
    /// Interaction logic for AddTagsWindow.xaml
    /// </summary>
    public partial class AddTagsWindow : MetroWindow
    {
        IEnumerable selectedImages;
        IDataServiceProxy dataService;
        public AddTagsWindow()
        {
            InitializeComponent();
        }
       

        public AddTagsWindow(IEventAggregator eventagregator,IDataServiceProxy dataservice,object selectedImages)
        {
            InitializeComponent();
            this.selectedImages = selectedImages as IEnumerable;
            this.dataService = dataservice;
            this.tagsTextBox.Focus();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.selectedImages != null && this.dataService != null)
            {
                string[] tags = this.tagsTextBox.Text.Split(',');
                for (int i = 0; i < tags.Length; i++)
                {
                    foreach (ImageModel selectediamge in selectedImages)
                    {
                        if (selectediamge != null)
                        {
                            if (! string.IsNullOrEmpty(tags[i]))
                            {
                                this.dataService.InsertTag(tags[i].Trim(), selectediamge.ID);
                            }
                        }
                    }
                }
            }
            this.Close();
        }
    }
}
