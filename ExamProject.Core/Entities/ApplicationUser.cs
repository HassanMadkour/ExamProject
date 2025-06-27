using Microsoft.AspNetCore.Identity;

namespace ExamProject.Domain.Entities {

    public class ApplicationUser : IdentityUser<int> {
        public string? Name { get; set; }

        public ICollection<UserExamEntity> UserExams { get; set; }
    }
}