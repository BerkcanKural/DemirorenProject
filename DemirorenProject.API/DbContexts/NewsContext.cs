using DemirorenProject.API.Entities;

using Microsoft.EntityFrameworkCore;

namespace DemirorenProject.API.DbContexts
{
    public class NewsContext : DbContext
    {
        public DbSet<NewsEN> News { get; set; } = null!;
        public DbSet<CategoriesEN> Categories { get; set; } = null!;
        public DbSet<UsersEN> Users { get; set; } = null!;
        public DbSet<NewsReadEN> NewsRead { get; set; }
        public DbSet<ImagesEN> NewsImages { get; set; }

        public NewsContext(DbContextOptions<NewsContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoriesEN>().HasData(
                new CategoriesEN()
                {
                    CategoryId = 1,
                    CategoryName = "sports",
                },
                new CategoriesEN()
                {
                    CategoryId = 2,
                    CategoryName = "science",
                },
                new CategoriesEN()
                {
                    CategoryId = 3,
                    CategoryName = "politics",
                }
                );
            modelBuilder.Entity<NewsEN>().HasData(
                new NewsEN()
                {
                    Id = 1,
                    Title = "Test",
                    Content = "This is the content for sports news",
                    Date = DateTime.Now,
                    NoOfViews = 0,
                    CategoryId = 1
                },

                new NewsEN()
                {
                    Id = 2,
                    Title = "Test2",
                    Content = "This is the content for science news",
                    Date = DateTime.Now,
                    NoOfViews = 0,
                    CategoryId = 2
                },
                new NewsEN()
                {
                    Id = 3,
                    Title = "Test3",
                    Content = "This is the content for politics news",
                    Date = DateTime.Now,
                    NoOfViews = 0,
                    CategoryId = 3
                },
                new NewsEN()
                {
                    Id = 4,
                    Title = "Test4",
                    Content = "This is the content for another politics news",
                    Date = DateTime.Now,
                    NoOfViews = 0,
                    CategoryId = 3
                }
                ); 
            modelBuilder.Entity<UsersEN>().HasData(
                new UsersEN()
                {
                    UserId = 1,
                    UserName = "UserNameTest1",
                    Password = "PasswordTest1",
                    FirstName = "FirstNameTest1",
                    LastName = "LastNameTest1",
                    Role = "admin"
                },
                new UsersEN()
                {
                    UserId = 2,
                    UserName = "UserNameTest2",
                    Password = "PasswordTest2",
                    FirstName = "FirstNameTest2",
                    LastName = "LastNameTest2",
                    Role = "user"
                }
                );
            modelBuilder.Entity<NewsReadEN>().HasData(
                new NewsReadEN()
                {
                    Id = 1,
                    NewsID = 1,
                    UserID = 2,
                },
                new NewsReadEN()
                {
                    Id = 2,
                    NewsID = 2,
                    UserID = 2,
                },
                new NewsReadEN()
                {
                    Id = 3,
                    NewsID = 2,
                    UserID = 1,
                }
                );
            modelBuilder.Entity<ImagesEN>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
