using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class UserExamRepo : IUserExamRepo {
        private readonly ExamDbContext examDb;

        public UserExamRepo(ExamDbContext examDb) {
            this.examDb = examDb;
        }

        public UserExamEntity? GetUserExam(int userId, int examId) {
            return examDb.UserExams.Where(x => x.UserId == userId && x.ExamId == examId).FirstOrDefault();
        }

        public List<UserExamEntity> GetUserExamsForExam(int examId, int page = 1, int pageSize = 10) {
            return examDb.UserExams.Where(x => x.ExamId == examId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<UserExamEntity> GetUserExamsForUser(int userId) {
            return examDb.UserExams.Where(x => x.UserId == userId).ToList();
        }
    }
}