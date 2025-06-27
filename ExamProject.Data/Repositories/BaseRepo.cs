using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.Infrastructure.Repositories {

    public class BaseRepo<T> : IBaseRepo<T> where T : BaseEnitity {
        protected readonly ExamDbContext examDb;

        public BaseRepo(ExamDbContext examDb) {
            this.examDb = examDb;
        }

        public async Task AddAsync(T entity)
        {
           await examDb.Set<T>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetByIdAsync(id);
            entity.IsDeleted = true;
            await Update(entity);
        }

        public  IQueryable<T> GetAllAsync()
        {
            return  examDb.Set<T>().Where(entity => !entity.IsDeleted);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await examDb.Set<T>().FirstOrDefaultAsync(e => e.ID == id && !e.IsDeleted);
        }

        public async Task Update(T entity)
        {
            examDb.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
              entity.UpdatedDate = DateTime.Now;
               entity.isUpdated = true;
        }



      
    }
}