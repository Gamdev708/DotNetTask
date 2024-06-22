using Microsoft.Azure.Cosmos;
using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Domain.Entities;
using DotNetTask.Server.Interfaces.Commands;
using DotNetTask.Server.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Application.Commands
{
    public class FormAnswersCommand : IFormAnswersCommand
    {
        private readonly DotNetTaskServerContext Context;

        public FormAnswersCommand(DotNetTaskServerContext context)
        {
            Context = context;
        }


        public async Task<int> BulkAddFormsAsync(IEnumerable<FormAnswersDTO> answers)
        {
            List<FormAnswers> formAnswers = new List<FormAnswers>();
            foreach (FormAnswersDTO answer in answers)
            {
                formAnswers.Add(new FormAnswers
                {
                    Answer = answer.Answer,
                    CreatedBy = answer.CreatedBy,
                    CreatedOn = answer.CreatedOn,
                    LastUpdatedBy = answer.LastUpdatedBy,
                    QuestionId = answer.QuestionId,
                    UpdatedOn = answer.UpdatedOn,
                });
            }

            await Context.FormAnswers.AddRangeAsync(formAnswers);
            return await Context.SaveChangesAsync();
        }


    }
}
