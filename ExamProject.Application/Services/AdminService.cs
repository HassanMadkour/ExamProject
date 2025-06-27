using AutoMapper;
using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
using ExamProject.Application.DTOs.AdminDTOs.StudentDtos;
using ExamProject.Application.Interfaces.IServices;
using ExamProject.Application.Interfaces.IUnitOfWorks;
using ExamProject.Application.Utils;
using ExamProject.Domain.Entities;

namespace ExamProject.Application.Services {

    public class AdminService : IAdminService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Either<Failure, ExamStudentsDTO>> GetExamStudents(int id) {
            try {
                ExamEntity? exam = await _unitOfWork.ExamRepo.GetByIdAsync(id);
                if (exam == null) return Either<Failure, ExamStudentsDTO>.Failure(new NotFoundFailure("Exam not found"));
                ExamStudentsDTO examStudentsDTO = _mapper.Map<ExamStudentsDTO>(exam);
                examStudentsDTO.Students = _mapper.Map<List<DisplayStudentDTO>>(_unitOfWork.UserExamRepo.GetUserExamsForUser(id));

                return Either<Failure, ExamStudentsDTO>.Success(examStudentsDTO);
            } catch (Exception ex) {
                return Either<Failure, ExamStudentsDTO>.Failure(new Failure(ex.Message));
            }
        }

        //public Either<Failure, CreateQuestionDTO> CreateQuestion(CreateQuestionDTO createQuestionDTO) {
        //    try {
        //        QuestionEntity question = _unitOfWork.QuestionRepo.Add(_mapper.Map<QuestionEntity>(createQuestionDTO));
        //        return _mapper.Map<CreateQuestionDTO>(question);
        //    } catch (Exception ex) {
        //        return new CreateQuestionDTO();
        //    }
        //}
    }
}