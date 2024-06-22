using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using DotNetTask.Client.Pages;
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
    public class FormQuestionsCommand : IFormQuestionsCommand
    {
        private readonly DotNetTaskServerContext Context;

        public FormQuestionsCommand(DotNetTaskServerContext context)
        {
            Context = context;
        }


        public async Task<int> Create(FormQuestionDTO question)
        {

            var form = await Context.Forms.OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync();


            FormQuestion formQuestions = new FormQuestion
            {
                Answers = question.QuestionType is FormQuestionTypeDTO.DropDown or FormQuestionTypeDTO.MCQ? FormQuestion.ConvertAnswersToString(question.MCQAnswers) : question.Answers,
                Question = question.Question,
                CreatedBy = question.CreatedBy,
                CreatedOn = question.CreatedOn,
                Other = question.Other,
                MaxChoice = question.MaxChoice,
                FormId = form.Id,
                IsRequired = question.IsRequired,
                QuestionType = (FormQuestionType)question.QuestionType
            };



            await Context.FormQuestions.AddAsync(formQuestions);
            return await Context.SaveChangesAsync();
        }
        public async Task<int> CreateBulk(List<FormQuestionDTO> questions)
        {
            var form = await Context.Forms.OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync();
            List<FormQuestion> formQuestions = new List<FormQuestion>();
            foreach (FormQuestionDTO question in questions)
            {
                formQuestions.Add(new FormQuestion
                {
                    Answers = question.QuestionType is FormQuestionTypeDTO.DropDown or FormQuestionTypeDTO.MCQ ? FormQuestion.ConvertAnswersToString(question.MCQAnswers) : question.Answers,
                    Question = question.Question,
                    CreatedBy = question.CreatedBy,
                    CreatedOn = question.CreatedOn,
                    Other = question.Other,
                    MaxChoice = question.MaxChoice,
                    FormId = form.Id,
                    IsRequired = question.IsRequired,
                    QuestionType = (FormQuestionType)question.QuestionType
                });
            }

            await Context.FormQuestions.AddRangeAsync(formQuestions);
            return await Context.SaveChangesAsync();
        }
        public async Task<int> Update(FormQuestionDTO question)
        {
            FormQuestion? Dbquestion = await Context.FormQuestions.FindAsync(question.Id);

            if (Dbquestion != null)
            {
                Dbquestion.Answers = question.Answers;
                Dbquestion.Question = question.Question;
                Dbquestion.CreatedBy = question.CreatedBy;
                Dbquestion.CreatedOn = question.CreatedOn;
                Dbquestion.Other = question.Other;
                Dbquestion.MaxChoice = question.MaxChoice;
                Dbquestion.FormId = question.FormId;
                Dbquestion.IsRequired = question.IsRequired;
                Dbquestion.QuestionType = (FormQuestionType)question.QuestionType;

                Context.FormQuestions.Update(Dbquestion);
                return await Context.SaveChangesAsync();
            }
            return 0;

        }
        public async Task<int> Delete(Guid Id)
        {
            FormQuestion? Dbquestion = await Context.FormQuestions.FindAsync(Id);
            if (Dbquestion != null)
            {
                Context.FormQuestions.Remove(Dbquestion);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
