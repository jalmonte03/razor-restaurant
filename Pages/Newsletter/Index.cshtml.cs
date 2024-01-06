using Microsoft.AspNetCore.Mvc.RazorPages;
using Restaurant.Website.Models;
using Restaurant.Website.Service;

public class NewsletterPageModel : PageModel
{
    private int EmailCount { get; set; } = 0;
    public int CurrentPage { get; set; } = 1;
    private const int NEWSLETTER_ITEMS = 5;
    public int TotalPages {
        get 
        {
            return (int)Math.Ceiling(EmailCount / Convert.ToDouble(NEWSLETTER_ITEMS));
        }
    }
    private INewsletterService newsletterService;
    public IEnumerable<Newsletter> emailList { get; set; } = Enumerable.Empty<Newsletter>();


    public NewsletterPageModel(INewsletterService nS)
    {
        this.newsletterService = nS;
    }

    public void OnGet(int p = 1)
    {
        CurrentPage = p;
        (emailList, EmailCount) = newsletterService.GetNewsletters(CurrentPage, NEWSLETTER_ITEMS);
    }

    public void OnPost()
    {

    }
}