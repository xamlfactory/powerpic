using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public interface IDialogService
    {
        void LaunchDialog<T>(string title, object viewmodel);

        void CloseDialog();
    }
}
