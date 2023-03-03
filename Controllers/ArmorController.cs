using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Models;
using web_api.Services;
using web_api.DTOs;
using Microsoft.AspNetCore.Cors;
using AutoMapper;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class ArmorController : ControllerBase
    {
        private readonly ArmorService _armorService;
        private readonly IMapper _mapper;

        public ArmorController(ArmorService armorService, IMapper mapper)
        {
            _armorService = armorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ArmorReadDTO>>> GetAllArmor()
        {
            var armor = await _armorService.GetAllArmorAsync();
            return Ok(_mapper.Map<ICollection<ArmorReadDTO>>(armor));
        }

        [HttpPost("name")]
        public async Task<ActionResult<ArmorReadDTO>> GetArmorByName([FromBody] string name)
        {
            var armor = await _armorService.GetArmorByNameAsync(name);
            return Ok(_mapper.Map<ArmorReadDTO>(armor));
        }

    }
}
