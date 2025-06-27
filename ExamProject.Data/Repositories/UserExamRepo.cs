using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class UserExamRepo : BaseRepo<UserExamEntity>, IUserExamRepo {

        public UserExamRepo(ExamDbContext examDb) : base(examDb) {
        }

        public UserExamEntity? GetUserExam(int userId, int examId) {
            return examDb.UserExams.Where(x => x.UserId == userId && x.ExamId == examId).FirstOrDefault();
        }

        public List<UserExamEntity> GetUserExamsForExam(int examId) {
            return examDb.UserExams.Where(x => x.ExamId == examId).ToList();
        }

        public List<UserExamEntity> GetUserExamsForUser(int userId) {
            return examDb.UserExams.Where(x => x.UserId == userId).ToList();
        }
    }
}