using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public interface INavigationService
    {
        void NavigateTo(string regionname, string viewname);
        void ClearViews(string regionName);
    }
}
