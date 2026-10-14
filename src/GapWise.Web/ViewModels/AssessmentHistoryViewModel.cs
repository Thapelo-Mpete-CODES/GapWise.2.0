using GapWise.Web.Models;

namespace GapWise.Web.ViewModels;

public sealed class AssessmentHistoryViewModel
{
    public IReadOnlyList<AssessmentHistoryItem> Attempts { get; init; } = [];
}
