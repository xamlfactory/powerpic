using MahApps.Metro.Controls;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using PicBro.DAL.Windows;
using PicBro.DataModel.Windows;
using PicBro.Foundation.Windows.Infrastructure;
using PicBro.Shell.Windows.ViewModels;
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
        IThreadService threadService;

        public ManageTagsWindow(IDataServiceProxy dataService, IThreadService threadservice, IEventAggregator eventAggregator,INavigationService navigationService)
        {
            InitializeComponent();
            this.DataContext = new ManageTagsViewModel(dataService,threadservice,eventAggregator,navigationService);
            this.Loaded += ManageTagsWindow_Loaded;
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            base.OnPreviewKeyUp(e);
            if(e.Key == Key.Escape)
            {
                this.Close();
            }
        }

        void ManageTagsWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var scroll = GetScrollbar(tags_grid);
            scroll.ScrollChanged += scroll_ScrollChanged;            
            ((ManageTagsViewModel)this.DataContext).OnNavigatedTo(null);
        }
      

        void scroll_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if(e.VerticalOffset > 0 && e.ViewportHeight + e.VerticalOffset == e.ExtentHeight)
            {
                ((ManageTagsViewModel)this.DataContext).RequestTags();
            }
        }

        private static ScrollViewer GetScrollbar(DependencyObject dep)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(dep); i++)
            {
                var child = VisualTreeHelper.GetChild(dep, i);
                if (child != null && child is ScrollViewer)
                    return child as ScrollViewer;
                else
                {
                    ScrollViewer sub = GetScrollbar(child);
                    if (sub != null)
                        return sub;
                }
            }
            return null;
        }
        
    }
}
