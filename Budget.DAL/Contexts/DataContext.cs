using Budget.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Budget.DAL.Context
{
    public class DataContext : DbContext
    {
        private DbSet<User> Users { get; set; }
        private DbSet<Category> Categories { get; set; }
        private DbSet<Expense> Expansies { get; set; }
        private DbSet<Income> Incomies { get; set; }
        private DbSet<UserCategory> UserCategories { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .HasOne<User>(x => x.User)
                .WithMany(t => t.Expansies)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<Expense>()
                .HasOne<Category>(x => x.Category)
                .WithMany(t => t.Expansies)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<UserCategory>()
                .HasOne<User>(x => x.User)
                .WithMany(t => t.UserCategoryPct)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<UserCategory>()
                .HasOne<Category>(x => x.Category)
                .WithMany(t => t.UserCategoryPct)
                .HasForeignKey(x => x.CategoryId);

            modelBuilder.Entity<Income>()
                .HasOne<User>(x => x.User)
                .WithMany(t => t.Incomies)
                .HasForeignKey(x => x.UserId);
        }
    }
}
