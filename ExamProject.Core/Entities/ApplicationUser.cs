using Microsoft.AspNetCore.Identity;

namespace ExamProject.Domain.Entities {

    public class ApplicationUser : IdentityUser<int> {
        public string Name { get; set; }

        public virtual ICollection<UserExamEntity> UserExams { get; set; }
    }
}