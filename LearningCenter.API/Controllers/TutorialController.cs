using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LearningCenter.API.Request;
using LearningCenter.API.Response;
using LearningCenter.Domain;
using LearningCenter.Infraestructure.Interfases;
using LearningCenter.Infraestructure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningCenter.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorialController : ControllerBase
    {

        private ITutorialInfraestructure _tutorialInfraestructure;
        private ITutorialDomain _tutorialDomain;
        private IMapper _mapper;
        
        public TutorialController(ITutorialInfraestructure tutorialInfraestructure,
            ITutorialDomain tutorialDomain, IMapper mapper)
        {
            _tutorialInfraestructure = tutorialInfraestructure;
            _tutorialDomain = tutorialDomain;
            _mapper = mapper;
        }
        
        
        
        // GET: api/Tutorial
        [HttpGet]
        public async Task<List<TutorialResponse>> GetAsync()
        {
            var tutorialList = await _tutorialInfraestructure.GetAllAsync();
            
            return _mapper.Map<List<Tutorial>, List<TutorialResponse>>(tutorialList);
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public TutorialResponse Get(int id)
        {
            Tutorial tutorial = _tutorialInfraestructure.GetById(id);

            var tutorialResponse = _mapper.Map<Tutorial, TutorialResponse>(tutorial);

            return tutorialResponse;
        }

        // POST: api/Tutorial
        [HttpPost]
        public async void PostAsync ([FromBody] TutorialRequest tutorialRequest)
        {
            if (ModelState.IsValid)
            {
                Tutorial tutorial = _mapper.Map<TutorialRequest, Tutorial>(tutorialRequest);
                await _tutorialDomain.saveAsync(tutorial);
            }
            else
            {
                StatusCode(400);
            }
            
        }

        // PUT: api/Tutorial/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            _tutorialDomain.update(id, value);
        }

        // DELETE: api/Tutorial/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _tutorialDomain.delete(id);
        }
    }
}
