using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class EditLocationModel : PageModel
{
    private ILocationService locationService;

    [BindProperty]
    public Location? location { get; set; }

    public EditLocationModel(ILocationService lS)
    {
        locationService = lS;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        location = await locationService.GetLocation(id);
        
        if (location == null) return RedirectToPage($"/Locations/LocationDetails/Index", new { id });

        return Page();
    }

    public async Task<IActionResult> OnPost (int id)
    {
        if (location != null && ModelState.IsValid)
        {
            location.Id = id;
            
            bool successful = await locationService.UpdateLocation(location);

            if (successful) return RedirectToPage($"/Locations/LocationDetails/Index", new { id });
        }
        
        return Page();
    }
}