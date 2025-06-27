using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class UserExamQuestionRepo : IUserExamQuestionRepo {
        private readonly ExamDbContext examDb;

        public UserExamQuestionRepo(ExamDbContext examDb) {
            this.examDb = examDb;
        }
    }
}