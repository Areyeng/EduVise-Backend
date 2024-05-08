using Abp.Application.Services;
using EduVise.Services.ResponseServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.ResponseServices
{
    public interface IResponseAppService : IApplicationService
    {
        Task<ResponseDto> CreateLearnerResponseAsync(ResponseDto responseDto);
        //Task<ResponseDto> GetByLearnerId(Guid id);
        //Task<List<ResponseDto>> GetAllLearnerResponsesAsync();
        //Task<ResponseDto> UpdateResponseAsync(ResponseDto input);
        //Task Delete(Guid id);
    }
}
