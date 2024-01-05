using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Restaurant.Website.Models;
using Restaurant.Website.Shared;

namespace Restaurant.Website.Service;

public class NewsletterService : INewsletterService
{
    private RestaurantContext db;

    public NewsletterService(RestaurantContext db)
    {
        this.db = db;
    }

    public bool AddEmail(string email)
    {
        try
        {
            Newsletter newsletter = new()
            {
                Email = email,
                Created = DateTime.Now
            };

            db.newsletters.Add(newsletter);
            int modified = db.SaveChanges();

            if (modified == 1)
                return true;

            return false;
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException is SqliteException)
            {
                bool IsUniqueError = ex.InnerException.Message.Contains("UNIQUE");
                if(IsUniqueError) {
                    throw new Exception("This email is already in the newsletter list.");
                }
            }
            
            throw new Exception("An unknown error happen");
        }
    }

    public bool DeleteEmail(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Newsletter> GetNewsletters()
    {
        throw new NotImplementedException();
    }
}