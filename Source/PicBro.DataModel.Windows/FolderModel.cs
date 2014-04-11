using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicBro.DataModel.Windows
{
    public class FolderModel
    {
        public string Name { get; set; }

        public string Path { get; set; }

        public int ID { get; set; }

        public int SortOrder { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
