using AutoMapper;
using ExamProject.Application.Interfaces.IUnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamProject.API.Controllers {
    [Route("api/[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentController(IUnitOfWork unitOfWork,IMapper mapper) {
        _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var students = await _unitOfWork.user.GetAll().ToList();

        }
    }
}
