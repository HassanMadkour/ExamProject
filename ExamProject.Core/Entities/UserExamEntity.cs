using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExamProject.Domain.Entities {

    [Table("UserExams"), PrimaryKey(nameof(UserId), nameof(ExamId))]
    public class UserExamEntity {

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Exam")]
        public int ExamId { get; set; }

        public int TotalScore { get; set; }
        public bool IsCompleted { get; set; }

        public bool? IsPassed { get; set; }

        public virtual ApplicationUser User { get; set; }
        public virtual ExamEntity Exam { get; set; }
    }
}