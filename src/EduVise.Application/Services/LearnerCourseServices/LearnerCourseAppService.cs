using Abp.Application.Services;
using Abp.Domain.Repositories;
using Abp.UI;
using EduVise.Domain;
using EduVise.Services.CourseServices;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.FundingServices.Dtos;
using EduVise.Services.LearnerCourseServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerCourseServices
{
    public class LearnerCourseAppService : ApplicationService,ILearnerCourseAppService
    {
        private readonly IRepository<LearnerCourse,Guid> _learnercourseRepository;
        private readonly IRepository<Learner, Guid> _learnerRepository;
        private readonly IRepository<Course, Guid> _courseRepository;
        public LearnerCourseAppService (IRepository<LearnerCourse, Guid> learnercourseRepository, IRepository<Learner, Guid> learnerRepository, IRepository<Course, Guid> courseRepository)
        {
            _learnercourseRepository =  learnercourseRepository;
            _learnerRepository = learnerRepository;
            _courseRepository = courseRepository;

        }
        //Create
        [HttpPost]
        public async Task<LearnerCourseDto> CreateLearnerCourseAsync(LearnerCourseDto input)
        {
            var learner = _learnerRepository.Get(input.LearnerId) ?? throw new Exception("learner does not exist!");
            var course = _courseRepository.Get(input.CourseId) ?? throw new Exception("course does not exist!");
            var learnercourse = new LearnerCourse
            {
                Learner = learner,
                Course = course,
            };
            await _learnercourseRepository.InsertAsync(learnercourse);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerCourseDto>(learnercourse);
        }
        //GetbyId
        [HttpGet]
        public async Task<LearnerCourseDto> GetByLearnerCourseId(Guid id)
        {
            var course = await _learnercourseRepository.GetAllIncluding(e => e.Learner, e => e.Course)
                                           .FirstOrDefaultAsync(e => e.Id == id);


            if (course == null)
            {
                throw new UserFriendlyException("course not found!");
            }
            return ObjectMapper.Map<LearnerCourseDto>(course);
        }
        //GetAll
        [HttpGet]
        public async Task<List<LearnerCourseDto>> GetAllLearnerCoursesAsync()
        {
            var learnercourse = await _learnercourseRepository.GetAllIncluding(x => x.Learner,x=>x.Course).ToListAsync();
            return ObjectMapper.Map<List<LearnerCourseDto>>(learnercourse);
        }
        public async Task<List<CourseDto>> GetAllCoursesForSpecificLearnerAsync(Guid id)
        {
            var learnerCourses = await _learnercourseRepository.GetAllIncluding(e => e.Learner, e => e.Course)
                                                .Where(e => e.Learner.Id == id)
                                                .ToListAsync();

            if (learnerCourses == null || learnerCourses.Count == 0)
            {
                throw new UserFriendlyException("No learnercourses found for the provided ID!");
            }

            // Extract institution IDs
            var institutionIds = learnerCourses.Select(li => li.Course.Id).ToList();

            // Fetch corresponding institutions
            var courses = await _courseRepository.GetAll().Where(i => institutionIds.Contains(i.Id)).ToListAsync();

            return ObjectMapper.Map<List<CourseDto>>(courses);
        }
        //Update
        [HttpPut]
        public async Task<LearnerCourseDto> UpdateLearnerCourseAsync(LearnerCourseDto input)
        {
            var learner = _learnerRepository.Get(input.LearnerId) ?? throw new Exception("learner does not exist!");
            var course = _courseRepository.Get(input.CourseId) ?? throw new Exception("course does not exist!");
            var learnercourse = new LearnerCourse
            {
                Learner = learner,
                Course = course,
            };
            var update = await _learnercourseRepository.UpdateAsync(ObjectMapper.Map(input, learnercourse));

            return ObjectMapper.Map<LearnerCourseDto>(update);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _learnercourseRepository.DeleteAsync(id);
        }
    }
}
