using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
using ExamProject.Application.DTOs.AdminDTOs.QuestionDTOs;
using ExamProject.Application.Utils;

namespace ExamProject.Application.Interfaces.IServices {

    public interface IAdminService {

        public Task<Either<Failure, ExamStudentsDTO>> GetExamStudents(int id);

        public Task<Either<Failure, CreateQuestionDTO>> CreateQuestion(CreateQuestionDTO createQuestionDTO);

        public Task<Either<Failure, List<QuestionDTO>>> GetAllQuestions();
    }
}