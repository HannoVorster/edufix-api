using EduFix_Api.Data;
using Microsoft.EntityFrameworkCore;

namespace SLeak_Backend.Data
{
    public class EduFixContext : DbContext
    {
        public EduFixContext(DbContextOptions<EduFixContext> options) : base(options)
        {
        }

        public DbSet<DropDownValues>? DropdownValues { get; set; }
        public DbSet<Requests>? Requests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DropDownValues>().ToTable("DropDownValues");
            modelBuilder.Entity<Requests>().ToTable("Requests");
        }
    }
}