using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public interface IEMailService
    {
        bool OpenStandardEmailClient(string attachmentPath);       
    }
}
