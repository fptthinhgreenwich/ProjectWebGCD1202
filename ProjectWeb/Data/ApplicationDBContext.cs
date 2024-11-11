using Microsoft.EntityFrameworkCore;
using ProjectWeb.Models;

namespace ProjectWeb.Data
{
    public class ApplicationDBContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
		public DbSet<Book> Books { get; set; }
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Adventure", Description = "Give you a feel of challenge", DisplayPriority = 1 },
                new Category { Id = 2, Name = "Roman", Description = "So romantique", DisplayPriority = 4 },
                new Category { Id = 3, Name = "Horror", Description = "So scary", DisplayPriority = 3 },
                new Category { Id = 4, Name = "Scifi", Description = "So interesting", DisplayPriority = 2 }
                );
			modelBuilder.Entity<Book>().HasData(
	           new Book { Id = 1, Title = "Into the Wild", Description = "An adventurous journey through nature.", Author = "Jon Krakauer", Price = 15.99, CategoryId = 1 },
	           new Book { Id = 2, Title = "Pride and Prejudice", Description = "A romantic novel of manners.", Author = "Jane Austen", Price = 12.99, CategoryId = 2 },
	           new Book { Id = 3, Title = "Dracula", Description = "A horror classic that defines vampires.", Author = "Bram Stoker", Price = 10.99, CategoryId = 3 },
	           new Book { Id = 4, Title = "Dune", Description = "A science fiction epic.", Author = "Frank Herbert", Price = 18.99, CategoryId = 4 }
                );


		}
    }
}