using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using web_api.Services;
using web_api.Models;
using web_api.DTOs;
using Microsoft.AspNetCore.Cors;


namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class AchievementController : ControllerBase
    {
        private readonly AchievementService _achievementService;
        private readonly IMapper _mapper;
        public AchievementController(AchievementService achievementService, IMapper mapper)
        {
            _achievementService = achievementService;
            _mapper = mapper;
        }

        [HttpPost("{achievementId}")]
        public async Task<CharacterReadDTO> AddAchievementToCharacter([FromBody] string characterName, int achievementId)
        {
            var character = await _achievementService.AddAchievementToCharacterAsync(achievementId, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }


        [HttpGet]
        public async Task<ICollection<AchievementReadDTO>> GetAchievements()
        {
            var achievements = await _achievementService.GetAchievementsAsync();

            var achievementsDto = new List<AchievementReadDTO>();

            foreach (var achievement in achievements)
            {
                achievementsDto.Add(_mapper.Map<AchievementReadDTO>(achievement));
            }

            return achievementsDto;
        }

    }
}
