using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Service;


public class NewsletterApiPageModel : PageModel
{
    private INewsletterService newsletterService;

    public NewsletterApiPageModel(INewsletterService nS)
    {
        this.newsletterService = nS;
    }

    public IActionResult OnGet()
    {
        var response = new 
        {
            id = 1,
            success = "The request was successful",
            added = true
        };
        return new JsonResult(response);
    }

    public IActionResult OnPost(string Email)
    {
        try
        {        
            bool success = newsletterService.AddEmail(Email);

            if (!success) return BadRequest("The email couldn't be added to the newsletter list. Try again in a few minutes.");

            var response = new
            {
                message = $"The email '{Email}' was added successfully to the newsletter list",
            };

            return new JsonResult(response);
        }
        catch (Exception ex)
        {
            return BadRequest(new {
                error = true,
                message = ex.Message
            });
        }
    }
}