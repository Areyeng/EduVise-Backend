using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.QuestionServices.Dtos;
using EduVise.Services.QuestionServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduVise.Services.QuestionServices
{
    public class QuestionAppService : ApplicationService, IQuestionsAppService
    {
        private readonly IRepository<Question, Guid> _questionRepository;
        public QuestionAppService(IRepository<Question, Guid> questionRepository)
        {
            _questionRepository = questionRepository;
        }
        //Create
        [HttpPost]
        public async Task<QuestionDto> CreateQuestionAsync(QuestionDto input)
        {
            var questioninput = ObjectMapper.Map<Question>(input);
            questioninput = await _questionRepository.InsertAsync(questioninput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<QuestionDto>(questioninput);
        }
        //GetbyId
        [HttpGet]
        public async Task<QuestionDto> GetByQuestionId(Guid id)
        {
            var questions = await _questionRepository.GetAsync(id);
            return ObjectMapper.Map<QuestionDto>(questions);
        }
        //GetAll
        [HttpGet]
        public async Task<List<QuestionDto>> GetAllQuestionsAsync()
        {
            var questions = await _questionRepository.GetAllListAsync();
            return ObjectMapper.Map<List<QuestionDto>>(questions);
        }
        //Update
        [HttpPut]
        public async Task<QuestionDto> UpdateQuestionAsync(QuestionDto input)
        {
            var questioninput = ObjectMapper.Map<Question>(input);
            questioninput = await _questionRepository.UpdateAsync(questioninput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<QuestionDto>(questioninput);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _questionRepository.DeleteAsync(id);
        }
    }
}
