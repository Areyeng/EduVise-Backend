using Abp.Application.Services;
using EduVise.Services.QuestionServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.QuestionServices
{
    public interface IQuestionsAppService : IApplicationService
    {
        Task<QuestionDto> CreateQuestionAsync(QuestionDto input);
        Task<QuestionDto> GetByQuestionId(Guid id);
        Task<List<QuestionDto>> GetAllQuestionsAsync();
        Task<QuestionDto> UpdateQuestionAsync(QuestionDto input);
        Task Delete(Guid id);
    }
}
