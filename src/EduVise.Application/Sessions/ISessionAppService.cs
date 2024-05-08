using System.Threading.Tasks;
using Abp.Application.Services;
using EduVise.Sessions.Dto;

namespace EduVise.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
