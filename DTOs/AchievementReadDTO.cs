namespace web_api.DTOs
{
    public class AchievementReadDTO
    {
        public int AchievementId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }
        public bool IsHidden { get; set; }
    }
}
