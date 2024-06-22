using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Queries
{
    public interface IFormAnswersQuery
    {
        Task<IEnumerable<FormAnswersDTO>> GetFormAnswers(Guid[] ids);
    }
}