using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public class ThreadService : IThreadService
    {
        public void DoBackgroundWork(DoWorkEventHandler work, RunWorkerCompletedEventHandler oncompleted, object parameter = null)
        {
            var worker = new BackgroundWorker();
            worker.DoWork += work;
            worker.RunWorkerCompleted += oncompleted;
            worker.RunWorkerAsync(parameter);
        }
    }
}
