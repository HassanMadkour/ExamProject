using ExamProject.Domain.Entities;

namespace ExamProject.Application.Interfaces.IRepositories {

    public interface IQuestionRepo : IBaseRepo<QuestionEntity> {

        public List<QuestionEntity> GetQuestionsByExamId(int id);
    }
}