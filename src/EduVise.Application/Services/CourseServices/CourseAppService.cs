using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.UI;
using AutoMapper;
using AutoMapper.Execution;
using EduVise.Domain;
using EduVise.Services.EventServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduVise.Services.CourseServices
{
    public class CourseAppService : ApplicationService, ICourseAppService
    {
        private readonly IRepository<Course,Guid> _courseRepository;
        private readonly IRepository<Faculty,Guid> _facultyRepository;
        

        public CourseAppService(IRepository<Course,Guid> courseRepository, IRepository<Faculty, Guid> facultyRepository)
        {
            _courseRepository = courseRepository;//Dependency Injections
            _facultyRepository = facultyRepository; 

        }
        //Create
        [HttpPost]
        public async Task<CourseDto> CreateCourseAsync(CourseDto input)
        {
            
            var faculty = _facultyRepository.Get(input.FacultyId) ?? throw new Exception("faculty does not exist!");
            var course = new Course
            {
                Name = input.Name,
                Description = input.Description,
                FacultyName = input.FacultyName,
                JobTitles = input.JobTitles,
                AvgAPS = input.AvgAPS,
                AvgDuration = input.AvgDuration,
                AvgTuition = input.AvgTuition,
                Faculty = faculty,
            }; 
            await _courseRepository.InsertAsync(course);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<CourseDto>(course);
        }
        //GetbyId
        [HttpGet]
        public async Task<CourseDto> GetByCourseId(Guid id)
        {
            var course = await _courseRepository.GetAllIncluding(e => e.Faculty)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (course == null)
            {
                throw new UserFriendlyException("course not found!");
            }
            return ObjectMapper.Map<CourseDto>(course);
        }
        //GetAll
        [HttpGet]
        public async Task<List<CourseDto>> GetAllCoursesAsync()
        {
            var courses = await _courseRepository.GetAllIncluding(x => x.Faculty).ToListAsync();

            return ObjectMapper.Map<List<CourseDto>>(courses);
        }
        public async Task<List<CourseDto>> GetCoursesByFacultyIdAsync(Guid facultyId)
        {
            var courses = await _courseRepository.GetAllIncluding(x => x.Faculty)
                                                  .Where(x => x.Faculty.Id == facultyId)
                                                  .ToListAsync();

            return ObjectMapper.Map<List<CourseDto>>(courses);
        }

        //Update
        [HttpPut]
        public async Task<CourseDto> UpdateCourseAsync(CourseDto input)
        {
            var faculty = _facultyRepository.Get(input.FacultyId) ?? throw new Exception("faculty does not exist!");
            var course = new Course
            {
                Name = input.Name,
                Description = input.Description,
                FacultyName = input.FacultyName,
                JobTitles = input.JobTitles,
                AvgAPS = input.AvgAPS,
                AvgDuration = input.AvgDuration,
                AvgTuition = input.AvgTuition,
                Faculty = faculty,
            };

            var update = await _courseRepository.UpdateAsync(ObjectMapper.Map(input, course));

            return ObjectMapper.Map<CourseDto>(update);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _courseRepository.DeleteAsync(id);
        }


    }
}
