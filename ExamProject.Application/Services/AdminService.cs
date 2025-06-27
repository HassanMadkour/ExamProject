using AutoMapper;
using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
using ExamProject.Application.Interfaces.IServices;
using ExamProject.Application.Interfaces.IUnitOfWorks;
using ExamProject.Application.Utils;

namespace ExamProject.Application.Services {

    public class AdminService : IAdminService {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper) {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Either<Failure, ExamStudentsDTO> GetExamStudents(int id) {
            try {
                var result = new { };
                ExamStudentsDTO dto = _mapper.Map<ExamStudentsDTO>(result);
                return Either<Failure, ExamStudentsDTO>.Success(dto);
            } catch (Exception ex) {
                return Either<Failure, ExamStudentsDTO>.Failure(new Failure(ex.Message));
            }
        }
    }
}