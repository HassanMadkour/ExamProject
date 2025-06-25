namespace ExamProject.Application.Interfaces.IRepositories {

    public interface IBaseRepo<T> {

        public void Add(T entity);

        public void Update(T entity);

        public void Delete(T entity);

        public IEnumerable<T> GetAll();

        public T GetById(int id);
    }
}