using System.Collections.Generic;

namespace Base.Core.Settings
{
    public class AppSettings
    {
        public List<DbConnection> DbConnections { get; set; }
        public string TimeoutConnection { get; set; }
    }

    public class DbConnection
    {
        public string Name { get; set; }
        public string Schema { get; set; }
        public string ConnectionString { get; set; }
        public string ConnectionEncrypted { get; set; }
        public string DbType { get; set; }
    }
}
