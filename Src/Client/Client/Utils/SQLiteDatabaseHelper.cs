using System.Data.SQLite;
using System.IO;
using System.Data;

namespace Client
{
    public class SQLiteDatabaseHelper
    {
        private string databasePath;
        private string connectionString;

        public SQLiteDatabaseHelper()
        {
            databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database.sqlite");
            connectionString = $"Data Source={databasePath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            // 如果数据库文件不存在，连接时会自动创建
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS Urls (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Url TEXT NOT NULL
                )";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        // 添加软件链接
        public void AddUrls(Urls url)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Urls (Name, Url) VALUES (@Name, @Url)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", url.Name);
                    command.Parameters.AddWithValue("@Url", url.Url);  // 修正了参数名
                    command.ExecuteNonQuery();
                }
            }
        }

        // 获取所有URL
        public List<Urls> GetAllUrls()
        {
            var urls = new List<Urls>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Urls";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        urls.Add(new Urls
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Url = reader["Url"].ToString(),
                        });
                    }
                }
            }
            return urls;
        }

        // 其他方法保持不变，但记得修正UpdateUrls中的参数名
        public void UpdateUrls(Urls url)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Urls SET Name = @Name, Url = @Url WHERE Id = @Id";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", url.Id);
                    command.Parameters.AddWithValue("@Name", url.Name);
                    command.Parameters.AddWithValue("@Url", url.Url);  // 修正了参数名
                    command.ExecuteNonQuery();
                }
            }
        }

        // ... 其他方法保持不变
    }
}