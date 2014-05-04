using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Commands;
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

        #region Properties

        #region Tags

        public ObservableCollection<ManageTagsModel> Tags
        {
            get { return (ObservableCollection<ManageTagsModel>)GetValue(TagsProperty); }
            set { SetValue(TagsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Tags.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TagsProperty =
            DependencyProperty.Register("Tags", typeof(ObservableCollection<ManageTagsModel>), typeof(ManageTagsWindow), new PropertyMetadata(null));

        #endregion

        #region SearchCommand



        public DelegateCommand SearchCommand
        {
            get { return (DelegateCommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(DelegateCommand), typeof(ManageTagsWindow), new PropertyMetadata(null));
        
        #endregion

        #region SearchText

        public string SearchText
        {
            get { return (string)GetValue(SearchTextProperty); }
            set { SetValue(SearchTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SearchText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SearchTextProperty =
            DependencyProperty.Register("SearchText", typeof(string), typeof(ManageTagsWindow), new PropertyMetadata(string.Empty));
        
        #endregion

        #region ClearSearchCommand




        public DelegateCommand ClearSearchCommand
        {
            get { return (DelegateCommand)GetValue(ClearSearchCommandProperty); }
            set { SetValue(ClearSearchCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ClearSearchCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ClearSearchCommandProperty =
            DependencyProperty.Register("ClearSearchCommand", typeof(DelegateCommand), typeof(ManageTagsWindow), new PropertyMetadata(null));

        

        #endregion



        #endregion



        private IDataServiceProxy dataService;
        public ManageTagsWindow()
        {
            InitializeComponent();
        }
        public ManageTagsWindow(IDataServiceProxy dataservice)
        {
            InitializeComponent();
            this.IntializeCommands();
            this.DataContext = this;
            this.dataService = dataservice;
            GetAllTags();

        }

        private void GetAllTags()
        {
            var tags = this.dataService.GetTags();
            this.Tags = new ObservableCollection<ManageTagsModel>(tags.Result.OrderByDescending(tag => tag.Images));
        }

        private void IntializeCommands()
        {
            this.SearchCommand = new DelegateCommand(this.OnSearchCommand);
            this.ClearSearchCommand = new DelegateCommand(this.GetAllTags);
        }

        private void OnSearchCommand()
        {
            var searchedTags = this.dataService.SearchTag(this.SearchText);
            this.Tags = new ObservableCollection<ManageTagsModel>(searchedTags.Result.OrderByDescending(tag => tag.Images));

        }

        private void tagList_KeyUp(object sender, KeyEventArgs e)
        {
            var selectedTags = new ObservableCollection<string>(this.tags_grid.SelectedItems.OfType<ManageTagsModel>().Select(selecteditem => selecteditem.Tag)); 
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
