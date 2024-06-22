using DotNetTask.Server.Interfaces.Queries;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;
using Microsoft.EntityFrameworkCore;
using DotNetTask.Server.Domain.DTOs;
using DotNetTask.Server.Domain.Entities;
using DotNetTask.Server.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Application.Queries
{
    public class FormQuery : IFormQuery
    {
        private readonly DotNetTaskServerContext Context;

        public FormQuery(DotNetTaskServerContext context)
        {
            Context = context;
        }

        public async Task<FormDTO> GetFormByIdAsync(Guid id)
        {
            Form form = await Context.Forms.FirstOrDefaultAsync(x=>x.FormProgramId==id);
            FormDTO dTO = new FormDTO{
                CreatedBy = form.CreatedBy,
                CreatedOn = form.CreatedOn,
                FormProgramId = form.FormProgramId,
                Id = form.Id,
                LastUpdatedBy = form.LastUpdatedBy,
                UpdatedOn = form.UpdatedOn,
            };
            
            return dTO;
        }

    }
}
