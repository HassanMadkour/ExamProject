using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamProject.Application.DTOs.AccountDTOs
{
    public class RegisterUserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber {  get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
