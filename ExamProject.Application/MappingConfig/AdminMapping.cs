using AutoMapper;
using ExamProject.Application.DTOs.AdminDTOs;
using ExamProject.Application.DTOs.QuestionDTOs;
using ExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.MappingConfig
{
    public partial class MappingConfig
    {
        private void AdminMappingConfig()
        {

            CreateMap<ExamEntity, AddExamDTO>().ReverseMap();
            CreateMap<QuestionEntity, QuestionDTO>().ReverseMap();
            CreateMap<ExamEntity, GetExamDTO>().AfterMap((s, d) =>
            {
                d.QuestionOfNumber = s.Questions?.Count() ?? 0;
            });
            CreateMap<ExamEntity, ExamDTO>().AfterMap((s, d) =>
            {
                d.QuestionOfNumber = s.Questions?.Count() ?? 0;
            });
            CreateMap<ExamUpdateDTO, ExamEntity>().ReverseMap();
        }
    }
}
