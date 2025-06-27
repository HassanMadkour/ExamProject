using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
using ExamProject.Application.Utils;

namespace ExamProject.Application.Interfaces.IServices {

    public interface IAdminService {

        public Task<Either<Failure, ExamStudentsDTO>> GetExamStudents(int id);
    }
}