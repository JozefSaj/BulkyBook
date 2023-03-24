using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
        }
        //creating category table in database
        public DbSet<Category> Categories { get; set; } //it will create a category table with the name of categories with 4 columns we have wrote in Categoty.cs
    }
}
