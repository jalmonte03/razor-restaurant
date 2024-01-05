using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class CreateLocationModel : PageModel
{
    private readonly ILocationService locationService;

    public CreateLocationModel(ILocationService locationService)
    {
        this.locationService = locationService;
    }

    [BindProperty]
    public Location location { get; set; } = new();

    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid)
        {
            Console.WriteLine($"{location.Name} {location.Phone} {location.State}");
            Location? newLocation = await locationService.CreateLocation(location);

            if (newLocation is null) return Page();

            return RedirectToPage("/Locations/Index");
        } 

        return Page();
    }
}