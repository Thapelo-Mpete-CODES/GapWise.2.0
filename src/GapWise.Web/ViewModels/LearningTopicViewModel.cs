namespace GapWise.Web.ViewModels;

public sealed class LearningTopicViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Overview { get; init; } = string.Empty;
    public string Difficulty { get; init; } = string.Empty;
    public string StudyTime { get; init; } = string.Empty;
    public IReadOnlyList<string> LearningObjectives { get; init; } = [];
    public IReadOnlyList<string> KeyConcepts { get; init; } = [];
    public string WorkedExample { get; init; } = string.Empty;
    public IReadOnlyList<string> StudyTips { get; init; } = [];
    public IReadOnlyList<string> CommonMistakes { get; init; } = [];
    public IReadOnlyList<string> ExamTips { get; init; } = [];
    public string Summary { get; init; } = string.Empty;
    public string VideoUrl { get; init; } = string.Empty;
}
