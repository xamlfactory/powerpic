using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace PicBro.DataModel.Windows
{
    public class ManageTagsModel : INotifyPropertyChanged
    {

        private string tag;

        public string Tag
        {
            get
            {
                return tag;
            }
            set
            {
                tag = value;
                this.RaisePropertyChanged("Tag");
            }
        }


        private int images;

        public int Images
        {
            get
            {
                return images;
            }
            set
            {
                images = value;
                this.RaisePropertyChanged("Images");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
