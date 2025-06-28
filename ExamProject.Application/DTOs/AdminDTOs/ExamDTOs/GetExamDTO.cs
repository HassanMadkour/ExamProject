using ExamProject.Domain.Entities;

namespace ExamProject.Application.DTOs.AdminDTOs.ExamDTOs {

    public class GetExamDTO {
        public string Name { get; set; }

        public short MinDegree { get; set; }

        public short MaxDegree { get; set; }

        public TimeSpan Duration { get; set; }
        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public int QuestionOfNumber { get; set; }
        public virtual ICollection<QuestionDTO> Questions { get; set; }
    }
}