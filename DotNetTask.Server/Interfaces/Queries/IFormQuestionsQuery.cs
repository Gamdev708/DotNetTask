using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Queries
{
    public interface IFormQuestionsQuery
    {
        Task<IEnumerable<FormQuestionDTO>> GetFormQuestions(Guid id);
    }
}