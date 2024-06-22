using DotNetTask.Server.Interfaces.Queries;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Domain.Entities;
using DotNetTask.Server.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace DotNetTask.Server.Application.Queries
{
    public class FormAnswersQuery : IFormAnswersQuery
    {
        private readonly DotNetTaskServerContext Context;

        public FormAnswersQuery(DotNetTaskServerContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<FormAnswersDTO>> GetFormAnswers(Guid[] ids)
        {
            List<FormAnswers> formAnswers = await Context.FormAnswers.Where(x => ids.Contains(x.Id)).ToListAsync();
            List<FormAnswersDTO> dTOs = new List<FormAnswersDTO>();
            foreach (var formanswer in formAnswers)
            {
                dTOs.Add(new FormAnswersDTO
                {
                    Answer = formanswer.Answer,
                    CreatedBy = formanswer.CreatedBy,
                    CreatedOn = formanswer.CreatedOn,
                    Id = formanswer.Id,
                    LastUpdatedBy = formanswer.LastUpdatedBy,
                    QuestionId = formanswer.QuestionId,
                    UpdatedOn = formanswer.UpdatedOn,
                });
            }
            return dTOs;
        }

    }
}

