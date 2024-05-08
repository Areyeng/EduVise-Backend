using System.Threading.Tasks;
using Abp.Application.Services;
using EduVise.Authorization.Accounts.Dto;

namespace EduVise.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
