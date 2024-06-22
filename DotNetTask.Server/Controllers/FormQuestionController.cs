using Microsoft.AspNetCore.Mvc;
using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Interfaces.Commands;
using DotNetTask.Server.Interfaces.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormQuestionController : ControllerBase
    {
        private readonly IFormQuestionsCommand _command;
        private readonly IFormQuestionsQuery _query;

        public FormQuestionController(IFormQuestionsCommand command, IFormQuestionsQuery query)
        {
            _command = command;
            _query = query;
        }

        // GET: api/<FormQuestionController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FormQuestionController>/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<FormQuestionDTO>> Get(Guid id)
        {
            return await _query.GetFormQuestions(id);
        }

        // POST api/<FormQuestionController>
        [HttpPost]
        public async Task Post([FromBody] FormQuestionDTO questionDTO)
        {
            await _command.Create(questionDTO);
        }

        // POST api/<FormQuestionController>
        [Route("PostBulk")]
        [HttpPost]
        public async Task PostBulk([FromBody] List<FormQuestionDTO> questionDTOs)
        {
            await _command.CreateBulk(questionDTOs);
        }

        // PUT api/<FormQuestionController>/5
        [HttpPut]
        public async Task Put([FromBody] FormQuestionDTO questionDTO)
        {
            await _command.Update(questionDTO);
        }

        // DELETE api/<FormQuestionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _command.Delete(id);
        }
    }
}
