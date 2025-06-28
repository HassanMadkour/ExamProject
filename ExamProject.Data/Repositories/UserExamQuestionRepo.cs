using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class UserExamQuestionRepo : BaseRepo<UserExamQuestionEntity>, IUserExamQuestionRepo {

        public UserExamQuestionRepo(ExamDbContext examDb) : base(examDb) {
        }
    }
}