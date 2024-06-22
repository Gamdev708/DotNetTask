using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Interfaces.Commands;
using DotNetTask.Server.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormAnswersController : ControllerBase
    {
        private readonly IFormAnswersCommand _command;
        private readonly IFormAnswersQuery _query;

        public FormAnswersController(IFormAnswersCommand command, IFormAnswersQuery query)
        {
            _command = command;
            _query = query;
        }


        // GET: api/<FormAnswersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FormAnswersController>/5
        //[HttpGet("{id}")]
        //public async string Get(int id)
        //{

        //    return await _query.GetFormAnswers(id);
        //}

        // POST api/<FormAnswersController>
        [HttpPost]
        public async void Post([FromBody] List<FormAnswersDTO> answersDTOs)
        {
            await _command.BulkAddFormsAsync(answersDTOs);
        }

        // PUT api/<FormAnswersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] FormAnswersDTO[] answersDTOs)
        {
        }

        // DELETE api/<FormAnswersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
