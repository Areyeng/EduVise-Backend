using Abp.Application.Services;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.LearnerSkillServices.Dtos;
using EduVise.Services.ResponseServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.FacultyServices
{
    public interface IFacultyAppService : IApplicationService
    {
        Task<FacultyDto> CreateFacultyAsync(FacultyDto faculty);
        Task<List<FacultyDto>> GetFacultiesBySkills(ResponseDto input);
        Task<FacultyDto> GetByFacultyId(Guid id);
        Task<List<FacultyDto>> GetAllFacultiesAsync();
        Task<FacultyDto> UpdateFacultyAsync(FacultyDto input);
        Task Delete(Guid id);
    }
}
