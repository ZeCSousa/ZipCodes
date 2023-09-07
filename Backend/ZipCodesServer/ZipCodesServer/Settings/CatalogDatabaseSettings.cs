using static ZipCodesServer.Settings.CatalogDatabaseSettings;

namespace ZipCodesServer.Settings
{
    public class CatalogDatabaseSettings : ICatalogDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string CollectionName { get; set; }
    }
}
