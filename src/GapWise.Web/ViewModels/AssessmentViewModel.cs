using GapWise.Web.Models;

namespace GapWise.Web.ViewModels;

public sealed class AssessmentViewModel
{
    public IReadOnlyList<AssessmentQuestion> Questions { get; init; } = [];

    public Dictionary<int, string> Answers { get; set; } = [];
}
