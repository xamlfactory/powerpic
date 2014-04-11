using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PicBro.DataModel.Windows
{
    public class ImageModel : INotifyPropertyChanged
    {
        public ImageModel()
        {
        }
        public int ID { get; set; }

        public string Name { get; set; }

        public byte[] ThumbDataSmall { get; set; }

        public byte[] ThumbDataMedium { get; set; }

        public byte[] ThumbDataLarge { get; set; }

        public byte[] ThumbDataExtraLarge { get; set; }

        public string Path { get; set; }

        public int Size { get; set; }

        public double Width { get; set; }

        public double Height { get; set; }
        private bool isFavorite;

        public bool IsFavorite
        {
            get { return isFavorite; }
            set { isFavorite = value; RaisePropertyChanged("IsFavorite"); }
        }
        private ObservableCollection<string> tags;

        public ObservableCollection<string> Tags
        {
            get { return tags; }
            set { tags = value; RaisePropertyChanged("Tags"); }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = String.IsNullOrEmpty(value) ? null : value; RaisePropertyChanged("Description"); }
        }

        private long popularity;

        public long Popularity
        {
            get { return popularity; }
            set { popularity = value; }
        }

        private ThumbSize imageThumbSize;

        public ThumbSize ImageThumbSize
        {
            get { return imageThumbSize; }
            set { imageThumbSize = value; RaisePropertyChanged("ImageThumbSize"); }
        }


        public DateTime LastModifiedDate { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
