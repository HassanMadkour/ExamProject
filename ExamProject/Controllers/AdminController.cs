using ExamProject.Application.DTOs.AdminDTOs.ExamStudentsDTOs;
using ExamProject.Application.Interfaces.IServices;
using ExamProject.Application.Utils;
using Microsoft.AspNetCore.Mvc;

namespace ExamProject.API.Controllers {

    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase {
        private readonly IAdminService adminService;

        public AdminController(IAdminService adminService) {
            this.adminService = adminService;
        }

        [HttpGet("Exams/{id}/Students")]
        public IActionResult GetAllStudentsByExam(int id) {
            Either<Failure, ExamStudentsDTO> result = adminService.GetExamStudents(id);
            if (result.IsSuccess)
                return Ok(result.Right);
            else
                return FailureIActionResult.FailureHandler(result.Left);
        }

        [HttpGet]
        public string GetAllTeachers() {
            return "Admin";
        }
    }
}