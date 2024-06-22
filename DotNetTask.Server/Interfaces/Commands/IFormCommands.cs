using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Commands
{
    public interface IFormCommands
    {
        Task<int> Create(FormDTO formdto);
        Task<int> Update(FormDTO formdto);
        Task<int> Delete(Guid Id);
    }
}