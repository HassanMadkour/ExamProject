using Microsoft.AspNetCore.Identity;

namespace ExamProject.Domain {

    public class ApplicationUser : IdentityUser<int> {
        public string? Name { get; set; }
    }
}