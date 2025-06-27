namespace ExamProject.Application.DTOs.AdminDTOs.QuestionDTOs {

    public class QuestionDTO {
        public string QuestionText { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public int CorrectAnswer { get; set; }
    }
}