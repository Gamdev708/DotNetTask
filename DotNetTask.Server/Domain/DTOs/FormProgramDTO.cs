using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Domain.DTOs
{
    public class FormProgramDTO
    {

        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
    }
}
