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
using Microsoft.AspNetCore.Cors;

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAllHeaders")]
    public class CharactersController : ControllerBase
    {
        private readonly CharacterService _characterService;
        private readonly IMapper _mapper;

        public CharactersController(CharacterService service, IMapper mapper)
        {
            _characterService = service;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<ICollection<CharacterReadDTO>>> GetAllCharacters()
        {
            ICollection<Character> tempCharacters = await _characterService.GetAllCharactersAsync();
            ICollection<CharacterReadDTO> characters = new List<CharacterReadDTO>();
            foreach (Character character in tempCharacters)
            {
                var mappedCharacter = _mapper.Map<CharacterReadDTO>(character);
                characters.Add(mappedCharacter);
            }
            return Ok(characters);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterReadDTO>> GetCharacterById(int id)
        {
            Character character = await _characterService.GetCharacterByIdAsync(id);
            CharacterReadDTO mappedCharacter = _mapper.Map<CharacterReadDTO>(character);
            return Ok(mappedCharacter);
        }

        [HttpPost("create")]
        public async Task<ActionResult<CharacterReadDTO>> CreateCharacter([FromBody] CharacterCreateDTO character)
        {
            Character characterToCreate = _mapper.Map<Character>(character);
            var returnCharacter = await _characterService.CreateCharacterAsync(characterToCreate);
            return _mapper.Map<CharacterReadDTO>(returnCharacter);
        }

        [HttpPatch("weapon/inventory/add/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> AddWeaponToInventory([FromBody]string weaponName, string characterName)
        {
            var character = await _characterService.AddWeaponToInventoryAsync(weaponName, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("weapon/loot/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> LootWeapon([FromBody]WeaponReadDTO weapon, string characterName)
        {
            var character = await _characterService.LootWeaponAsync(_mapper.Map<Weapon>(weapon), characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }



        [HttpPatch("weapon/inventory/remove/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> RemoveWeaponFromInventory([FromBody] string weaponName, string characterName)
        {
            var character = await _characterService.RemoveWeaponFromInventoryAsync(weaponName, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("coins/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> UpdateCoins([FromBody]int coins, string characterName)
        {
            var character = await _characterService.UpdateCoinsAsync(coins, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("attributes/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> UpdateAttributes([FromBody] List<int> values, string characterName)
        {
            var character = await _characterService.UpdateAttributesAsync(values[0], values[1], values[2], characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("level/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> UpdateLevel([FromBody] int level, string characterName)
        {
            var character = await _characterService.UpdateLevelAsync(level, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("experience/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> UpdateExperience([FromBody] int experience, string characterName)
        {
            var character = await _characterService.UpdateExperienceAsync(experience, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("equip/weapon/{characterName}")]

        public async Task<ActionResult<CharacterReadDTO>> EquipWeapon([FromBody] string weaponName, string characterName)
        {
            var character = await _characterService.EquipWeaponAsync(weaponName, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("contract/change/{characterName}")]

        public async Task<ActionResult<CharacterReadDTO>> ChangeActiveContract([FromBody] string contractName, string characterName)
        {
            var character = await _characterService.ChangeActiveContractAsync(contractName, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("health/{characterName}")]

        public async Task<ActionResult<CharacterReadDTO>> UpdateHealth([FromBody] int health, string characterName)
        {
            var character = await _characterService.UpdateHealthAsync(health, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

        [HttpPatch("maxhealth/{characterName}")]
        public async Task<ActionResult<CharacterReadDTO>> UpdateMaxHealth([FromBody] int maxHealth, string characterName)
        {
            var character = await _characterService.UpdateMaxHealthAsync(maxHealth, characterName);
            return _mapper.Map<CharacterReadDTO>(character);
        }

    }
}
