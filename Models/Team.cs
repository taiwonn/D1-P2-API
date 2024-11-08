public class Team
{
    public int TeamId { get; set; }
    public required string TeamName { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int? CoachId { get; set; }
    public int TotalScore { get; set; }
}
