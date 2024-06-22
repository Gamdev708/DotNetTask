using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Queries
{
    public interface IFormProgramQuery
    {
        Task<IEnumerable<FormProgramDTO>> GetProgram();
        Task<FormProgramDTO> GetProgramById(Guid Id);
    }
}