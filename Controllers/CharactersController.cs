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

namespace web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public async Task<ActionResult<CharacterReadDTO>> CreateCharacter([FromBody] CharacterCreateDTO character)
        {
            Character characterToCreate = _mapper.Map<Character>(character);
            var returnCharacter = await _characterService.CreateCharacterAsync(characterToCreate);
            return _mapper.Map<CharacterReadDTO>(returnCharacter);
        }

    }
}
