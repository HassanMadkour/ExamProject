using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class UserExamRepo : IUserExamRepo {
        private readonly ExamDbContext _examDb;

        public UserExamRepo(ExamDbContext examDb) {
            _examDb = examDb;
        }

        public UserExamEntity? GetUserExam(int userId, int examId) {
            return _examDb.UserExams.Where(x => x.UserId == userId && x.ExamId == examId).FirstOrDefault();
        }

        public List<UserExamEntity> GetUserExamsForExam(int examId) {
            return _examDb.UserExams.Where(x => x.ExamId == examId).ToList();
        }

        public List<UserExamEntity> GetUserExamsForUser(int userId) {
            return _examDb.UserExams.Where(x => x.UserId == userId).ToList();
        }
    }
}