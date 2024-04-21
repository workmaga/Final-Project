using Microsoft.EntityFrameworkCore;
using BlazoreApp.Entities;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.Eventing.Reader;
using Assignment6.Entities;

namespace BlazoreApp.Database;





public class AppDbContext:DbContext
{   
    public DbSet<User> Users { get; set; }

    public DbSet<Book> Books { get; set; }

    public DbSet<Genre> Genres { get; set; }

    public string DbPath { get; set; }


    public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       modelBuilder.Entity<User>().HasData(
            new User{UserId=1, UserName="George R.R. Martin"},
            new User{UserId=2, UserName="J.K. Rowling"},
            new User{UserId=3, UserName="Neal Stephenson"},
            new User{UserId=4, UserName="Steven King"},
            new User{UserId=5, UserName="Roald Dahl"}
        );

        modelBuilder.Entity<Book>().HasData(

            new Book {BookId = 1, ISBN = 9780006479888, Title = "A Song of Ice and Fire", GenreId = 2, UserId = 1 },
            new Book{BookId=2, ISBN=9780590353403, Title="Harry Potter and the Sorcerer's Stone", GenreId=1, UserId=2},
            new Book{BookId=3, ISBN=9780060512804, Title="Cryptonomicon", GenreId=3, UserId=3},
            new Book{BookId=4, ISBN=9781501156700, Title="Pet Sematary", GenreId=4, UserId=4},
            new Book{BookId=5, ISBN=9780142410318, Title="Charlie and the Chocolate Factory", GenreId=5, UserId=5}

        );

         modelBuilder.Entity<Genre>().HasData(
            new Genre {GenreId=1, GenreIs="Sci-Fi"},
            new Genre {GenreId=2, GenreIs="Cartoon"},
            new Genre {GenreId=3, GenreIs="Historical Fiction"},
            new Genre {GenreId=4, GenreIs="Creepy"},
            new Genre {GenreId=5, GenreIs="Childrens"}
        );

    }




}