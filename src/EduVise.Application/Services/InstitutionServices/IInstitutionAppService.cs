using Abp.Application.Services;
using EduVise.Services.InstitutionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EduVise.Services.InstitutionServices
{
    public interface IInstitutionAppService : IApplicationService
    {
        Task<InstitutionDto> CreateInstitutionAsync(InstitutionDto input);
        Task<InstitutionDto> GetByInstitutionId(Guid id);
        Task<List<InstitutionDto>> GetAllInstitutionsAsync();
        Task<List<InstitutionDto>> GetAllInstitutionsByClosingAsync();
        Task<InstitutionDto> UpdateInstitutionAsync(InstitutionDto input);
        Task Delete(Guid id);
    }
}
