using AutoMapper;
using ExamProject.Application.DTOs.StudentDTOs.ExamDTOs;
using ExamProject.Application.DTOs.StudentDTOs.QuestionDTOs;
using ExamProject.Application.DTOs.StudentDTOs.UserExamDTOs;
using ExamProject.Domain.Entities;

namespace ExamProject.Application.MappingConfig {

    public class StudentMapping : Profile {

        public StudentMapping() {
            CreateMap<QuestionEntity, StudentQuestionDTO>()
      .ForMember(dest => dest.QuestionText, opt => opt.MapFrom(src => src.Text));

            CreateMap<UserExamEntity, CompletedUserExamsDTO>().AfterMap((src, dest) => {
                dest.ExamName = src.Exam.Name;
                dest.MaxScore = src.Exam.MaxDegree;
            });

            CreateMap<UserExamEntity, ExamDetailsDTO>().AfterMap((src, dest) => {
                dest.ExamName = src.Exam.Name;
                dest.MaxMarks = src.Exam.MaxDegree;
                dest.IsPassed = src.IsPassed ?? false;
            });
            CreateMap<UserExamQuestionEntity, QuestionDetailsDTO>().AfterMap((src, dest) => {
                dest.QuestionText = src.Question.Text;
                dest.CorrectAnswer = src.Question.CorrectAnswer;
                dest.Score = src.Question.Score;
                dest.AnswerScore = src.AnswerScore;
            });
        }
    }
}