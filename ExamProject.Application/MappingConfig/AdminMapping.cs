using AutoMapper;
using ExamProject.Application.DTOs.AdminDTOs.ExamDTOs;
using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
using ExamProject.Application.DTOs.AdminDTOs.QuestionDTOs;
using ExamProject.Application.DTOs.AdminDTOs.StudentDtos;
using ExamProject.Domain.Entities;

namespace ExamProject.Application.MappingConfig {

    public class AdminMapping : Profile {

        public AdminMapping() {
            CreateMap<ExamEntity, ExamStudentsDTO>().AfterMap((src, dest) => {
                dest.ExamName = src.Name;
                dest.MaxMarks = src.MaxDegree;
                dest.MinMarks = src.MinDegree;
                dest.Duration = src.Duration;
                dest.StartDateTime = src.StartTime;
                dest.EndDateTime = src.EndTime;
            });

            CreateMap<UserExamEntity, DisplayStudentDTO>().AfterMap((src, dest) => {
                dest.Marks = src.TotalScore;
                dest.isPassed = src.IsPassed;
                dest.FullName = src.User.Name;
            });

            CreateMap<CreateQuestionDTO, QuestionEntity>().AfterMap((src, dest) => {
                //dest.ExamId = src.ExamId;
            });

            CreateMap<ExamEntity, AddExamDTO>().ReverseMap();
            CreateMap<ExamEntity, GetExamDTO>().AfterMap((s, d) => {
                d.QuestionOfNumber = s.Questions?.Count() ?? 0;
            });
            CreateMap<ExamEntity, ExamDTO>().AfterMap((s, d) => {
                d.QuestionOfNumber = s.Questions?.Count() ?? 0;
            });
            CreateMap<ExamUpdateDTO, ExamEntity>().ReverseMap();
        }
    }
}