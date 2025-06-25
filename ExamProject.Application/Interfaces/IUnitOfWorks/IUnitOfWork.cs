namespace ExamProject.Application.Interfaces.IUnitOfWorks {

    public interface IUnitOfWork {

        public Task SaveChangesAsync();
    }
}