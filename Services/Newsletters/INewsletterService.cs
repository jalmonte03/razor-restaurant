using Restaurant.Website.Models;

namespace Restaurant.Website.Service;

public interface INewsletterService
{
    public bool AddEmail(string email);
    public bool DeleteEmail(int id);
    public IEnumerable<Newsletter> GetNewsletters();
}