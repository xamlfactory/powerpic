using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public interface IThreadService
    {
        void DoBackgroundWork(DoWorkEventHandler work, RunWorkerCompletedEventHandler oncompleted, object parameter = null);
    }
}
