using AutoMapper;
using ExamProject.Application.DTOs.AdminDTOs.ExamDTOs;
using ExamProject.Application.Interfaces.IRepositories;
using ExamProject.Application.Interfaces.IServices;
using ExamProject.Application.Interfaces.IUnitOfWorks;
using ExamProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.Services
{
    public class ExamService :IExamService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ExamService(IUnitOfWork unitOfWork,IMapper mapper) 
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task AddAsync(AddExamDTO examDTO)
        {
            var exam = mapper.Map<ExamEntity>(examDTO);
            await unitOfWork.ExamRepo.AddAsync(exam);
            await unitOfWork.SaveChangesAsync();
            foreach (var question in examDTO.Questions)
            {

                QuestionEntity q = new QuestionEntity
                {
                    Text = question.Text,
                    Choice1 = question.Choice1,
                    Choice2 = question.Choice2,
                    Choice3 = question.Choice3,
                    Choice4 = question.Choice4,
                    CorrectAnswer = question.CorrectAnswer,
                    Score = (short)question.Score,
                    ExamId=exam.Id,
                };
                await unitOfWork.QuestionRepo.AddAsync(q);
            }
            await unitOfWork.SaveChangesAsync();
             
        }

        public async Task Delete(int id)
        {
            await unitOfWork.ExamRepo.Delete(id);
            await unitOfWork.SaveChangesAsync();

        }

        public async Task<List<ExamDTO>> GetAllExamAsync()
        {
            var Exams =  unitOfWork.ExamRepo.GetAllAsync();
            var examList = await Exams.ToListAsync();
            return  mapper.Map<List<ExamDTO>>(examList);
        }

        public async Task<ExamDTO> GetExamByIdAsync(int id)
        {
            var exam = await unitOfWork.ExamRepo.GetByIdAsync(id);
            return  mapper.Map<ExamDTO>(exam);
        }

        public async Task Update(int examId,ExamUpdateDTO examUpdateDTO)
        {
            var examfromDb = await unitOfWork.ExamRepo.GetByIdAsync(examId);

            mapper.Map(examUpdateDTO, examfromDb);
            examfromDb.UpdatedDate =DateTime.Now;
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<GetExamDTO> GetExamWithQuestionsAsync(int id)
        {
            var exam = await unitOfWork.ExamRepo.GetByIdAsync(id);
            return mapper.Map<GetExamDTO>(exam);
        }

        public async Task<List<ExamDTO>> SearchAsync(string name)
        {
            var exams =  unitOfWork.ExamRepo.GetAllAsync();
            var searchedResult = await exams.Where(e=>e.Name.Contains(name)).ToListAsync();
            return mapper.Map<List<ExamDTO>>(searchedResult);


        }
    }
}
