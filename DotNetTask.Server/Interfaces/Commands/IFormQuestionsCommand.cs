
using DotNetTask.Server.Domain.DTOs;

namespace DotNetTask.Server.Interfaces.Commands
{
    public interface IFormQuestionsCommand
    {
        Task<int> Create(FormQuestionDTO questions);
        Task<int> CreateBulk(List<FormQuestionDTO> questions);
        Task<int> Delete(Guid Id);
        Task<int> Update(FormQuestionDTO questions);
    }
}