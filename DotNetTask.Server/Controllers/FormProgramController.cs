using Microsoft.AspNetCore.Mvc;
using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Interfaces.Commands;
using DotNetTask.Server.Interfaces.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DotNetTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormProgramController : ControllerBase
    {
        private readonly IFormProgramCommand _command;
        private readonly IFormProgramQuery _query;

        public FormProgramController(IFormProgramCommand command, IFormProgramQuery query)
        {
            _command = command;
            _query = query;
        }

        // GET: api/<FormProgramController>
        [HttpGet]
        public async Task<IEnumerable<FormProgramDTO>> Get()
        {
            return await _query.GetProgram();
        }

        // GET api/<FormProgramController>/5
        [HttpGet("{id}")]
        public async Task<FormProgramDTO> Get(Guid id)
        {
            try
            {
                return await _query.GetProgramById(id);

            }
            catch (Exception ex)
            {
                return null;
                // Log the exception
            }
        }

        // POST api/<FormProgramController>
        [HttpPost]
        public async Task Post([FromBody] FormProgramDTO program)
        {
            //await _command.Create(program);
            await _command.CreateProgram(program);
        }

        // PUT api/<FormProgramController>/5
        [HttpPut]
        public async Task Put([FromBody] FormProgramDTO program)
        {
            await _command.Update(program);
        }

        // DELETE api/<FormProgramController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _command.Delete(id);
                return Ok("Program deleted successfully.");
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
