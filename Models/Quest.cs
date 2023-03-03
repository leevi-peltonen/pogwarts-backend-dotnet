namespace web_api.Models
{
    public class Quest
    {
        public int QuestId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Reward { get; set; }
        public int Difficulty { get; set; }
        public ICollection<Enemy> EnemyList { get; set; }
        public ICollection<string>? ActiveCharacterList { get; set; }
        public ICollection<string> CompletedCharacterList { get; set; }
        public int CurrentStage { get; set; }
        public ICollection<QuestStage> QuestStages { get; set; }
    }
}
