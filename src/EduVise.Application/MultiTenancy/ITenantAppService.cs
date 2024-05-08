using Abp.Application.Services;
using EduVise.MultiTenancy.Dto;

namespace EduVise.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

