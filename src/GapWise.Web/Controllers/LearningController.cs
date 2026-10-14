using GapWise.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GapWise.Web.Controllers;

[Authorize]
public sealed class LearningController : Controller
{
    private static readonly IReadOnlyDictionary<string, LearningTopicViewModel> MathematicsTopics = new Dictionary<string, LearningTopicViewModel>(StringComparer.OrdinalIgnoreCase)
    {
        ["Algebra"] = Topic("Algebra", "Build confidence with symbols, expressions, equations, and patterns.", "Foundation", "45 minutes", ["Simplify algebraic expressions accurately.", "Solve linear equations step by step.", "Factorise common algebraic forms."], ["Like terms can be combined.", "Use inverse operations to isolate a variable.", "Check solutions by substitution."], "Solve 3x + 5 = 20. Subtract 5 from both sides to get 3x = 15, then divide by 3. Therefore x = 5.", ["Write one clear step per line.", "Keep both sides of an equation balanced.", "Practise short questions before mixed problems."], ["Combining unlike terms.", "Forgetting to change signs when moving terms.", "Skipping the final check."], ["Show all working for method marks.", "Underline the value requested.", "Estimate whether your answer is reasonable."], "Algebra is the language of Mathematics. Strong equation skills support functions, graphs, and problem solving.", "https://www.youtube.com/results?search_query=algebra+basics+grade+10"),
        ["Functions"] = Topic("Functions", "Understand input-output rules, graphs, gradients, and intercepts.", "Intermediate", "50 minutes", ["Identify a function rule and evaluate values.", "Read key information from a graph.", "Connect equations to graph behaviour."], ["f(x) represents an output.", "Gradient describes rate of change.", "The y-intercept is where x equals zero."], "For f(x) = 2x + 3, calculate f(4): 2(4) + 3 = 11. The input is 4 and the output is 11.", ["Make a small table of values before sketching.", "Label axes and intercepts clearly.", "Compare changes in x and y to find gradient."], ["Confusing the x-intercept with the y-intercept.", "Ignoring negative signs in a rule.", "Using an uneven graph scale."], ["Read the question before choosing a graph method.", "Use graph paper carefully.", "State coordinates in the order (x, y)."], "Functions link algebra to visual patterns. Use tables, rules, and graphs together to deepen understanding.", "https://www.youtube.com/results?search_query=functions+and+graphs+grade+10"),
        ["Geometry"] = Topic("Geometry", "Develop spatial reasoning with angles, shapes, measurement, and proofs.", "Intermediate", "55 minutes", ["Use angle relationships in geometric figures.", "Apply perimeter, area, and Pythagoras correctly.", "Justify statements using geometry theorems."], ["Angles in a triangle total 180 degrees.", "Area measures surface inside a shape.", "Pythagoras applies only to right-angled triangles."], "A right triangle has sides 6 cm and 8 cm. c squared = 6 squared + 8 squared = 100, so c = 10 cm.", ["Draw and label a diagram first.", "Write the theorem before substituting values.", "Include units in measurement answers."], ["Using Pythagoras on a non-right triangle.", "Mixing area and perimeter units.", "Giving a reason that does not match a statement."], ["Mark known angles on the diagram.", "Memorise the most common angle rules.", "Leave proof questions for a final reason check."], "Geometry rewards careful diagrams and clear reasons. Build a personal theorem list as you study.", "https://www.youtube.com/results?search_query=geometry+basics+grade+10"),
        ["Trigonometry"] = Topic("Trigonometry", "Use right-triangle ratios and angle relationships to solve measurement problems.", "Intermediate", "50 minutes", ["Identify opposite, adjacent, and hypotenuse sides.", "Choose the correct trigonometric ratio.", "Calculate an unknown side or angle."], ["SOH CAH TOA links ratios to sides.", "Calculator mode must match the question.", "A right angle is essential for basic trigonometry."], "If opposite = 4 and adjacent = 3, tan theta = 4/3. Use inverse tan on a calculator to find theta.", ["Label sides relative to the chosen angle.", "Write the ratio before entering values.", "Round only at the final step."], ["Using sine when tangent is needed.", "Leaving the calculator in radians.", "Rounding too early."], ["Draw a clear right triangle.", "Use the degree symbol for angles.", "Check whether the answer is sensible for the diagram."], "Trigonometry becomes easier when every problem starts with a labelled triangle and a deliberate ratio choice.", "https://www.youtube.com/results?search_query=trigonometry+SOHCAHTOA+grade+10")
    };

    [HttpGet]
    public IActionResult Index() => View(new LearningHubViewModel
    {
        Subjects =
        [
            new() { Name = "Mathematics", Description = "Topic guides and targeted revision for core CAPS Mathematics skills.", IsAvailable = true },
            new() { Name = "Mathematical Literacy", Description = "Everyday problem-solving and quantitative reasoning resources.", IsAvailable = false },
            new() { Name = "Physical Sciences", Description = "Structured support for Physics and Chemistry concepts.", IsAvailable = false },
            new() { Name = "Life Sciences", Description = "Clear study pathways for Biology and life processes.", IsAvailable = false },
            new() { Name = "Accounting", Description = "Practical support for accounting principles and practice.", IsAvailable = false },
            new() { Name = "English FAL", Description = "Language, comprehension, and writing support.", IsAvailable = false }
        ]
    });

    [HttpGet]
    public IActionResult Subject(string id)
    {
        if (!string.Equals(id, "Mathematics", StringComparison.OrdinalIgnoreCase)) return RedirectToAction(nameof(Index));
        return View(new LearningSubjectViewModel { Subject = "Mathematics", Topics = MathematicsTopics.Values.Select(topic => new LearningTopicCardViewModel { Name = topic.Name, Description = topic.Overview, Difficulty = topic.Difficulty, StudyTime = topic.StudyTime }).ToList() });
    }

    [HttpGet]
    public IActionResult Topic(string id)
    {
        return MathematicsTopics.TryGetValue(id, out var topic) ? View(topic) : RedirectToAction(nameof(Subject), new { id = "Mathematics" });
    }

    private static LearningTopicViewModel Topic(string name, string overview, string difficulty, string studyTime, IReadOnlyList<string> objectives, IReadOnlyList<string> concepts, string example, IReadOnlyList<string> tips, IReadOnlyList<string> mistakes, IReadOnlyList<string> examTips, string summary, string videoUrl) => new() { Name = name, Overview = overview, Difficulty = difficulty, StudyTime = studyTime, LearningObjectives = objectives, KeyConcepts = concepts, WorkedExample = example, StudyTips = tips, CommonMistakes = mistakes, ExamTips = examTips, Summary = summary, VideoUrl = videoUrl };
}
