using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PicBro.DataModel.Windows;
using System.Collections.ObjectModel;

namespace PicBro.DAL.Windows
{
    public class DataServiceProxy : IDataServiceProxy
    {
        private SQLiteConnection connection = null;

        private const string descriptionPrefix = @"~";

        public SQLiteConnection Connection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteConnection("Data Source=" + filePath + ";Version=3;");
                }
                return connection;
            }
        }

        static string filePath = string.Empty;
        public bool InitializeDataBase(string folderPath)
        {

            string path = string.Empty;
            if (Directory.Exists(folderPath))
                path = folderPath;
            else
                path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Picbro\";

            filePath = path + @"\appdata.sqlite";

            if (File.Exists(filePath))
            {
                return false;
            }
            else
            {
                Directory.CreateDirectory(path);
                SQLiteConnection.CreateFile(filePath);

                return true;
            }
        }

        public async Task CreateImagesTable()
        {
            Connection.Open();
            string createimages = @"CREATE TABLE [Images] (
  [ID] INTEGER PRIMARY KEY AUTOINCREMENT, 
  [Name] varchar(255) NOT NULL, 
  [Path] varchar(255), 
  [ThumbDataSmall] BLOB, 
  [FolderID] int NOT NULL REFERENCES [Folders]([ID]) ON DELETE CASCADE ON UPDATE CASCADE, 
  [LastModifiedDate] DATE, 
  [Size] INTEGER, 
  [Height] DOUBLE, 
  [Width] DOUBLE, 
  [IsFavorite] int NOT NULL, 
  [Popularity] INT64 DEFAULT 0, 
  [ThumbDataMedium] BLOB, 
  [ThumbDataLarge] BLOB,
  [ThumbDataExtraLarge] BLOB);";

            SQLiteCommand command = new SQLiteCommand(createimages, connection);
            await command.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task CreateTagsTable()
        {
            Connection.Open();

            string createtags = @"CREATE TABLE Tags 
                                        (
                                            Name varchar(255) NOT NULL,
                                            ImageID INTEGER,
                                            FOREIGN KEY (ImageID) REFERENCES Images(ID) ON DELETE CASCADE ON UPDATE CASCADE
                                        )";


            SQLiteCommand command = new SQLiteCommand(createtags, connection);
            await command.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task CreateFoldersTable()
        {
            Connection.Open();

            string createfolders = @"CREATE TABLE [Folders] (
  [ID] INTEGER PRIMARY KEY AUTOINCREMENT, 
  [SortOrder] INTEGER,
  [Name] varchar(255) NOT NULL ON CONFLICT FAIL CONSTRAINT [NameUnique] UNIQUE ON CONFLICT IGNORE, 
  [Path] varchar(255) NOT NULL);";

            SQLiteCommand command = new SQLiteCommand(createfolders, connection);
            await command.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task<int> InsertFolder(string name, string path)
        {
            Connection.Open();

            int lastinsertedRow = -1;

            string createfolders = @"INSERT INTO Folders (SortOrder, Name, Path) SELECT COUNT(*) + 1, '" + name.Replace(@"'", @"''") + "', '" + path.Replace(@"'", @"''") + "' FROM Folders;";
            SQLiteCommand command = new SQLiteCommand(createfolders, connection);
            int ret = await command.ExecuteNonQueryAsync();
            if (ret > 0)
            {
                string lastinsertquery = "SELECT * FROM Folders ORDER BY ID DESC LIMIT 1";
                using (SQLiteCommand lastinsertcommand = new SQLiteCommand(lastinsertquery, connection))
                {
                    using (DbDataReader rdr = await lastinsertcommand.ExecuteReaderAsync())
                    {
                        while (rdr.Read())
                        {
                            lastinsertedRow = rdr.GetInt32(0);
                        }
                    }
                }
            }

            Connection.Close();

            return lastinsertedRow;
        }

        public async Task UpdateFolderSortOrderAsync(IEnumerable<FolderModel> folders)
        {
            int index = 1;
            StringBuilder updateQuery = new StringBuilder();
            updateQuery.AppendLine("BEGIN EXCLUSIVE TRANSACTION;");
            foreach (var item in folders)
            {
                updateQuery.AppendLine(string.Format("UPDATE Folders SET SortOrder = {0} WHERE ID = {1};", index, item.ID));
                index++;
            }
            updateQuery.AppendLine("COMMIT TRANSACTION;");
            connection.Open();
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery.ToString(), connection);
            await updateCommand.ExecuteNonQueryAsync();
            connection.Close();
        }
        public async Task UpdatePopularity(int imageId)
        {
            Connection.Open();
            string query = "UPDATE Images SET Popularity=Popularity+1 WHERE ID=@id";
            SQLiteCommand updateCommand = new SQLiteCommand(query, Connection);
            updateCommand.Parameters.Add(new SQLiteParameter("@id", imageId));
            await updateCommand.ExecuteNonQueryAsync();
            Connection.Close();
        }

        public async Task UpdateFavorite(int imageid, bool isfavorite)
        {
            Connection.Open();

            string query = "UPDATE Images SET IsFavorite=@favorite WHERE ID=@id";
            SQLiteCommand updateCommand = new SQLiteCommand(query, Connection);
            updateCommand.Parameters.Add(new SQLiteParameter("@id", imageid));
            updateCommand.Parameters.Add(new SQLiteParameter("@favorite", isfavorite ? 1 : 0));

            await updateCommand.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task<int> InsertImage(int lastinsertedRow, string path, byte[] smalldata, byte[] mediumdata = null, byte[] largedata = null, byte[] extralargeData = null)
        {
            Connection.Open();

            int lastinsertedImage = -1;

            string filename = Path.GetFileName(path);
            FileInfo info = new FileInfo(path);
            long size = info.Length;
            DateTime date = info.LastAccessTime;
            Image image = Image.FromFile(path);
            double width = image.Width;
            double height = image.Height;
            int favorite = 0;

            string insertimagequery = @"INSERT INTO Images (Name, Path, ThumbDataSmall, FolderID, LastModifiedDate, Size, Height, Width, IsFavorite,ThumbDataMedium,ThumbDataLarge,ThumbDataExtraLarge) 
            VALUES (@name, @path, @smalldata, @folderid, @date, @size, @height, @width, @favorite,@mediumdata,@largedata,@extralargedata)";
            SQLiteCommand insertimagecommand = new SQLiteCommand(insertimagequery, Connection);
            insertimagecommand.Parameters.Add(new SQLiteParameter("@name", filename));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@path", path));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@smalldata", smalldata));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@folderid", lastinsertedRow));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@date", date));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@size", size));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@height", height));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@width", width));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@favorite", favorite));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@mediumdata", mediumdata));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@largedata", largedata));
            insertimagecommand.Parameters.Add(new SQLiteParameter("@extralargedata", extralargeData));
            await insertimagecommand.ExecuteNonQueryAsync();

            string lastinsertquery = "SELECT * FROM Images ORDER BY ID DESC LIMIT 1";
            using (SQLiteCommand lastinsertcommand = new SQLiteCommand(lastinsertquery, connection))
            {
                using (DbDataReader rdr = await lastinsertcommand.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        lastinsertedImage = rdr.GetInt32(0);
                    }
                }
            }

            Connection.Close();

            return lastinsertedImage;
        }

        public async Task InsertTag(string name, int imageId)
        {
            Connection.Open();

            string inserttag = "INSERT INTO Tags (Name, ImageID) VALUES (@name, @imageId);";

            SQLiteCommand command = new SQLiteCommand(inserttag, connection);
            command.Parameters.Add(new SQLiteParameter("@name", name));
            command.Parameters.Add(new SQLiteParameter("@imageId", imageId));

            await command.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task UpdateDescription(int imageId, string description)
        {
            Connection.Open();

            string updatedes = @"UPDATE Tags SET Name = @name WHERE ImageId = @imageId AND Name LIKE '" + descriptionPrefix + "%';";


            SQLiteCommand command = new SQLiteCommand(updatedes, connection);
            command.Parameters.Add(new SQLiteParameter("@name", descriptionPrefix + description));
            command.Parameters.Add(new SQLiteParameter("@imageId", imageId));

            int result = await command.ExecuteNonQueryAsync();

            if (result <= 0)
            {
                string insertdes = @"INSERT OR IGNORE INTO Tags (Name, ImageID) VALUES (@name, @imageId);";
                command = new SQLiteCommand(insertdes, connection);
                command.Parameters.Add(new SQLiteParameter("@name", descriptionPrefix + description));
                command.Parameters.Add(new SQLiteParameter("@imageId", imageId));
                await command.ExecuteNonQueryAsync();
            }

            Connection.Close();
        }

        public async Task<List<DataModel.Windows.ImageModel>> GetAllImages(int folderID)
        {
            List<ImageModel> list = new List<ImageModel>();

            Connection.Open();

            string createfolders = @"SELECT * FROM Images WHERE FolderID = @id";

            if (folderID == -1)
            {
                createfolders = @"SELECT * FROM Images WHERE IsFavorite = 1";
            }

            using (SQLiteCommand cmd = new SQLiteCommand(createfolders, Connection))
            {
                cmd.Parameters.Add(new SQLiteParameter("@id", folderID));

                using (DbDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        ImageModel image = new ImageModel();
                        image.ID = rdr.GetInt32(0);
                        image.Name = rdr.GetString(1);
                        image.Path = rdr.GetString(2);
                        image.ThumbDataSmall = (byte[])rdr[3];
                        image.LastModifiedDate = rdr.GetDateTime(5);
                        image.Size = Convert.ToInt32(rdr.GetValue(6));
                        image.Height = rdr.GetDouble(7);
                        image.Width = rdr.GetDouble(8);
                        image.IsFavorite = rdr.GetInt32(9) == 0 ? false : true;
                        image.Popularity = rdr.GetInt64(10);
                        image.ThumbDataMedium = (byte[])rdr[11];
                        image.ThumbDataLarge = (byte[])rdr[12];
                        image.ThumbDataExtraLarge = (byte[])rdr[13];
                        list.Add(image);
                    }
                }
            }

            Connection.Close();
            return list;
        }

        public async Task<List<DataModel.Windows.ImageModel>> GetAllImages(string searchQuery, bool includeTag = true, bool includeDescription = true, bool isFavoritesOnly = false)
        {
            List<ImageModel> list = new List<ImageModel>();

            Connection.Open();

            string[] tags = searchQuery.Split(',');
            string images = String.Empty;

            for (int i = 0; i < tags.Length; i++)
            {
                string getimages = @"SELECT DISTINCT ImageId FROM Tags WHERE ";

                getimages += "Name LIKE @tag" + i + " COLLATE NOCASE ";

                if (includeDescription && includeTag)
                    getimages += "OR Name LIKE @tagd" + i + " COLLATE NOCASE ";
                //if (i != tags.Length - 1)
                //    getimages += "AND ";

                using (SQLiteCommand tagcmd = new SQLiteCommand(getimages, Connection))
                {
                    if (includeDescription && includeTag)
                    {
                        tagcmd.Parameters.Add(new SQLiteParameter("@tag" + i, tags[i].Trim() + "%"));
                        tagcmd.Parameters.Add(new SQLiteParameter("@tagd" + i, descriptionPrefix + "%" + tags[i].Trim() + "%"));
                    }
                    else if (includeTag)
                    {
                        tagcmd.Parameters.Add(new SQLiteParameter("@tag" + i, tags[i].Trim() + "%"));
                    }
                    else if (includeDescription)
                    {
                        tagcmd.Parameters.Add(new SQLiteParameter("@tag" + i, descriptionPrefix + "%" + tags[i].Trim() + "%"));
                    }

                    using (DbDataReader rdr = await tagcmd.ExecuteReaderAsync())
                    {
                        while (rdr.Read())
                        {
                            images += rdr.GetInt64(0) + ",";
                        }
                    }
                }
            }

            var query = from c in images.Split(',')
                        group c by c into g
                        where g.Count() > 1
                        select new { Item = g.Key, ItemCount = g.Count() };

            List<string> imageIDs = new List<string>();

            if (tags.Length > 1)
            {
                var queries = from item in query
                              where item.ItemCount == tags.Length
                              select item;

                foreach (var value in queries)
                {
                    imageIDs.Add(value.Item.ToString());
                }
            }
            else
            {
                imageIDs = images.Split(',').ToList();
            }

            foreach (var c in imageIDs)
            {
                string getimage = @"SELECT * FROM Images WHERE ID = @id";

                if (isFavoritesOnly)
                    getimage += " AND IsFavorite=1;";

                using (SQLiteCommand cmd = new SQLiteCommand(getimage, Connection))
                {
                    cmd.Parameters.Add(new SQLiteParameter("@id", c));

                    using (DbDataReader rdr = await cmd.ExecuteReaderAsync())
                    {
                        while (rdr.Read())
                        {
                            ImageModel image = new ImageModel();
                            image.ID = rdr.GetInt32(0);
                            image.Name = rdr.GetString(1);
                            image.Path = rdr.GetString(2);
                            image.ThumbDataSmall = (byte[])rdr[3];
                            image.LastModifiedDate = rdr.GetDateTime(5);
                            image.Size = rdr.GetInt32(6);
                            image.Height = rdr.GetDouble(7);
                            image.Width = rdr.GetDouble(8);
                            image.IsFavorite = rdr.GetInt32(9) == 0 ? false : true;
                            image.Popularity = rdr.GetInt64(10);
                            image.ThumbDataMedium = (byte[])rdr[11];
                            image.ThumbDataLarge = (byte[])rdr[12];
                            image.ThumbDataExtraLarge = (byte[])rdr[13];
                            list.Add(image);
                        }
                    }
                }
            }

            Connection.Close();
            return list;
        }

        public async Task DeleteAll()
        {
            Connection.Open();

            string delete = @"DELETE FROM Tags; DELETE FROM Images; DELETE FROM Folders";
            SQLiteCommand command = new SQLiteCommand(delete, Connection);
            await command.ExecuteNonQueryAsync();

            Connection.Close();
        }

        public async Task<bool> RemoveSelectedFolder(int selectedFolderId)
        {
            Connection.Open();
            try
            {
                string removefolders = @"PRAGMA foreign_keys = ON; DELETE FROM Folders WHERE ID = @id";
                SQLiteCommand command = new SQLiteCommand(removefolders, Connection);
                command.Parameters.Add(new SQLiteParameter("@id", selectedFolderId));
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

        }

        public async Task<bool> CleanupDataBase()
        {
            Connection.Open();
            try
            {
                string selectFolders = @"SELECT Id,Path FROM Folders";

                using (SQLiteCommand cmd = new SQLiteCommand(selectFolders, Connection))
                {
                    using (DbDataReader rdr = await cmd.ExecuteReaderAsync())
                    {
                        while (rdr.Read())
                        {
                            int folderId = rdr.GetInt32(0);
                            string folderPath = rdr.GetString(1);
                            if (Directory.Exists(folderPath))
                            {
                                string selectImages = @"SELECT Id,Path FROM Images WHERE FolderId= @fId";
                                using (SQLiteCommand imgcmd = new SQLiteCommand(selectImages, Connection))
                                {
                                    imgcmd.Parameters.Add(new SQLiteParameter("@fId", folderId));
                                    using (DbDataReader imgrdr = await imgcmd.ExecuteReaderAsync())
                                    {
                                        while (imgrdr.Read())
                                        {
                                            int imageId = imgrdr.GetInt32(0);
                                            string imagePath = imgrdr.GetString(1);
                                            if (File.Exists(imagePath))
                                            {
                                                continue;
                                            }
                                            else
                                            {
                                                string removeImage = @"PRAGMA foreign_keys = ON; DELETE FROM Images WHERE ID = @id";
                                                SQLiteCommand imgcommand = new SQLiteCommand(removeImage, Connection);
                                                imgcommand.Parameters.Add(new SQLiteParameter("@id", imageId));
                                                await imgcommand.ExecuteNonQueryAsync();
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string removefolder = @"PRAGMA foreign_keys = ON; DELETE FROM Folders WHERE ID = @id";
                                SQLiteCommand command = new SQLiteCommand(removefolder, Connection);
                                command.Parameters.Add(new SQLiteParameter("@id", folderId));
                                await command.ExecuteNonQueryAsync();
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return false;
        }

        private byte[] CreateThumbnailBytes(byte[] originalImage)
        {
            Image thumbnail = null;

            Image tempImage = Image.FromStream(new MemoryStream(originalImage));

            int desiredWidth = 120;

            int newPixelWidth = tempImage.Width;
            int newPixelHeight = tempImage.Height;

            if (newPixelWidth > desiredWidth)
            {
                float resizePercent = 0F;

                if (newPixelHeight > newPixelWidth)
                {
                    resizePercent = ((float)desiredWidth / (float)tempImage.Height);
                }
                else
                {
                    resizePercent = ((float)desiredWidth / (float)tempImage.Width);
                }

                newPixelWidth = (int)(tempImage.Width * resizePercent) + 1;
                newPixelHeight = (int)(tempImage.Height * resizePercent) + 1;
            }

            Bitmap bitmap = new Bitmap(newPixelWidth, newPixelHeight);

            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(tempImage, 0, 0, newPixelWidth, newPixelHeight);
            }

            thumbnail = (Image)bitmap;

            MemoryStream ms = new MemoryStream();
            thumbnail.Save(ms, ImageFormat.Jpeg);

            return ms.ToArray();
        }

        public async Task<List<DataModel.Windows.FolderModel>> GetAllFolders()
        {
            List<FolderModel> list = new List<FolderModel>();

            Connection.Open();

            string createfolders = @"SELECT * FROM Folders ORDER BY SortOrder ASC";

            using (SQLiteCommand cmd = new SQLiteCommand(createfolders, Connection))
            {
                using (DbDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        FolderModel folder = new FolderModel();
                        folder.ID = rdr.GetInt32(0);
                        folder.SortOrder = rdr.GetInt32(1);
                        folder.Name = rdr.GetString(2);
                        folder.Path = rdr.GetString(3);
                        list.Add(folder);
                    }
                }
            }

            Connection.Close();
            return list;
        }

        public async Task<string> GetTagsForImage(int imageId)
        {
            Connection.Open();

            StringBuilder tagsEntries = new StringBuilder();

            string tags = @"SELECT Name FROM Tags WHERE ImageId = @id AND Name NOT LIKE '" + descriptionPrefix + "%'"; ;

            using (SQLiteCommand cmd = new SQLiteCommand(tags, Connection))
            {
                cmd.Parameters.Add(new SQLiteParameter("@id", imageId));

                using (DbDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    bool flag = false;
                    while (rdr.Read())
                    {
                        if (flag)
                            tagsEntries.Append(",");
                        tagsEntries.Append(rdr.GetString(0));
                        flag = true;
                    }
                }
            }

            Connection.Close();
            return tagsEntries.ToString();
        }

        public async Task<string> GetDescriptionForImage(int imageId)
        {
            Connection.Open();

            StringBuilder tagsEntries = new StringBuilder();

            string tags = @"SELECT Name FROM Tags WHERE ImageId = @id AND Name LIKE '" + descriptionPrefix + "%'";

            using (SQLiteCommand cmd = new SQLiteCommand(tags, Connection))
            {
                cmd.Parameters.Add(new SQLiteParameter("@id", imageId));

                using (DbDataReader rdr = await cmd.ExecuteReaderAsync())
                {
                    while (rdr.Read())
                    {
                        tagsEntries.Append(rdr.GetString(0).Remove(0, descriptionPrefix.Length));
                    }
                }
            }

            Connection.Close();
            return tagsEntries.ToString();
        }

        public async Task<bool> RemoveTag(string tag)
        {
            Connection.Open();
            try
            {
                string removeTags = "DELETE FROM Tags WHERE Name = @tag";
                SQLiteCommand command = new SQLiteCommand(removeTags, Connection);
                command.Parameters.Add(new SQLiteParameter("@tag", tag));
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public async Task<bool> RemoveTagForImage(int imageId, string tag)
        {
            Connection.Open();
            try
            {
                string removefolders = @"DELETE FROM Tags WHERE ImageId = @id AND Name LIKE @tag";
                SQLiteCommand command = new SQLiteCommand(removefolders, Connection);
                command.Parameters.Add(new SQLiteParameter("@id", imageId));
                command.Parameters.Add(new SQLiteParameter("@tag", tag));
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

        }

        public async Task<bool> RemoveAllTags(int imageId)
        {
            Connection.Open();
            try
            {
                string removefolders = @"DELETE FROM Tags WHERE ImageId = @id AND Name NOT LIKE '" + descriptionPrefix + "%'"; ;
                SQLiteCommand command = new SQLiteCommand(removefolders, Connection);
                command.Parameters.Add(new SQLiteParameter("@id", imageId));
                await command.ExecuteNonQueryAsync();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }


        public async Task<ObservableCollection<ManageTagsModel>> GetTags(int start, int end)
        {
            ObservableCollection<ManageTagsModel> result = new ObservableCollection<ManageTagsModel>();
            try
            {
                Connection.Open();
                string sqlCommand = "SELECT DISTINCT Name FROM Tags LIMIT " + start.ToString() + ", " + end.ToString();
                SQLiteCommand cmd = new SQLiteCommand(sqlCommand, Connection);
                using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        ManageTagsModel manageModel = new ManageTagsModel();
                        manageModel.Tag = reader.GetString(0);
                        string countCommand = "select COUNT(*) from Tags where Name=@name";
                        SQLiteCommand countCmd = new SQLiteCommand(countCommand, Connection);
                        countCmd.Parameters.Add(new SQLiteParameter("@name", manageModel.Tag));
                        using (DbDataReader countReader = await countCmd.ExecuteReaderAsync())
                        {
                            while (countReader.Read())
                            {
                                manageModel.Images = countReader.GetInt32(0);
                            }
                        }
                        result.Add(manageModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                Connection.Close();
            }
            return result;

        }

        public async Task<ObservableCollection<ManageTagsModel>> SearchTag(string tag)
        {
            ObservableCollection<ManageTagsModel> result = new ObservableCollection<ManageTagsModel>();
            try
            {
                Connection.Open();
                string sqlCommand = @"SELECT  Name FROM Tags  WHERE Name LIKE '" + tag + "%'";
                SQLiteCommand cmd = new SQLiteCommand(sqlCommand, Connection);
                using (DbDataReader reader = await cmd.ExecuteReaderAsync())
                {
                    while (reader.Read())
                    {
                        ManageTagsModel manageModel = new ManageTagsModel();
                        manageModel.Tag = reader.GetString(0);
                        string countCommand = "select COUNT(*) from Tags where Name=@name";
                        SQLiteCommand countCmd = new SQLiteCommand(countCommand, Connection);
                        countCmd.Parameters.Add(new SQLiteParameter("@name", manageModel.Tag));
                        using (DbDataReader countReader = await countCmd.ExecuteReaderAsync())
                        {
                            while (countReader.Read())
                            {
                                manageModel.Images = countReader.GetInt32(0);
                            }
                        }
                        result.Add(manageModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return result;
            }
            finally
            {
                Connection.Close();
            }
            return result;

        }
    }
}
