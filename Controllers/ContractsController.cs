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
    public class ContractsController : ControllerBase
    {
        private readonly ContractService _contractService;
        private readonly IMapper _mapper;

        public ContractsController(ContractService contractService, IMapper mapper)
        {
            _contractService = contractService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<ContractReadDTO>>> GetAllBaseContracts()
        {
            var contracts = await _contractService.GetAllBaseContractsAsync();
            var mappedContracts = new List<ContractReadDTO>();

            foreach (var item in contracts)
            {
                mappedContracts.Add(_mapper.Map<ContractReadDTO>(item));
            }

            return mappedContracts;
        }

        [HttpPost("new")]
        public async Task<ActionResult<ContractReadDTO>> CreateActiveContract([FromBody] ContractCreateDTO ccdto)
        {
            var contract = await _contractService.CreateActiveContractAsync(ccdto);
            return _mapper.Map<ContractReadDTO>(contract);
        }

        [HttpPatch("update")]
        public async Task<ActionResult<ContractReadDTO>> UpdateContract([FromBody] ContractUpdateDTO cudto)
        {
            var contract = await _contractService.UpdateContract(cudto);
            return _mapper.Map<ContractReadDTO>(contract);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteContract([FromBody] ContractUpdateDTO cudto)
        {
            await _contractService.DeleteContractAsync(cudto);
            return Ok();
        }

    }
}
