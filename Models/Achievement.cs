namespace web_api.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }
        public bool IsHidden { get; set; }
        public ICollection<Character> CharactersCompleted { get; set; }
    }
}
