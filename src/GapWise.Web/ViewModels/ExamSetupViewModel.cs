using System.ComponentModel.DataAnnotations;

namespace GapWise.Web.ViewModels;

public sealed class ExamSetupViewModel
{
    [Required(ErrorMessage = "Please choose a grade.")]
    [Display(Name = "Grade")]
    public string? Grade { get; set; }

    [Required(ErrorMessage = "Please choose a subject.")]
    [Display(Name = "Subject")]
    public string? Subject { get; set; }

    [Required(ErrorMessage = "Please choose an assessment type.")]
    [Display(Name = "Assessment type")]
    public string? AssessmentType { get; set; }

    [Range(10, 40, ErrorMessage = "Please choose the number of questions.")]
    public int QuestionCount { get; set; }

    [Required(ErrorMessage = "Please choose a time mode.")]
    [Display(Name = "Time mode")]
    public string? TimeMode { get; set; }
}
