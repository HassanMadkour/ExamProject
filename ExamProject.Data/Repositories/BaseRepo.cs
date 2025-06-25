using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    public class BaseRepo<T> : IBaseRepo<T> where T : class {
        protected readonly ExamDbContext examDb;

        public BaseRepo(ExamDbContext examDb) {
            this.examDb = examDb;
        }

        public void Add(T entity) {
            examDb.Set<T>().Add(entity);
        }

        public void Delete(T entity) {
            examDb.Set<T>().Remove(entity);
        }

        public IEnumerable<T> GetAll() {
            return examDb.Set<T>().ToList();
        }

        public T GetById(int id) {
            return examDb.Set<T>().Find(id);
        }

        public void Update(T entity) {
            examDb.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}