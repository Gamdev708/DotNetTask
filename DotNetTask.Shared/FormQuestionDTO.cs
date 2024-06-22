using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Shared
{
    public enum FormQuestionTypeDTO
    {
        None,
        Paragraph,
        Number,
        DropDown,
        MCQ,
        YesNo,
        Date
    }
    public class FormQuestionDTO
    {
        public Guid Id { get; set; }
        public FormDTO? Form { get; set; }
        public Guid FormId { get; set; }
        public FormQuestionTypeDTO QuestionType { get; set; }

        public string? Question { get; set; }
        public string? Answers { get; set; }
        public bool Other { get; set; }
        public int MaxChoice { get; set; }
        public List<string>? MCQAnswers { get; set; } = new List<string>();
        public bool IsRequired { get; set; }

        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }

    }
}
