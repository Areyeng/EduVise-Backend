using Abp.Application.Services;
using EduVise.Services.EventServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.CourseServices
{
    public interface ICourseAppService : IApplicationService
    {
        Task<CourseDto> CreateCourseAsync(CourseDto input);
        Task<CourseDto> GetByCourseId(Guid id);
        Task<List<CourseDto>> GetAllCoursesAsync();
        Task<List<CourseDto>> GetCoursesByFacultyIdAsync(Guid facultyId);
        Task<CourseDto> UpdateCourseAsync(CourseDto input);
        Task Delete(Guid id);

    }
}
