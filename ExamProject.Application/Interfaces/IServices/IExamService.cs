using ExamProject.Application.DTOs.AdminDTOs.ExamDTOs;
using ExamProject.Application.DTOs.StudentDTOs.ExamDTOs;
using ExamProject.Application.DTOs.StudentDTOs.QuestionDTOs;
using ExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.Interfaces.IServices
{
    public interface IExamService
    {
        Task<List<ExamDTO>> GetAllExamAsync();
        Task<ExamDTO> GetExamByIdAsync(int id);
        Task AddAsync(AddExamDTO examDTO);
        Task Delete(int id);
        Task Update(int examId, ExamUpdateDTO examUpdateDTO);
        Task<GetExamDTO> GetExamWithQuestionsAsync(int id);
        Task<List<ExamListDTO>> GetAllUncompletedExamsAsync(int userId);
        Task<List<StudentQuestionDTO>> GetExamQuestionsAsync(int examId);
        Task<SubmitExamResultDTO> SubmitExamAsync(SubmitAnswerDTO model);
        Task<List<GetExamDTO>> SearchAsync(string name);
        
        Task<List<ExamDTO>> SearchAsync(string name);
    }
}