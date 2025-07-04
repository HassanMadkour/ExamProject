using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class QuestionRepo : BaseRepo<QuestionEntity>, IQuestionRepo {

        public QuestionRepo(ExamDbContext examDb) : base(examDb) {
        }

        public List<QuestionEntity> GetQuestionsByExamId(int id, int page, int pageSize) {
            return examDb.Questions.Where(x => x.ExamId == id && !x.IsDeleted).Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }
    }
}