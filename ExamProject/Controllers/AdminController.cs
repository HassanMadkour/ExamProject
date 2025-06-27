using ExamProject.Application.Interfaces.IServices;
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
            adminService.GetExamStudents(id);
            return Ok("Admin");
        }

        [HttpGet]
        public string GetAllTeachers() {
            return "Admin";
        }
    }
}