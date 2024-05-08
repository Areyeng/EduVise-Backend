using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduVise.Authorization.Users;
using EduVise.Domain;
using EduVise.Services.CourseServices;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.FacultyServices.Dtos;
using EduVise.Services.ResponseServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.FacultyServices
{
    public class FacultyAppService : ApplicationService,IFacultyAppService
    {
        private readonly IRepository<Faculty,Guid> _facultyRepository;
        private readonly IRepository<Institution, Guid> _institutionRepository;

        public  FacultyAppService(IRepository<Faculty, Guid> facultyRepository, IRepository<Institution, Guid> institutionRepository)
        {
            _facultyRepository = facultyRepository;
            _institutionRepository = institutionRepository;
        }
        //Create
        [HttpPost]
        public async Task<FacultyDto> CreateFacultyAsync(FacultyDto input)
        {
            var institution = _institutionRepository.Get(input.InstitutionId) ?? throw new Exception("institution does not exist!");
            var faculty = new Faculty
            {
                Name = input.Name,
                Description = input.Description,
                RequiredSubjects = input.RequiredSubjects,
                Institution = institution,

            };
            await _facultyRepository.InsertAsync(faculty);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<FacultyDto>(faculty);
        }
        //GetbyId
        [HttpGet]
        public async Task<FacultyDto> GetByFacultyId(Guid id)
        {
            var faculty = await _facultyRepository.GetAsync(id);
            return ObjectMapper.Map<FacultyDto>(faculty);
        }
        //GetAll
        [HttpGet]
        public async Task<List<FacultyDto>> GetAllFacultiesAsync()
        {
            var faculties = await _facultyRepository.GetAllIncluding(x => x.Institution).ToListAsync();
            return ObjectMapper.Map<List<FacultyDto>>(faculties);
        }
        [HttpPost]
        public async Task<List<FacultyDto>> GetFacultiesBySkills([FromBody] ResponseDto input)
        {
            // Get all faculties
            var faculties = await _facultyRepository.GetAllIncluding(x => x.Institution).ToListAsync();

            // Calculate distance between input skills and faculties' skills
            var facultiesWithDistance = new List<Tuple<Faculty, double>>();
            foreach (var faculty in faculties)
            {
                // Calculate distance between input skills and faculty skills
                double distance = CalculateSkillDistance(input, faculty);

                // Add faculty and its distance to the list
                facultiesWithDistance.Add(new Tuple<Faculty, double>(faculty, distance));
            }

            // Select top 3 faculties with closest skill values
            var closestFaculties = facultiesWithDistance.OrderBy(x => x.Item2).Take(3).Select(x => x.Item1).ToList();

            // Return the closest faculties
            return ObjectMapper.Map<List<FacultyDto>>(closestFaculties);
            
            //Then add faculty id's to table (LearnerResponse)  
            
        }

        private double CalculateSkillDistance(ResponseDto inputFaculty, Faculty faculty)
        {
            // Calculate Euclidean distance between input skills and faculty skills
            double distance = 0;
            distance += Math.Pow(inputFaculty.CriticalThinking - faculty.CriticalThinking, 2);
            distance += Math.Pow(inputFaculty.ProblemSolving - faculty.ProblemSolving, 2);
            distance += Math.Pow(inputFaculty.EffectiveCommunication - faculty.EffectiveCommunication, 2);
            distance += Math.Pow(inputFaculty.HealthcareProficiency - faculty.HealthcareProficiency, 2);
            distance += Math.Pow(inputFaculty.InstructionalDesign - faculty.InstructionalDesign, 2);
            distance += Math.Pow(inputFaculty.LegalReasoning - faculty.LegalReasoning, 2);
            distance += Math.Pow(inputFaculty.Leadership - faculty.Leadership, 2);
            distance += Math.Pow(inputFaculty.EnvironmentalSustainability - faculty.EnvironmentalSustainability, 2);

            // Return the square root of the sum of squared differences
            return Math.Sqrt(distance);
        }

        //Update
        [HttpPut]
        public async Task<FacultyDto> UpdateFacultyAsync(FacultyDto input)
        {
            var institution = _institutionRepository.Get(input.InstitutionId) ?? throw new Exception("institution does not exist!");
            var faculty = new Faculty
            {
                Name = input.Name,
                Description = input.Description,
                RequiredSubjects = input.RequiredSubjects,
                Institution = institution,

            };
            var update = await _facultyRepository.UpdateAsync(ObjectMapper.Map(input, faculty));

            return ObjectMapper.Map<FacultyDto>(update);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _facultyRepository.DeleteAsync(id);
        }

    }
}
