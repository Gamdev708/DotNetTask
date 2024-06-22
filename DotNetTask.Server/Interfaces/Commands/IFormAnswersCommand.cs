using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Commands
{
    public interface IFormAnswersCommand
    {
        Task<int> BulkAddFormsAsync(IEnumerable<FormAnswersDTO> answers);
    }
}