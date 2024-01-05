using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class DeleteLocationModel : PageModel
{
    private ILocationService locationService;
    public Location? location { get; set; }

    public DeleteLocationModel(ILocationService lS)
    {
        locationService = lS;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        location = await locationService.GetLocation(id);
        if (location == null) return RedirectToPage("/locations/index");

        return Page();
    }

    public IActionResult OnPostCancel(int id)
    {
        return RedirectToPage("/locations/locationdetails/index", new { id });
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        bool deleted = await locationService.DeleteLocation(id);

        if (deleted)
            return RedirectToPage("/locations/index");

        return Page();
    }
}