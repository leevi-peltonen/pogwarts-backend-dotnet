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

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public UsersController(UserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDTO>> GetUserById(int id)
        {
            User user = await _userService.GetUserByIdAsync(id);
            return _mapper.Map<UserReadDTO>(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDTO>> CreateUser([FromBody] UserCreateDTO user)
        {
            var mappedUser = _mapper.Map<User>(user);
            var passwordHasher = new PasswordHasher<User>();
            var hashedPassword = passwordHasher.HashPassword(mappedUser, user.Password);
            mappedUser.PasswordHash = hashedPassword;
            await _userService.CreateCharacterAsync(mappedUser);
            return Ok(mappedUser);
        }

    }
}
