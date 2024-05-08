using Abp.Application.Services;
using EduVise.Services.CourseServices;
using EduVise.Services.LearnerCourseServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerCourseServices
{
    public interface ILearnerCourseAppService : IApplicationService
    {
        Task<LearnerCourseDto> CreateLearnerCourseAsync(LearnerCourseDto eventDto);
        Task<LearnerCourseDto> GetByLearnerCourseId(Guid id);
        Task<List<LearnerCourseDto>> GetAllLearnerCoursesAsync();
        Task<List<CourseDto>> GetAllCoursesForSpecificLearnerAsync(Guid id);
        Task<LearnerCourseDto> UpdateLearnerCourseAsync(LearnerCourseDto input);
        Task Delete(Guid id);
    }
}
