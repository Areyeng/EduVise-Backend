using System.Threading.Tasks;
using EduVise.Configuration.Dto;

namespace EduVise.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
