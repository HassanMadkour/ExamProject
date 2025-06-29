using ExamProject.Application.DTOs.StudentDTOs.ExamDTOs;
using ExamProject.Application.DTOs.StudentDTOs.QuestionDTOs;
using ExamProject.Application.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExamProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IExamService _examService;

        public StudentController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet("exams/{userId}")]
        public async Task<IActionResult> GetExams(int userId)
        {
            var exams = await _examService.GetAllUncompletedExamsAsync(userId);
            return Ok(exams);
        }

        [HttpGet("examQuestions/{examId}")]
        public async Task<IActionResult> GetExamQuestions(int examId)
        {
            var questions = await _examService.GetExamQuestionsAsync(examId);
            return Ok(questions);
        }

        [HttpPost("submitExam")]
        public async Task<IActionResult> SubmitExam([FromBody] SubmitAnswerDTO model)
        {
            var result = await _examService.SubmitExamAsync(model);
            return Ok(result);
        }

        [HttpGet("examDetails/{examId}")]
        public async Task<IActionResult> GetExamDetails(int examId)
        {
            var exam = await _examService.GetExamWithQuestionsAsync(examId);
            return Ok(exam);
        }

     
    }
}
