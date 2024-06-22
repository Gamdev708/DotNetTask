using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Commands
{
    public interface IFormProgramCommand
    {
        Task<int> Create(FormProgramDTO formdto);
        Task<int> CreateProgram(FormProgramDTO formdto);
        Task<int> Delete(Guid Id);
        Task<int> Update(FormProgramDTO formdto);
    }
}