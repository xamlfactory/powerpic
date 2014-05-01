using MahApps.Metro.Controls;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ManageTagsWindow.xaml
    /// </summary>
    public partial class ManageTagsWindow : MetroWindow
    {


        public ObservableCollection<ManageTagsModel> Tags
        {
            get { return (ObservableCollection<ManageTagsModel>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<ManageTagsModel>), typeof(ManageTagsWindow), new PropertyMetadata(null));



        private IDataServiceProxy dataService;
        public ManageTagsWindow()
        {
            InitializeComponent();
        }
        public ManageTagsWindow(IDataServiceProxy dataservice)
        {
            InitializeComponent();
            this.DataContext = this;
            this.dataService = dataservice;
            var tags = this.dataService.GetTags();
            this.Tags =tags.Result;
        }

        private void tagList_KeyUp(object sender, KeyEventArgs e)
        {
            var selectedTags = new ObservableCollection<string>(this.tagList.SelectedItems.OfType<ManageTagsModel>().Select(selecteditem => selecteditem.Tag)); 
            if (e.Key == Key.Delete)
            {
                var dialogResult = MessageBox.Show("Do you want to Remove Tag", "Remove Tag", MessageBoxButton.OKCancel);
                if (dialogResult == MessageBoxResult.OK)
                {
                    foreach (string item in selectedTags)
                    {
                        bool isSuccess = this.dataService.RemoveTag(item).Result;
                        if (isSuccess)
                        {
                            this.Tags.Remove(this.Tags.FirstOrDefault(tag => tag.Tag == item));
                        }
                    }
                }               
            }
        }

      
    }
}
