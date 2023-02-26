using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api;
using web_api.Models;
using web_api.DTOs;
using web_api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class WeaponsController : ControllerBase
    {
        private readonly WeaponService _weaponService;
        private readonly IMapper _mapper;

        public WeaponsController(WeaponService WeaponService, IMapper mapper)
        {
            _weaponService = WeaponService;
            _mapper = mapper;
        }


        [HttpPost("name")]
        public async Task<ActionResult<WeaponReadDTO>> GetWeaponByName([FromBody] string name)
        {
            var weapon = await _weaponService.GetWeaponByNameAsync(name);
            return _mapper.Map<WeaponReadDTO>(weapon);
        }


    }
}
