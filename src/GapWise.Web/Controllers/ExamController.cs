using System.Text.Json;
using GapWise.Web.Interfaces;
using GapWise.Web.Models;
using GapWise.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GapWise.Web.Controllers;

[Authorize]
public sealed class ExamController(IAssessmentService assessmentService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View(new ExamSetupViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(ExamSetupViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        return RedirectToAction(nameof(Take));
    }

    [HttpGet]
    public IActionResult Take()
    {
        return View(new AssessmentViewModel
        {
            Questions = assessmentService.GetMathematicsQuestions()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Submit(AssessmentViewModel model)
    {
        var result = assessmentService.MarkAssessment(model.Answers);
        TempData["AssessmentResult"] = JsonSerializer.Serialize(result);

        return RedirectToAction(nameof(Results));
    }

    [HttpGet]
    public IActionResult Results()
    {
        if (TempData["AssessmentResult"] is not string serializedResult)
        {
            return RedirectToAction(nameof(Index));
        }

        var result = JsonSerializer.Deserialize<AssessmentResult>(serializedResult);
        if (result is null)
        {
            return RedirectToAction(nameof(Index));
        }

        return View(new AssessmentResultsViewModel { Result = result });
    }

    [HttpGet]
    public IActionResult History()
    {
        return View(new AssessmentHistoryViewModel
        {
            Attempts = assessmentService.GetAssessmentHistory()
        });
    }
}
