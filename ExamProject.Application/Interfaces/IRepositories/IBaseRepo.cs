namespace ExamProject.Application.Interfaces.IRepositories {

    public interface IBaseRepo<T> {

        Task AddAsync(T entity);

        Task Update(T entity);

        Task Delete(int id);

        IQueryable<T> GetAllAsync();

        Task<T?> GetByIdAsync(int id);
    }
}