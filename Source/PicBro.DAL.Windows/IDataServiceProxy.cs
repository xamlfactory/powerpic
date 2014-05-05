using System.Collections.Generic;
using System.Threading.Tasks;
using PicBro.DataModel.Windows;
using System.Collections.ObjectModel;

namespace PicBro.DAL.Windows
{
    public interface IDataServiceProxy
    {
        bool InitializeDataBase(string folderPath);

        Task CreateFoldersTable();

        Task CreateTagsTable();

        Task CreateImagesTable();

        Task<int> InsertFolder(string name, string path);

        Task<List<FolderModel>> GetAllFolders();

        Task<List<DataModel.Windows.ImageModel>> GetAllImages(int folderID);

        Task<List<DataModel.Windows.ImageModel>> GetAllImages(string searchQuery, bool includeTag = true, bool includeDescription = false, bool isFavoritesOnly = false);

        Task<int> InsertImage(int lastinsertedRow, string path, byte[] smalldata, byte[] mediumdata, byte[] largedata, byte[] extralargeData);

        Task DeleteAll();

        Task<bool> RemoveSelectedFolder(int folderID);

        Task InsertTag(string name, int imageId);

        Task<string> GetTagsForImage(int imageId);

        Task<bool> RemoveTagForImage(int imageId, string tag);

        Task<string> GetDescriptionForImage(int imageId);

        Task UpdateDescription(int imageId, string description);

        Task<bool> RemoveAllTags(int imageId);

        Task UpdateFavorite(int imageid, bool isfavorite);

        Task UpdatePopularity(int imageId);

        Task<ObservableCollection<ManageTagsModel>> GetTags(int start, int end);

        Task<bool> RemoveTag(string tag);

        Task<ObservableCollection<ManageTagsModel>> SearchTag(string tag);

        Task<bool> CleanupDataBase();
        Task UpdateFolderSortOrderAsync(IEnumerable<FolderModel> folders);
    }
}
