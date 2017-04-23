namespace Blog.MVC.Settings
{
    public class DatabaseSettings
    {
        public bool UseSQLite { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
    }

    public class ConnectionStrings
    {
        public string SQLConnectionString { get; set; }
        public string SQLiteConnectionString { get; set; }
    }
}