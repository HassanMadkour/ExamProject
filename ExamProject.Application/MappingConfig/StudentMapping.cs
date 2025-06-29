using AutoMapper;
using ExamProject.Application.DTOs.StudentDTOs.QuestionDTOs;
using ExamProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.MappingConfig
{
    public class StudentMapping:Profile
    {
        public StudentMapping()
        {
            CreateMap<QuestionEntity, StudentQuestionDTO>()
      .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Text));

        }
    }
}
