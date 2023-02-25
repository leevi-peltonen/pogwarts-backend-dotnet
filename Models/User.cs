using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace web_api.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Character>? Characters { get; set; }
    }
}
