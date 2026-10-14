namespace GapWise.Web.Models;

public sealed class AssessmentResult
{
    public int TotalScore { get; init; }

    public int TotalQuestions { get; init; }

    public int Percentage { get; init; }

    public int CorrectAnswers { get; init; }

    public int IncorrectAnswers { get; init; }

    public string PerformanceLevel { get; init; } = string.Empty;

    public string SubjectFeedback { get; init; } = string.Empty;

    public string StrongestTopic { get; init; } = string.Empty;

    public string WeakestTopic { get; init; } = string.Empty;

    public IReadOnlyList<TopicPerformance> TopicPerformance { get; init; } = [];

    public IReadOnlyList<TopicRecommendation> Recommendations { get; init; } = [];
}
