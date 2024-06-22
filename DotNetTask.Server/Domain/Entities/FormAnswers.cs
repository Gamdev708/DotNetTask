using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Domain.Entities
{
    public class FormAnswers
    {
        public Guid Id { get; set; }
        public string? Answer { get; set; }

        public FormQuestion Question { get; set; }
        public Guid QuestionId { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }
    }
}
