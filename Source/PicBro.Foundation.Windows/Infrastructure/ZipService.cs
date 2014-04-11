using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace PicBro.Foundation.Windows.Infrastructure
{
    public class ZipService : IZipService
    {
        public string GetZipFile(List<string> paths)
        {
            try
            {
                string zipFileName = "picbromail.zip";
                string localFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string zipFilepath = localFolder + @"\Picbro\" + zipFileName;
                if (File.Exists(zipFilepath))
                    File.Delete(zipFilepath);
                using (ZipArchive zip = ZipFile.Open(zipFilepath, ZipArchiveMode.Create))
                {
                    foreach (var path in paths)
                    {
                        if (File.Exists(path))
                        {
                            FileInfo finfo = new FileInfo(path);
                            zip.CreateEntryFromFile(path, finfo.Name);
                        }
                    }
                }
                return zipFilepath;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }
    }
}
