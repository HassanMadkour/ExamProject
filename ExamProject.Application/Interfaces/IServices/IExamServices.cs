using ExamProject.Domain.Entities;

namespace ExamProject.Application.Interfaces.IServices {

    public interface IExamServices {

        public ExamEntity AddAsync(ExamEntity exam);

        public ExamEntity UpdateAsync(ExamEntity exam);

        public bool DeleteAsync(int id);

        public ExamEntity GetAsync(int id);
    }
}