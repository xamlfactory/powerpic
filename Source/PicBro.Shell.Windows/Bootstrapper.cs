using Microsoft.Practices.Prism.UnityExtensions;
using System;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using PicBro.DAL.Windows;
using Microsoft.Practices.Prism.Regions;
using PicBro.Shell.Windows.Common;
using PicBro.Shell.Windows.Views;
using PicBro.Foundation.Windows.Infrastructure;

namespace PicBro.Shell.Windows
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            this.Container.RegisterType<IDataServiceProxy, DataServiceProxy>();
            this.Container.RegisterType<IThreadService, ThreadService>();
            this.Container.RegisterType<IDialogService, DialogService>();
            this.Container.RegisterType<INavigationService, NavigationService>();
            this.Container.RegisterType<IZipService, ZipService>();
            this.Container.RegisterType<IEMailService, EmailService>();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeModules()
        {
            base.InitializeModules();

            var region = this.Container.Resolve<IRegionManager>();
            region.RegisterViewWithRegion(RegionNames.MenuBarRegion, typeof(MenuBarView));
            region.RegisterViewWithRegion(RegionNames.MainContentRegion, typeof(ImageListView));
            region.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(FolderListView));
            region.RegisterViewWithRegion(RegionNames.MainContentRegion, typeof(ImageView));
            region.RegisterViewWithRegion(RegionNames.FooterRegion, typeof(FooterView));
            region.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(ImageDetailView));
            region.RegisterViewWithRegion(RegionNames.MenuBarRegion, typeof(ImageHeaderView));
            region.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(SearchDetailView));
            this.Container.RegisterType<Object, TagView>(ViewNames.TagView);
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }
    }
}
