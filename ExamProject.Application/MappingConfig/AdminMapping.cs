using AutoMapper;
using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
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
        }
    }
}