using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProject.Domain.Entities {

    [Table("UserExamQuestion"), PrimaryKey("UserId", "QuestionId", "ExamId")]
    public class UserExamQuestionEntity {

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Question")]
        public int QuestionId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        [Range(0, 20)]
        public short AnswerScore { get; set; }

        public string SelectedAnswer {  get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual QuestionEntity Question { get; set; }
        public virtual ExamEntity Exam { get; set; }
    }
}