using ExamProject.Application.DTOs.AdminDTOs.ExamDTOs;
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
        Task Update(int examId,ExamUpdateDTO examUpdateDTO);
        Task<GetExamDTO> GetExamWithQuestionsAsync(int id);
        Task<List<ExamDTO>> SearchAsync(string name);
    }
}
