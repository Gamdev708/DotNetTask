using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Interfaces.Commands;
using DotNetTask.Server.Interfaces.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IFormCommands _command;
        private readonly IFormQuery _query;

        public FormController(IFormCommands command, IFormQuery query)
        {
            _command = command;
            _query = query;
        }

        // GET: api/<FormController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FormController>/5
        [HttpGet("{id}")]
        public async Task<FormDTO> Get(Guid id)
        {
            return await _query.GetFormByIdAsync(id);
        }

        // POST api/<FormController>
        [HttpPost]
        public async Task Post([FromBody] FormDTO form)
        {
            await _command.Create(form);
        }

        // PUT api/<FormController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] FormDTO form)
        {
            await _command.Update(form);
        }

        // DELETE api/<FormController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _command.Delete(id);
        }
    }
}
