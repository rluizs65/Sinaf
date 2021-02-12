using Base.Core.Settings;
using Microsoft.Extensions.Options;
using System.Linq;

namespace Base.Core.GlobalConfigurations
{
    public class BaseGlobalConfiguration : IBaseGlobalConfiguration
    {
        private AppSettings _appSetting { get; set; }

        public BaseGlobalConfiguration(IOptions<AppSettings> appsetting)
        {
            _appSetting = appsetting.Value;
        }

        public DbConnection GetDbConnection(string name)
        {
            return _appSetting.DbConnections.Where(x => x.Name == name).FirstOrDefault();
        }

        public string GetTimeoutConnection()
        {
            return _appSetting.TimeoutConnection;
        }

        public string GetSchema(string name)
        {
            return _appSetting.DbConnections.Where(x => x.Name == name).FirstOrDefault().Schema;
        }
    }
}
