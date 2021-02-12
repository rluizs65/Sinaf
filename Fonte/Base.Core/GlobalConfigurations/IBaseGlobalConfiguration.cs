using Base.Core.Settings;

namespace Base.Core.GlobalConfigurations
{
    public interface IBaseGlobalConfiguration
    {
        DbConnection GetDbConnection(string name);
        string GetSchema(string name);
        string GetTimeoutConnection();
    }
}
