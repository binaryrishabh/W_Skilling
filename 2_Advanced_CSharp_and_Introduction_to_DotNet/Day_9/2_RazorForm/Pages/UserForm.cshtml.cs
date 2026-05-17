using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _2_RazorForm.Pages;

public class UserFormModel : PageModel
{
    [BindProperty]
    public string FirstName { get; set; } = string.Empty;

    public string SubmittedName { get; private set; } = string.Empty;

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!string.IsNullOrEmpty(FirstName))
        {
            SubmittedName = FirstName;
        }
        return Page();
    }
}