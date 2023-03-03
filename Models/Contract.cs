using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class Contract
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ContractId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumEnemies { get; set; }
        public int RewardCoins { get; set; }
        public string? ActiveCharacter { get; set; }
    }
}
