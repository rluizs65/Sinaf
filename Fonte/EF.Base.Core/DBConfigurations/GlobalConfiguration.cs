using Microsoft.Extensions.Options;
using Base.Core.Settings;
using Base.Core.GlobalConfigurations;

namespace EF.Base.Core.DBConfigurations
{
    public class GlobalConfiguration : BaseGlobalConfiguration, IGlobalConfiguration
    {
        private AppSettings _appSetting { get; set; }

        public GlobalConfiguration(IOptions<AppSettings> appsetting) : base(appsetting)
        {
            _appSetting = appsetting.Value;
        }
    }
}
