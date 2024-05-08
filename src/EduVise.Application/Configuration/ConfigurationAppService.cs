using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using EduVise.Configuration.Dto;

namespace EduVise.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : EduViseAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
