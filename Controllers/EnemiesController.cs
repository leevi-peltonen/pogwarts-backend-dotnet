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

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnemiesController : ControllerBase
    {
        private readonly EnemyService _enemyService;
        private readonly IMapper _mapper;
        public EnemiesController(EnemyService enemyService, IMapper mapper)
        {
            _enemyService = enemyService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<ICollection<Enemy>>> GetAllEnemies()
        {
            var enemies = await _enemyService.GetAllEnemiesAsync();
            return Ok(enemies);
        }

    }
}
