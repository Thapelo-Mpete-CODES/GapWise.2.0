using GapWise.Web.Models;

namespace GapWise.Web.Interfaces;

public interface IAssessmentService
{
    IReadOnlyList<AssessmentQuestion> GetMathematicsQuestions();

    AssessmentResult MarkAssessment(IReadOnlyDictionary<int, string>? answers);

    IReadOnlyList<AssessmentHistoryItem> GetAssessmentHistory();
}
