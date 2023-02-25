using web_api.Models;

namespace web_api.DTOs
{
    public class UserReadDTO
    {
        public string Name { get; set; }
        public ICollection<CharacterReadDTO>? Characters { get; set; }
    }
}
