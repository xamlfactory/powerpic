using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Shell.Windows.Events
{
    public class ScanProgressChangedArgs
    {
        public byte[] Data { get; set; }

        public double Progress { get; set; }

        public string ProgressText { get; set; }
    }
}
