using Abp.Application.Services;
using EduVise.Services.LearnerSkillServices.Dtos;
using EduVise.Services.ResponseServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.LearnerSkillServices
{
    public interface ILearnerSkillAppService : IApplicationService
    {
        Task<LearnerSkillDto> CreateLearnerSkillsAsync(LearnerSkillDto responseDto);
       
    }
}
