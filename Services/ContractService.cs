using Microsoft.EntityFrameworkCore;
using web_api.Models;
using web_api.DTOs;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace web_api.Services
{
    public class ContractService
    {
        private readonly PogwartsContext _context;

        public ContractService(PogwartsContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Contract>> GetAllBaseContractsAsync()
        {
            var contracts = await _context.Contract.Where(c => c.ActiveCharacter == null).ToListAsync();
            return contracts;
        }

        public async Task<Contract> CreateActiveContractAsync(ContractCreateDTO ccdto)
        {
            var contractDetails = await _context.Contract.FirstAsync(c => c.Name == ccdto.Name);
            var character = await _context.Character.FirstAsync(c => c.Name == ccdto.ActiveCharacter);
            var contract = new Contract()
            {
                Name = contractDetails.Name,
                Description = contractDetails.Description,
                NumEnemies = contractDetails.NumEnemies,
                RewardCoins = contractDetails.RewardCoins,
                ActiveCharacter = ccdto.ActiveCharacter
            };
            character.ActiveContract = contract;
            _context.Contract.Add(contract);
            _context.SaveChanges();

            return contract;
        }

        public async Task<Contract> UpdateContract(ContractUpdateDTO cudto)
        {
            var contract = await _context.Contract.Where(c => c.Name == cudto.ContractName && c.ActiveCharacter == cudto.ActiveCharacter).FirstAsync();

            contract.NumEnemies = cudto.NumEnemies;

            await _context.SaveChangesAsync();

            return contract;
        }


        public async Task DeleteContractAsync(ContractUpdateDTO cudto)
        {
            var contract = await _context.Contract.Where(c => c.Name == cudto.ContractName && c.ActiveCharacter == cudto.ActiveCharacter).FirstAsync();
            
            _context.Contract.Remove(contract);

            await _context.SaveChangesAsync();

        }


    }
}
