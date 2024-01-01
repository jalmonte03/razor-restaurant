using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class EditDishModel : PageModel 
{
    private readonly IDishService dishService;

    [BindProperty]
    public Dish? Dish { get; set; } = null;

    public EditDishModel(IDishService dishService)
    {
        this.dishService = dishService;
    }

    public async Task<IActionResult> OnGet(int id)
    {
        Dish? foundDish  = await dishService.GetDish(id);

        if (foundDish is null) 
        {
            return RedirectToPage("./Index");
        }
        else
        {
            Dish = foundDish;
        }

        return Page();
    }

    public async Task<IActionResult> OnPost(string Id)
    {  
        if(ModelState.IsValid && Dish != null)
        {
            Dish.Id = int.Parse(Id);
            bool updated = await dishService.UpdateDish(Dish);
            
            if (updated)
                return RedirectToPage("/Menu/DishDetails/Index", new { id = Dish.Id });

            return Page();
        }
        else
        {
            return Page();
        }
    }
}