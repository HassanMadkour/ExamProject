using ExamProject.Application.DTOs.AdminDTOs.StudentDtos;

namespace ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs {

    public class ExamStudentsDTO {

        public ExamStudentsDTO() {
            Students = new List<DisplayStudentDTO>();
        }

        public string ExamName { get; set; }
        public short MaxMarks { get; set; }

        public short MinMarks { get; set; }
        public TimeSpan Duration { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public List<DisplayStudentDTO> Students { get; set; }
    }
}