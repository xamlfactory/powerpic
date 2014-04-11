using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicBro.Foundation.Windows.Utils
{
    using System.IO;
    using System.IO.IsolatedStorage;

    public class LocalStorageHelper
    {
        private static string importFolderName = "picbroimport.txt";

        private static string exportFolderName = "picbroexport.txt";

        public static void StoreFolderPath(string filedata,string folderType="import")
        {
            // For Writing
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string folderPath = path + @"\Picbro\";
                string filepath=string.Empty;
                filepath = folderPath + importFolderName;
                if (folderType.ToLower() == "export") filepath = folderPath + exportFolderName;

                if (File.Exists(filepath))
                {
                    TextWriter writer = new StreamWriter(new FileStream(filepath, FileMode.Truncate));
                    writer.WriteLine(filedata);
                    writer.Close();
                }
                else
                {
                    File.CreateText(filepath).Dispose();
                    using (TextWriter writer = new StreamWriter(new FileStream(filepath, FileMode.Truncate)))
                    {
                        writer.WriteLine(filedata);
                        writer.Close();
                    }
                }
            }
            catch (Exception e)
            {
                
            }
        }

        public static string GetFolderPath(string folderType="import")
        {
            try
            {

                string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                string folderPath = path + @"\Picbro\";
                string filepath = folderPath + importFolderName;
                if (folderType.ToLower() == "export") filepath = folderPath + exportFolderName;

                string returnData = string.Empty;

                if (File.Exists(filepath))
                {
                    using (TextReader reader = new StreamReader(new FileStream(filepath, FileMode.Open)))
                    {
                        returnData = reader.ReadLine();
                        reader.Close();
                    }
                }
                return returnData;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
            
        }
        
    }
}
