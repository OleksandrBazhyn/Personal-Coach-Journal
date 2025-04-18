using Microsoft.EntityFrameworkCore;
using Personal_Coach_Journal.db;

namespace Personal_Coach_Journal.Controllers
{
    public class DBController
    {
        public static void EnsureDatabase()
        {
            try
            {
                using var context = new AppDbContext();

                if (context.Database.EnsureCreated())
                {
                    Console.WriteLine("✅ SQLite database is checked");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error ensuring database: {ex.Message}");
            }
        }

        public static void ApplyMigrations()
        {
            try
            {
                using var context = new AppDbContext();
                context.Database.Migrate();
                Console.WriteLine("✅ SQLite database is migrated");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error during migration: {ex.Message}");
            }
        }

        public static void DeleteDatabase()
        {
            try
            {
                using var context = new AppDbContext();
                context.Database.EnsureDeleted();
                Console.WriteLine("✅ SQLite database is deleted");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error deleting database: {ex.Message}");
            }
        }

        public static string GetDatabasePath()
        {
            try
            {
                var dbPath = Environment.GetEnvironmentVariable("DB_PATH");
                if (string.IsNullOrEmpty(dbPath))
                {
                    throw new InvalidOperationException("Environment variable 'DB_PATH' is not set.");
                }
                return Path.GetFullPath(dbPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error retrieving database path: {ex.Message}");
                throw;
            }
        }
    }
}
