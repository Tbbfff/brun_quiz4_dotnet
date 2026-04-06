using Microsoft.EntityFrameworkCore;

namespace brun_quiz4_dotnet.Models
{
    // -------------------------------------------------------
    // Data model
    // -------------------------------------------------------
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }

    // -------------------------------------------------------
    // EF Core DbContext (SQLite – local database)
    // -------------------------------------------------------
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }

    // -------------------------------------------------------
    // Database seeder – populates sample rows on first run
    // -------------------------------------------------------
    public static class DbSeeder
    {
        public static void Seed(AppDbContext db)
        {
            if (db.Products.Any()) return;   // already seeded

            db.Products.AddRange(
                new Product { Name = "Laptop",     Category = "Electronics", Price = 999.99m  },
                new Product { Name = "Desk Chair", Category = "Furniture",   Price = 249.50m  },
                new Product { Name = "Notebook",   Category = "Stationery",  Price = 4.99m    },
                new Product { Name = "Monitor",    Category = "Electronics", Price = 399.00m  },
                new Product { Name = "Keyboard",   Category = "Electronics", Price = 79.95m   }
            );
            db.SaveChanges();
        }
    }

    // -------------------------------------------------------
    // ViewModel passed to the Index view
    // -------------------------------------------------------
    public class HomeViewModel
    {
        public List<Product> Products { get; set; } = new();

        // *** Requirement 6 ***
        public string DatabaseMessage =>
            "Database access has already been done on April 6, 2026 by Bruno Farias";
    }
}
