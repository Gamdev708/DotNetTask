using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Domain.Entities
{
    public class Form
    {
        public Guid Id { get; set; }

        public List<FormQuestion> Questions { get; set; }
        public FormProgram FormProgram { get; set; }
        public Guid FormProgramId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
    }
}
