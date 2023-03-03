namespace web_api.Models
{
    public class QuestStage
    {
        public int QuestStageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool isCompleted { get; set; }
        public Quest Quest { get; set; }
    }
}
