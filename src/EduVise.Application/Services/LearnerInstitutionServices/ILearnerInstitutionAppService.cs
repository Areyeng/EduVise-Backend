using Abp.Application.Services;
using EduVise.Services.InstitutionServices.Dtos;
using EduVise.Services.LearnerInstitutionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerInstitutionServices
{
    public interface ILearnerInstitutionAppService : IApplicationService
    {
        Task<LearnerInstitutionDto> CreateLearnerInstitutionAsync(LearnerInstitutionDto eventDto);
        Task<LearnerInstitutionDto> GetByLearnerInstitutionId(Guid id);
        Task<List<LearnerInstitutionDto>> GetAllLearnerInstitutionsAsync();
        Task<List<InstitutionDto>> GetAllInstitutionsForSpecificLearnerAsync(Guid id);
        Task<LearnerInstitutionDto> UpdateLearnerInstitutionAsync(LearnerInstitutionDto input);
        Task Delete(Guid id);
    }
}
