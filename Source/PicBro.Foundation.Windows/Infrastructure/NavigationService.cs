using System;
using System.Linq;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public class NavigationService : INavigationService
    {
        private IRegionManager regionManager;

        public IRegionManager RegionManager
        {
            get
            {
                if (regionManager == null)
                {
                    regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
                }
                return regionManager;
            }
        }

        public void NavigateTo(string regionname, string viewname)
        {
            var region = RegionManager.Regions[regionname];
            Uri uri = new Uri(viewname, UriKind.Relative);
            region.RequestNavigate(uri, this.ThrowError);
        }

        private void ThrowError(NavigationResult obj)
        {

        }

        public void ClearViews(string regionName)
        {
            var region = RegionManager.Regions[regionName];
            foreach(var view in region.Views.ToList())
            {
                region.Remove(view);
            }
        }
    }
}
