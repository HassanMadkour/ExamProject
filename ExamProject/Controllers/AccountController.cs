using System.Web;
using AutoMapper;
using ExamProject.Application.DTOs.AccountDTOs;
using ExamProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExamProject.API.Controllers {


    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IConfiguration config;
        private readonly IEmailSender emailSender;
        private readonly IMapper mapper;


        public AccountController(UserManager<ApplicationUser> _userManager 
            , IConfiguration _config ,IEmailSender _emailSender , IMapper _mapper)
        {
            userManager = _userManager;
            config = _config;
            emailSender = _emailSender;
            mapper = _mapper;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto userDto)
        {
            var user = mapper.Map<ApplicationUser>(userDto);
            var result = await userManager.CreateAsync(user, userDto.Password);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            await userManager.AddToRoleAsync(user, "student");
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            //var encodedToken = HttpUtility.UrlEncode(token);
            var confirmationLink = $"http://localhost:4200/ConfirmEmail?userId={user.Id}&token={token}";
            await emailSender.SendEmailAsync(user.Email, "Confirm your Email", confirmationLink);
            return Ok("Registration successful! Please confirm your email before logging in.");
        }

        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user is null)
                return BadRequest("Invalid user");

            var result = await userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return Ok("Email confirmed successfully");

            return BadRequest("Email confirmation failed");
        }



    }
}