using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace _1_RazorFirstApp.Pages;

public class IndexModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string Name { get; set; } = "Rishabh";

    public void OnGet() { }

    public IActionResult OnPost()
    {
        return Page();
    }
}