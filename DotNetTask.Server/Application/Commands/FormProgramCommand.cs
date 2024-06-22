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
    public class FormProgramCommand : IFormProgramCommand
    {
        private readonly DotNetTaskServerContext Context;

        public FormProgramCommand(DotNetTaskServerContext context)
        {
            Context = context;
        }

        public async Task<int> Create(FormProgramDTO formdto)
        {
            FormProgram form = new FormProgram
            {
                //Id = Guid.NewGuid(),
                Title = formdto.Title,
                Description = formdto.Description,
                CreatedBy = formdto.CreatedBy,
                CreatedOn = formdto.CreatedOn,
            };

            await Context.FormPrograms.AddAsync(form);
            return await Context.SaveChangesAsync();
        }
        public async Task<int> Update(FormProgramDTO formdto)
        {
            FormProgram? DbForm = await Context.FormPrograms.FindAsync(formdto.Id);

            if (DbForm != null)
            {
                DbForm.Title = formdto.Title;
                DbForm.Description = formdto.Description;
                DbForm.LastUpdatedBy = formdto.LastUpdatedBy;
                DbForm.UpdatedOn = formdto.UpdatedOn;

                Context.FormPrograms.Update(DbForm);
                return await Context.SaveChangesAsync();
            }
            return 0;

        }
        public async Task<int> Delete(Guid Id)
        {
            FormProgram? DbForm = await Context.FormPrograms.FindAsync(Id);
            if (DbForm != null)
            {
                Context.FormPrograms.Remove(DbForm);
                return await Context.SaveChangesAsync();
            }
            return 0;

        }

        public async Task<int> CreateProgram(FormProgramDTO formdto)
        {
            FormProgram form = new FormProgram
            {
                //Id = Guid.NewGuid(),
                Title = formdto.Title,
                Description = formdto.Description,
                CreatedBy = formdto.CreatedBy,
                CreatedOn = formdto.CreatedOn,
            };

            await Context.FormPrograms.AddAsync(form);
            return await Context.SaveChangesAsync();

        }
    }
}
