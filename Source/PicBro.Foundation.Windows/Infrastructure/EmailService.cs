using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Infrastructure
{
    using PicBro.Foundation.Windows.Utils.EMailUtils;

    public class EmailService : IEMailService
    {
        public bool OpenStandardEmailClient(string attachmentPath="")
        {
            try
            {
                MapiMailMessage message = new MapiMailMessage("","");
                
                if(attachmentPath != string.Empty)
                    message.Files.Add(attachmentPath);
                message.ShowDialog();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
           
          
        }
    }
}
