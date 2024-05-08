using Abp.Application.Services;
using Abp.Domain.Repositories;
using EduVise.Domain;
using EduVise.Services.LearnerFacultyServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.InstitutionFacultyServices
{
    public class InstitutionFacultyAppService : ApplicationService
    {
        private readonly IRepository<InstitutionFaculty, Guid> _institutionfacultyRepository;
        private readonly IRepository<Faculty, Guid> _facultyRepo;
        private readonly IRepository<Institution, Guid> _institutionRepo;
        public InstitutionFacultyAppService(IRepository<InstitutionFaculty, Guid> institutionfacultyRepository, IRepository<Faculty, Guid> facultyRepo, IRepository<Institution, Guid> institutionRepo)
        {
            _institutionfacultyRepository = institutionfacultyRepository;
            _facultyRepo = facultyRepo;
            _institutionRepo = institutionRepo;
        }
        //Create
        [HttpPost]
        public async Task<InstitutionFacultyDto> CreateAsync(InstitutionFacultyDto input)
        {
            var faculty = await _facultyRepo.GetAsync((Guid)input.FacultyId);
            var institution = await _institutionRepo.GetAsync((Guid)(input.InstitutionId));
            var payload = new InstitutionFaculty
            {
                Institution = institution,
                Faculty = faculty,
            };
            var response = await _institutionfacultyRepository.InsertAsync(payload);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<InstitutionFacultyDto>(response);
        }
    }
}
