using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.EntityFrameworkCore;
using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Domain.Entities;
using DotNetTask.Server.Interfaces.Queries;
using DotNetTask.Server.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Application.Queries
{
    public class FormQuestionsQuery : IFormQuestionsQuery
    {
        private readonly DotNetTaskServerContext Context;

        public FormQuestionsQuery(DotNetTaskServerContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<FormQuestionDTO>> GetFormQuestions(Guid id)
        {
            Form? form1 = await Context.Forms.FindAsync(id);
            List<FormQuestion> formQuestions = await Context.FormQuestions.Where(x => x.FormId == form1.Id).ToListAsync();
            List<FormQuestionDTO> dTOs = new List<FormQuestionDTO>();

            foreach (var form in formQuestions)
            {
                dTOs.Add(new FormQuestionDTO
                {
                    Id = form.Id,
                    CreatedOn = form.CreatedOn,
                    Answers = form.Answers,
                    MCQAnswers = form.QuestionType is FormQuestionType.DropDown or FormQuestionType.MCQ  ? FormQuestion.ConvertStringToAnswers(form.Answers): null,
                    CreatedBy = form.CreatedBy,
                    FormId = form.FormId,
                    Other = form.Other,
                    MaxChoice = form.MaxChoice,
                    IsRequired = form.IsRequired,
                    LastUpdatedBy = form.LastUpdatedBy,
                    QuestionType = (FormQuestionTypeDTO)form.QuestionType,
                    UpdatedOn = form.UpdatedOn,
                    Question = form.Question,
                });
            }

            return dTOs;

        }

    }
}
