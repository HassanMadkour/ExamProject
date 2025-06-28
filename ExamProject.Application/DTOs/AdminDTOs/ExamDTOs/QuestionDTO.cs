using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.DTOs.AdminDTOs.ExamDTOs
{
    public class QuestionDTO
    {

        [MaxLength(150)]
        public string Text { get; set; }

        [MaxLength(150)]
        public string Choice1 { get; set; }

        [MaxLength(150)]
        public string Choice2 { get; set; }

        [MaxLength(150)]
        public string Choice3 { get; set; }

        [MaxLength(150)]
        public string Choice4 { get; set; }

        [MaxLength(150)]
        public string CorrectAnswer { get; set; }

        [Range(0, 20)]
        public short Score { get; set; }
    }
}
