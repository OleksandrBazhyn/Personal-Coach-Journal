using Microsoft.EntityFrameworkCore;
using Personal_Coach_Journal.db;

namespace Personal_Coach_Journal.Controllers
{
    public class DBController
    {
        public static void EnsureDatabase()
        {
            using var context = new AppDbContext();

            if (context.Database.EnsureCreated())
            {
                Console.WriteLine("✅ SQLite database is checked");
            }
        }

        public static void ApplyMigrations()
        {
            using var context = new AppDbContext();
            context.Database.Migrate();
            Console.WriteLine("✅ SQLite database is migrated");
        }
        public static void DeleteDatabase()
        {
            using var context = new AppDbContext();
            context.Database.EnsureDeleted();
            Console.WriteLine("✅ SQLite database is deleted");
        }
        public static string GetDatabasePath()
        {
            var dbPath = Environment.GetEnvironmentVariable("DB_PATH");
            return Path.GetFullPath(dbPath);
        }
    }
}
