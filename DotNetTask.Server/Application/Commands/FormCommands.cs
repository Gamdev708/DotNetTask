using Azure;
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
using Microsoft.EntityFrameworkCore;

namespace DotNetTask.Server.Application.Commands
{
    public class FormCommands : IFormCommands
    {
        private readonly DotNetTaskServerContext Context;

        public FormCommands(DotNetTaskServerContext context)
        {
            Context = context;
        }

        public async Task<int> Create(FormDTO formdto)
        {
            var program  = await Context.FormPrograms.OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync();


            Form form = new Form
            {
                FormProgramId = program.Id,
                CreatedBy = formdto.CreatedBy,
                CreatedOn = formdto.CreatedOn,
            };

            await Context.Forms.AddRangeAsync(form);
            return await Context.SaveChangesAsync();
        }
        public async Task<int> Update(FormDTO formdto)
        {
            Form? DbForm = await Context.Forms.FindAsync(formdto.Id);

            if (DbForm != null)
            {

                DbForm.LastUpdatedBy = formdto.LastUpdatedBy;
                DbForm.UpdatedOn = formdto.UpdatedOn;

                Context.Forms.Update(DbForm);
                return await Context.SaveChangesAsync();
            }

            return 0;

        }
        public async Task<int> Delete(Guid Id)
        {
            Form? DbForm = await Context.Forms.FindAsync(Id);
            if (DbForm != null)
            {
                Context.Forms.Remove(DbForm);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }
    }
}
