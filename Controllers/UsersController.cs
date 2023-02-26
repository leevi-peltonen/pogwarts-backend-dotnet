using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api;
using web_api.Models;
using web_api.Services;
using web_api.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Cors;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]

    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UsersController(UserService userService, IMapper mapper, IPasswordHasher<User> passwordHasher)
        {
            _userService = userService;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            User user = await _userService.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return _mapper.Map<UserReadDTO>(user);
        }
        
        [HttpPost("register")]
        public async Task<ActionResult<UserReadDTO>> Register([FromBody] UserCreateDTO user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var hashedPassword = _passwordHasher.HashPassword(mappedUser, user.Password);
            mappedUser.PasswordHash = hashedPassword;
            await _userService.CreateUserAsync(mappedUser);
            return _mapper.Map<UserReadDTO>(mappedUser);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserReadDTO>> Login([FromBody] UserCreateDTO ucdto)
        {
            var user = await _userService.GetUserByName(ucdto.Name);
            PasswordVerificationResult result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, ucdto.Password);

            if(result == PasswordVerificationResult.Success)
            {
                return _mapper.Map<UserReadDTO>(user);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
