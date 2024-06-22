using DotNetTask.Server.Domain.DTOs;
using System.Threading.Tasks;

namespace DotNetTask.Server.Interfaces.Queries
{
    public interface IFormQuery
    {
        Task<FormDTO> GetFormByIdAsync(Guid id);
    }
}