namespace GapWise.Web.ViewModels;

public sealed class LearningHubViewModel
{
    public IReadOnlyList<LearningSubjectCardViewModel> Subjects { get; init; } = [];
}

public sealed class LearningSubjectCardViewModel
{
    public string Name { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public bool IsAvailable { get; init; }
}
