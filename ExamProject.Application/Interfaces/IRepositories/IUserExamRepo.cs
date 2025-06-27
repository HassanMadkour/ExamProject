using ExamProject.Domain.Entities;

namespace ExamProject.Application.Interfaces.IRepositories {

    public interface IUserExamRepo {

        public UserExamEntity? GetUserExam(int userId, int examId);

        public List<UserExamEntity> GetUserExamsForUser(int userId);

        public List<UserExamEntity> GetUserExamsForExam(int examId, int page = 1, int pageSize = 10);
    }
}