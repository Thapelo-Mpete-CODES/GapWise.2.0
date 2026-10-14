using GapWise.Web.Models;
using GapWise.Web.Interfaces;
using GapWise.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GapWise.Web.Controllers;

[Authorize]
public sealed class DashboardController(UserManager<ApplicationUser> userManager, IAssessmentService assessmentService) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var user = await userManager.GetUserAsync(User);
        if (user is null)
        {
            return Challenge();
        }

        var attempts = assessmentService.GetAssessmentHistory();
        var latestAttempt = attempts.FirstOrDefault();
        var averageScore = attempts.Count == 0 ? null : (int?)Math.Round(attempts.Average(attempt => attempt.Percentage));

        return View(new DashboardViewModel
        {
            FirstName = user.FirstName,
            AssessmentsCompleted = attempts.Count,
            LatestAssessmentScore = latestAttempt?.Percentage,
            AverageScore = averageScore,
            StrongestTopic = latestAttempt?.StrongestTopic ?? "Not available yet",
            WeakestTopic = latestAttempt?.WeakestTopic ?? "Not available yet",
            LearningStatus = GetLearningStatus(averageScore),
            LearningProgress = averageScore ?? 0,
            LatestRecommendation = latestAttempt is null
                ? "Complete a diagnostic assessment to receive a personalized recommendation."
                : $"Build confidence in {latestAttempt.WeakestTopic} by completing its focused learning guide."
        });
    }

    private static string GetLearningStatus(int? averageScore) => averageScore switch
    {
        >= 75 => "Excellent",
        >= 60 => "Good",
        _ => "Needs Improvement"
    };
}
