namespace GapWise.Web.Models;

public sealed class AssessmentQuestion
{
    public int Id { get; init; }

    public string Text { get; init; } = string.Empty;

    public string Topic { get; init; } = string.Empty;

    public IReadOnlyDictionary<string, string> Options { get; init; } = new Dictionary<string, string>();

    public string CorrectOption { get; init; } = string.Empty;
}
