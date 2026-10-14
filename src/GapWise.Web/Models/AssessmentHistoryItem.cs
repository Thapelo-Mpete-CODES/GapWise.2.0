namespace GapWise.Web.Models;

public sealed class AssessmentHistoryItem
{
    public DateTime DateTaken { get; init; }
    public string Subject { get; init; } = "Mathematics";
    public int Percentage { get; init; }
    public string StrongestTopic { get; init; } = string.Empty;
    public string WeakestTopic { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
}
