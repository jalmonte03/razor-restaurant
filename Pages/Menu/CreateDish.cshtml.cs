using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class CreateDishModel : PageModel 
{
    private readonly IDishService dishService;

    [BindProperty]
    public Dish Dish { get; set; } = new();

    public CreateDishModel(IDishService dishService)
    {
        this.dishService = dishService;
    }

    public IActionResult OnPost()
    {
        if(ModelState.IsValid)
        {
            dishService.CreateDish(Dish);
            
            return RedirectToPage("./Index");
        }
        else
        {
            return Page();
        }
    }
}