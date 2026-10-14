using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace GapWise.Web.Models;

public sealed class ApplicationUser : IdentityUser
{
    [PersonalData]
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [PersonalData]
    [MaxLength(50)]
    public string LastName { get; set; } = string.Empty;
}
