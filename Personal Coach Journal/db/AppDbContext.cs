using Microsoft.EntityFrameworkCore;
using Personal_Coach_Journal.Models;
using System;
using System.IO;

namespace Personal_Coach_Journal.db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var relativePath = Environment.GetEnvironmentVariable("DB_PATH") ?? "db/personal_coach_journal.db";
            var basePath = AppContext.BaseDirectory;
            var dbPath = Path.Combine(basePath, relativePath);

            Directory.CreateDirectory(Path.GetDirectoryName(dbPath)!);

            options.UseSqlite($"Data Source={dbPath}");
        }
    }
}
