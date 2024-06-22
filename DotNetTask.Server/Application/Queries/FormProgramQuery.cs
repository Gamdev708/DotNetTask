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
    public class FormProgramQuery : IFormProgramQuery
    {
        private readonly DotNetTaskServerContext Context;

        public FormProgramQuery(DotNetTaskServerContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<FormProgramDTO>> GetProgram()
        {
            List<FormProgram> forms = await Context.FormPrograms.ToListAsync();
            List<FormProgramDTO> dtos = new List<FormProgramDTO>();

            foreach (var form in forms)
            {
                dtos.Add(new FormProgramDTO
                {
                    UpdatedOn = form.UpdatedOn,
                    LastUpdatedBy = form.LastUpdatedBy,
                    CreatedBy = form.CreatedBy,
                    Description = form.Description,
                    Title = form.Title,
                    CreatedOn = form.CreatedOn,
                    Id = form.Id
                });
            }

            return dtos;
        }

        public async Task<FormProgramDTO> GetProgramById(Guid Id)
        {
            FormProgram form = await Context.FormPrograms.FindAsync(Id);
            FormProgramDTO dto = new FormProgramDTO
            {
                UpdatedOn = form.UpdatedOn,
                LastUpdatedBy = form.LastUpdatedBy,
                CreatedBy = form.CreatedBy,
                Description = form.Description,
                Title = form.Title,
                CreatedOn = form.CreatedOn,
                Id = form.Id
            };
            return dto;
        }


    }
}
