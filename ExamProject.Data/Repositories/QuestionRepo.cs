using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class QuestionRepo : BaseRepo<QuestionEntity>, IQuestionRepo {

        public QuestionRepo(ExamDbContext examDb) : base(examDb) {
        }
    }
}