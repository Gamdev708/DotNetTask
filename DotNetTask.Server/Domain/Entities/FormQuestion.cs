using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTask.Server.Domain.Entities
{
    public enum FormQuestionType
    {
        None,
        Paragraph,
        Number,
        DropDown,
        MCQ,
        YesNo,
    }

    public class FormQuestion
    {
        public Guid Id { get; set; }
        public Form Form { get; set; }
        public Guid FormId { get; set; }
        public FormQuestionType QuestionType { get; set; }
        public string Question { get; set; }
        public string Answers { get; set; }
        public bool IsRequired { get; set; }
        public bool Other { get; set; }
        public int MaxChoice { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string? LastUpdatedBy { get; set; }

        // Convert List<string> to comma-separated string
        public static string ConvertAnswersToString(List<string> answers)
        {
            return string.Join(",", answers);
        }

        // Convert comma-separated string to List<string>
        public static List<string> ConvertStringToAnswers(string answers)
        {
            return string.IsNullOrEmpty(answers) ? new List<string>() : answers.Split(',').ToList();
        }
    }
}
