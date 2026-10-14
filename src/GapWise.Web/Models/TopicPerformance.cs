namespace GapWise.Web.Models;

public sealed class TopicPerformance
{
    public string Topic { get; init; } = string.Empty;
    public int CorrectAnswers { get; init; }
    public int TotalQuestions { get; init; }
    public int Percentage { get; init; }
    public bool NeedsImprovement { get; init; }
}
