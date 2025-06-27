using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.DTOs.QuestionDTOs
{
    public class QuestionDTO
    {
        public string Text { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string CorrectAnswer { get; set; }
        public int Score { get; set; }
    }
}
