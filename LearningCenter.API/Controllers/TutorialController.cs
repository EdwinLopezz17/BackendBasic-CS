using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        
        public TutorialController(ITutorialInfraestructure tutorialInfraestructure,
            ITutorialDomain tutorialDomain)
        {
            _tutorialInfraestructure = tutorialInfraestructure;
            _tutorialDomain = tutorialDomain;
        }
        
        
        
        // GET: api/Tutorial
        [HttpGet]
        public async Task<List<Tutorial>> GetAsync()
        {
            return await _tutorialInfraestructure.GetAllAsync();
        }

        // GET: api/Tutorial/5
        [HttpGet("{id}", Name = "Get")]
        public TutorialResponse Get(int id)
        {
            Tutorial tutorial = _tutorialInfraestructure.GetById(id);
            
            //temporal
            TutorialResponse tutorialResponse = new TutorialResponse()
            {
                id = tutorial.id,
                name = tutorial.name,
                description = tutorial.description,
                maxLenght = tutorial.maxLenght,
            };

            return tutorialResponse;
        }

        // POST: api/Tutorial
        [HttpPost]
        public async void PostAsync ([FromBody] TutorialRequest tutorialRequest)
        {
            if (ModelState.IsValid)
            {
                //temporal
                Tutorial tutorial = new Tutorial()
                {
                    name = tutorialRequest.name,
                    description = tutorialRequest.description,
                    maxLenght = tutorialRequest.maxLenght,
                };
            
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
