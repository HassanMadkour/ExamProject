using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.DTOs.StudentDTOs.ExamDTOs
{
    public class SubmitAnswerDTO
    {
        public int ExamId { get; set; }
        public int UserId { get; set; }
        public List<AnswerItem> Answers { get; set; }

        public class AnswerItem
        {
            public int QuestionId { get; set; }
            public string SelectedAnswer { get; set; }
        }
    }

}
