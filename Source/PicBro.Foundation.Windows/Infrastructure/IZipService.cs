using System.Collections.Generic;

namespace PicBro.Foundation.Windows.Infrastructure
{
   public interface IZipService
    {
       string GetZipFile(List<string> paths);      
    }
}
