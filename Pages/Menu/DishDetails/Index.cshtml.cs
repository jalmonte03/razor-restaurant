using Microsoft.AspNetCore.Mvc.RazorPages;

public class DishDetailsModel : PageModel
{
    public int DishId { get; set; }

    public void OnGet(int id)
    {
        DishId = id;
    }
} 