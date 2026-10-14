using GapWise.Web.Interfaces;
using GapWise.Web.Models;

namespace GapWise.Web.Services;

public sealed class MockAssessmentService : IAssessmentService
{
    private static readonly IReadOnlyList<AssessmentQuestion> Questions =
    [
        Question(1, "Solve for x: 4x + 8 = 28.", "Algebra", "B", ("A", "x = 4"), ("B", "x = 5"), ("C", "x = 6"), ("D", "x = 7")),
        Question(2, "Simplify: 3a + 5b - a + 2b.", "Algebra", "C", ("A", "2a + 3b"), ("B", "4a + 7b"), ("C", "2a + 7b"), ("D", "3a + 7b")),
        Question(3, "What is the value of 2 to the power of 4?", "Algebra", "D", ("A", "6"), ("B", "8"), ("C", "12"), ("D", "16")),
        Question(4, "Factorise: x squared - 9.", "Algebra", "A", ("A", "(x - 3)(x + 3)"), ("B", "(x - 9)(x + 1)"), ("C", "(x - 3) squared"), ("D", "x(x - 9)")),
        Question(5, "If y = 3x - 2, what is y when x = 4?", "Algebra", "B", ("A", "8"), ("B", "10"), ("C", "12"), ("D", "14")),
        Question(6, "If f(x) = 2x + 3, what is f(5)?", "Functions", "C", ("A", "7"), ("B", "10"), ("C", "13"), ("D", "15")),
        Question(7, "What is the gradient of y = -3x + 4?", "Functions", "A", ("A", "-3"), ("B", "3"), ("C", "4"), ("D", "-4")),
        Question(8, "Which point lies on y = x + 2?", "Functions", "D", ("A", "(1, 1)"), ("B", "(2, 2)"), ("C", "(3, 4)"), ("D", "(3, 5)")),
        Question(9, "The graph of y = x squared is a:", "Functions", "B", ("A", "straight line"), ("B", "parabola"), ("C", "circle"), ("D", "hyperbola")),
        Question(10, "What is the y-intercept of y = 5x - 7?", "Functions", "C", ("A", "5"), ("B", "-5"), ("C", "-7"), ("D", "7")),
        Question(11, "What is the sum of the interior angles of a triangle?", "Geometry", "A", ("A", "180 degrees"), ("B", "270 degrees"), ("C", "360 degrees"), ("D", "90 degrees")),
        Question(12, "A rectangle is 8 cm by 5 cm. What is its area?", "Geometry", "D", ("A", "13 square cm"), ("B", "26 square cm"), ("C", "30 square cm"), ("D", "40 square cm")),
        Question(13, "What is the hypotenuse of a right triangle with sides 6 cm and 8 cm?", "Geometry", "B", ("A", "9 cm"), ("B", "10 cm"), ("C", "12 cm"), ("D", "14 cm")),
        Question(14, "Each exterior angle of a regular hexagon is:", "Geometry", "C", ("A", "45 degrees"), ("B", "50 degrees"), ("C", "60 degrees"), ("D", "72 degrees")),
        Question(15, "What is the circumference of a circle with radius 3 cm?", "Geometry", "A", ("A", "6 pi cm"), ("B", "3 pi cm"), ("C", "9 pi cm"), ("D", "12 pi cm")),
        Question(16, "What is sin 30 degrees?", "Trigonometry", "B", ("A", "0"), ("B", "1/2"), ("C", "1"), ("D", "square root of 3 / 2")),
        Question(17, "In a right triangle, SOH refers to:", "Trigonometry", "D", ("A", "side over hypotenuse"), ("B", "sine over height"), ("C", "sum of hypotenuse"), ("D", "sine equals opposite over hypotenuse")),
        Question(18, "What is cos 60 degrees?", "Trigonometry", "A", ("A", "1/2"), ("B", "0"), ("C", "1"), ("D", "square root of 3 / 2")),
        Question(19, "If opposite = 4 and adjacent = 3, tan theta is:", "Trigonometry", "C", ("A", "3/4"), ("B", "5/3"), ("C", "4/3"), ("D", "3/5")),
        Question(20, "Which ratio is cosine?", "Trigonometry", "B", ("A", "opposite / hypotenuse"), ("B", "adjacent / hypotenuse"), ("C", "opposite / adjacent"), ("D", "hypotenuse / opposite"))
    ];

    private readonly List<AssessmentHistoryItem> attempts = [];
    private readonly object attemptsLock = new();

    public IReadOnlyList<AssessmentQuestion> GetMathematicsQuestions() => Questions;

    public AssessmentResult MarkAssessment(IReadOnlyDictionary<int, string>? answers)
    {
        var topicPerformance = Questions.GroupBy(question => question.Topic).Select(group =>
        {
            var correct = group.Count(question => answers is not null && answers.TryGetValue(question.Id, out var answer) && answer == question.CorrectOption);
            var total = group.Count();
            var percentage = correct * 100 / total;
            return new TopicPerformance { Topic = group.Key, CorrectAnswers = correct, TotalQuestions = total, Percentage = percentage, NeedsImprovement = percentage < 75 };
        }).ToList();
        var correctAnswers = topicPerformance.Sum(topic => topic.CorrectAnswers);
        var percentage = correctAnswers * 100 / Questions.Count;
        var strongestTopic = topicPerformance.OrderByDescending(topic => topic.Percentage).ThenByDescending(topic => topic.CorrectAnswers).First().Topic;
        var weakestTopic = topicPerformance.OrderBy(topic => topic.Percentage).ThenBy(topic => topic.CorrectAnswers).First().Topic;
        var (performanceLevel, feedback) = percentage switch
        {
            < 40 => ("Needs Immediate Attention", "Focus on core Mathematics concepts before attempting another diagnostic assessment."),
            < 60 => ("Needs Improvement", "You have a foundation to build on. Target the topics below and practise regularly."),
            < 75 => ("Average", "You are making good progress. Strengthen the topics below to improve your confidence."),
            _ => ("Strong Performance", "Excellent work. Keep practising to maintain your strong Mathematics foundation.")
        };
        var result = new AssessmentResult
        {
            TotalScore = correctAnswers, TotalQuestions = Questions.Count, Percentage = percentage, CorrectAnswers = correctAnswers, IncorrectAnswers = Questions.Count - correctAnswers,
            PerformanceLevel = performanceLevel, SubjectFeedback = feedback, StrongestTopic = strongestTopic, WeakestTopic = weakestTopic, TopicPerformance = topicPerformance,
            Recommendations = topicPerformance.Select(topic => new TopicRecommendation
            {
                Topic = topic.Topic, NeedsImprovement = topic.NeedsImprovement,
                Message = topic.NeedsImprovement
                    ? $"Revise {topic.Topic} fundamentals, practise focused questions, and complete another {topic.Topic} diagnostic."
                    : $"Your {topic.Topic} performance is strong. Maintain it with mixed practice questions."
            }).ToList()
        };
        lock (attemptsLock)
        {
            attempts.Add(new AssessmentHistoryItem { DateTaken = DateTime.Now, Percentage = result.Percentage, StrongestTopic = strongestTopic, WeakestTopic = weakestTopic, Status = performanceLevel });
        }
        return result;
    }

    public IReadOnlyList<AssessmentHistoryItem> GetAssessmentHistory()
    {
        lock (attemptsLock)
        {
            return attempts.OrderByDescending(attempt => attempt.DateTaken).ToList();
        }
    }

    private static AssessmentQuestion Question(int id, string text, string topic, string correctOption, params (string Key, string Value)[] options) => new() { Id = id, Text = text, Topic = topic, CorrectOption = correctOption, Options = options.ToDictionary(option => option.Key, option => option.Value) };
}
