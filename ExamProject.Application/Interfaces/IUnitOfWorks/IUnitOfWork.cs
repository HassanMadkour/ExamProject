using ExamProject.Application.Interfaces.IRepositories;

namespace ExamProject.Application.Interfaces.IUnitOfWorks {

    public interface IUnitOfWork {
        IExamRepo ExamRepo { get; }
        IQuestionRepo QuestionRepo { get; }
        //IUserRepo UserRepo { get; }
        public Task SaveChangesAsync();
    }
}