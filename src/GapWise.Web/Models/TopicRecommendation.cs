namespace GapWise.Web.Models;

public sealed class TopicRecommendation
{
    public string Topic { get; init; } = string.Empty;
    public string Message { get; init; } = string.Empty;
    public bool NeedsImprovement { get; init; }
}
