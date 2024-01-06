using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class DeleteNewsletterPageModel : PageModel
{
    private INewsletterService newsletterService;
    public Newsletter? newsletter { get; set; }

    public DeleteNewsletterPageModel(INewsletterService nS)
    {
        newsletterService = nS;
    }

    public IActionResult OnGet(int id)
    {
        newsletter = newsletterService.GetNewsletter(id);

        if (newsletter == null)
            return RedirectToPage("/Newsletter/Index");

        return Page();
    }

    public IActionResult OnPostDelete(int id)
    {
        bool deleted = newsletterService.DeleteEmail(id);
        if (deleted)
        {
            return RedirectToPage("/Newsletter/Index");
        }
            
        newsletter = newsletterService.GetNewsletter(id);
        return Page();
    }

    public IActionResult OnPostCancel()
    {
        return RedirectToPage("/Newsletter/Index");
    }
}