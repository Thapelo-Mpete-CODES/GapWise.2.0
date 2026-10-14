namespace GapWise.Web.ViewModels;

public sealed class DashboardViewModel
{
    public string FirstName { get; init; } = string.Empty;

    public int AssessmentsCompleted { get; init; }
    public int? LatestAssessmentScore { get; init; }
    public int? AverageScore { get; init; }
    public string StrongestTopic { get; init; } = "Not available yet";
    public string WeakestTopic { get; init; } = "Not available yet";
    public string LearningStatus { get; init; } = "Needs Improvement";
    public int LearningProgress { get; init; }
    public string LatestRecommendation { get; init; } = "Complete a diagnostic assessment to receive a personalized recommendation.";
}
