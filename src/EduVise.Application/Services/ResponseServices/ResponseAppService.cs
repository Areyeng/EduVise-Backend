using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.ResponseServices.Dtos;
using EduVise.Services.ResponseServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduVise.Services.FacultyServices.Dtos;
using Microsoft.EntityFrameworkCore;

namespace EduVise.Services.ResponseServices
{
    public class ResponseAppService : ApplicationService
    {
        private readonly IRepository<Response, Guid> _responseRepository;
        private readonly IRepository<Faculty, Guid> _facultyRepository;
        public ResponseAppService(IRepository<Response, Guid> responseRepository)
        {
            _responseRepository = responseRepository;
        }
        //Create
        [HttpPost]
        public async Task<ResponseDto> CreateLearnerResponseAsync(ResponseDto input)
        {
            var responseinput = ObjectMapper.Map<Response>(input);
            responseinput = await _responseRepository.InsertAsync(responseinput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<ResponseDto>(responseinput);
        }

       
        
        ////GetAll
        //[HttpGet]
        //public async Task<List<ResponseDto>> GetAllResponsesAsync()
        //{
        //    var responses = await _responseRepository.GetAllListAsync();
        //    return ObjectMapper.Map<List<ResponseDto>>(responses);
        //}
        ////Update
        //[HttpPut]
        //public async Task<ResponseDto> UpdateResponseAsync(ResponseDto input)
        //{
        //    var responseinput = ObjectMapper.Map<Response>(input);
        //    responseinput = await _responseRepository.UpdateAsync(responseinput);
        //    await CurrentUnitOfWork.SaveChangesAsync();
        //    return ObjectMapper.Map<ResponseDto>(responseinput);
        //}
        ////Delete
        //[HttpDelete]
        //public async Task Delete(Guid id)
        //{
        //    await _responseRepository.DeleteAsync(id);
        //}
    }
}
