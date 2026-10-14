namespace GapWise.Web.ViewModels;

public sealed class LearningSubjectViewModel
{
    public string Subject { get; init; } = string.Empty;
    public IReadOnlyList<LearningTopicCardViewModel> Topics { get; init; } = [];
}

public sealed class LearningTopicCardViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Difficulty { get; init; } = string.Empty;
    public string StudyTime { get; init; } = string.Empty;
}
