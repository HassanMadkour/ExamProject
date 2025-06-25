using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Domain.Entities;
using ExamProject.Infrastructure.Data;

namespace ExamProject.Infrastructure.Repositories {

    internal class ExamRepo : BaseRepo<ExamEntity>, IExamRepo {

        public ExamRepo(ExamDbContext examDb) : base(examDb) {
        }
    }
}