using Checkr.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Checkr.Services.Context
{
    public class ApplicationDbContext(DbContextOptions options) : IdentityDbContext<User>(options)
    {
        public DbSet<Board> Boards { get; set; }

        public DbSet<Box> Boxes { get; set; }

        public DbSet<Card> Cards { get; set; }

        public DbSet<ToDoItem> ToDoItems { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Boards)
                .WithMany(b => b.Users)
                .UsingEntity(j => j.ToTable("UserBoards"));

            modelBuilder.Entity<Box>()
                .HasMany(b => b.Tags)
                .WithMany(l => l.Boxes)
                .UsingEntity(j => j.ToTable("BoxTags"));
        }
    }
}
