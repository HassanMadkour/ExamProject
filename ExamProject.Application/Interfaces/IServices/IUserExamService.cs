using ExamProject.Application.DTOs.StudentDTOs.UserExamDTOs;

namespace ExamProject.Application.Interfaces.IServices {

    public interface IUserExamService {

        public List<CompletedUserExamsDTO> GetPassedExamsAsync(int userId);

        public List<UnCompletedUserExamsDTO> GetUnpassedUserExamsForUser(int userId);
    }
}