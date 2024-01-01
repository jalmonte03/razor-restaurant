using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class DeleteDishModel : PageModel
{
    private readonly IDishService dishService;

    [BindProperty]
    public Dish? Dish { get; set; } = null;

    public DeleteDishModel(IDishService dishService)
    {
        this.dishService = dishService;
    }

    public async void OnGet(int id)
    {
        Dish  = await dishService.GetDish(id);

        if (Dish is null) 
        {
            RedirectToPage("./Index");
            return;
        }
    }

    public async Task<IActionResult> OnPostDelete(int id)
    {
        Dish  = await dishService.GetDish(id);

        if (Dish is null) 
        {
            return RedirectToPage("./Index");
        }

        bool removed = await dishService.RemoveDish(id);

        if (removed)
        {
            Console.WriteLine($"Product \"{Dish.Name}\" was successfully removed.");
            return RedirectToPage("/Menu/Index");
        }

        return Page();
    }

    public IActionResult OnPostCancel(int id)
    {
        Console.WriteLine("Canceling delete of product");
        return RedirectToPage("/Menu/EditDish", new { id = id });
    }
}