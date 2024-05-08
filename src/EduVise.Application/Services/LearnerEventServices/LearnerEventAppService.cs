using Abp.Application.Services;
using Abp.Domain.Repositories;
using AutoMapper.Internal.Mappers;
using EduVise.Domain;
using EduVise.Services.LearnerEventServices.Dtos;
using EduVise.Services.LearnerEventServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EduVise.Services.LearnerCourseServices.Dtos;
using Microsoft.EntityFrameworkCore;
using Abp.UI;
using EduVise.Services.FundingServices.Dtos;
using EduVise.Services.EventServices.Dtos;

namespace EduVise.Services.LearnerEventServices
{
    public class LearnerEventAppService : ApplicationService, ILearnerEventAppService
    {
        private readonly IRepository<LearnerEvent, Guid> _learnereventRepository;
        private readonly IRepository<Learner, Guid> _learnerRepository;
        private readonly IRepository<Event, Guid> _eventRepository;
        public LearnerEventAppService(IRepository<LearnerEvent, Guid> learnereventRepository, IRepository<Learner, Guid> learnerRepository, IRepository<Event, Guid> eventRepository)
        {
            _learnereventRepository = learnereventRepository;
            _learnerRepository = learnerRepository;
            _eventRepository = eventRepository;
        }
        //Create
        [HttpPost]
        public async Task<LearnerEventDto> CreateLearnerEventAsync(LearnerEventDto input)
        {
            var learner = _learnerRepository.Get(input.LearnerId) ?? throw new Exception("learner does not exist!");
            var events = _eventRepository.Get(input.EventId) ?? throw new Exception("course does not exist!");
            var learnerevent = new LearnerEvent
            {
                Learner = learner,
                Event= events,
            };
            await _learnereventRepository.InsertAsync(learnerevent);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerEventDto>(learnerevent);
        }
        //GetbyId
        [HttpGet]
        public async Task<LearnerEventDto> GetByLearnerEventId(Guid id)
        {
           
           var learnerevent = await _learnereventRepository.GetAllIncluding(e => e.Learner, e => e.Event)
                                           .FirstOrDefaultAsync(e => e.Id == id);
            if (learnerevent == null)
            {
                throw new UserFriendlyException("learner's event not found!");
            }
            return ObjectMapper.Map<LearnerEventDto>(learnerevent);
        }
        //GetAll
        [HttpGet]
        public async Task<List<LearnerEventDto>> GetAllLearnerEventsAsync()
        {
            var learnerevent= await _learnereventRepository.GetAllIncluding(x => x.Learner, x => x.Event).ToListAsync();
            return ObjectMapper.Map<List<LearnerEventDto>>(learnerevent);
        }
        public async Task<List<EventDto>> GetAllEventsForSpecificLearnerAsync(Guid id)
        {
            var learnerEvents = await _learnereventRepository.GetAllIncluding(e => e.Learner, e => e.Event)
                                                .Where(e => e.Learner.Id == id)
                                                .ToListAsync();

            if (learnerEvents == null || learnerEvents.Count == 0)
            {
                throw new UserFriendlyException("No learnerfunding found for the provided ID!");
            }

            // Extract institution IDs
            var eventIds = learnerEvents.Select(li => li.Event.Id).ToList();

            // Fetch corresponding institutions
            var events = await _eventRepository.GetAll().Where(i => eventIds.Contains(i.Id)).ToListAsync();

            return ObjectMapper.Map<List<EventDto>>(events);
        }
        //Update
        [HttpPut]
        public async Task<LearnerEventDto> UpdateLearnerEventAsync(LearnerEventDto input)
        {
            var learnereventinput = ObjectMapper.Map<LearnerEvent>(input);
            learnereventinput = await _learnereventRepository.UpdateAsync(learnereventinput);
            await CurrentUnitOfWork.SaveChangesAsync();
            return ObjectMapper.Map<LearnerEventDto>(learnereventinput);
        }
        //Delete
        [HttpDelete]
        public async Task Delete(Guid id)
        {
            await _learnereventRepository.DeleteAsync(id);
        }
    }
}
