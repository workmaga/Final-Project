using BlazoreApp.Client.Pages;
using Microsoft.FluentUI.AspNetCore.Components;
using BlazoreApp.Components;
using BlazoreApp.Database;
using Microsoft.EntityFrameworkCore;
using BlazoreApp.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BlazoreApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddFluentUIComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("sqlite");
    options.UseSqlite(connectionString);
}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazoreApp.Client._Imports).Assembly);


//Users Table
app.MapGet("/api/users", async (AppDbContext dbContext) =>
{
    var users = await dbContext.Users.ToListAsync();

    List<UserViewModel> userViewModels = new();

    foreach(var user in users)
    {
        userViewModels.Add(new UserViewModel
        {

            UserId = user.UserId,
            UserName = user.UserName,
            MoneyAmount = user.MoneyAmount
        }
        );
    }

    return Results.Ok(userViewModels);
}
);

app.MapGet("/api/users/{id}", async (AppDbContext dbContext, int id) =>
{

    var user = await dbContext.Users.FindAsync(id);
    if (user == null)
    {
        return Results.NotFound();  
    }

    UserViewModel UserViewModel = new()
        {

            UserName = user.UserName,
            MoneyAmount = user.MoneyAmount,

        };

    return Results.Ok(UserViewModel);

}
);

app.MapPost("/api/users", async (AppDbContext dbContext, UserViewModel userViewModel) =>
{

    User user = new()
    {
        UserName = userViewModel.UserName,
        MoneyAmount = userViewModel.MoneyAmount,

    };

    await dbContext.Users.AddAsync(user);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/users/{user.UserId}", user);
}
);


app.MapPut("/api/users/{id}", async (AppDbContext dbContext, int id, UserViewModel userViewModel) =>
{
    var user = await dbContext.Users.FindAsync(id);
    if (user == null)
    {
        return Results.NotFound();
    }

    user.UserName = userViewModel.UserName;
    user.MoneyAmount = userViewModel.MoneyAmount;

    await dbContext.SaveChangesAsync();
    return Results.Ok(user);
}
);

app.MapDelete("/api/users/{id}", async (AppDbContext dbContext, int id) =>
{
    var user = await dbContext.Users.FindAsync(id);
    if (user == null)
    {
        return Results.NotFound();
    }

    dbContext.Users.Remove(user);
    await dbContext.SaveChangesAsync();
    return Results.Ok(user);
}
);
//
//
//
//
//
//
//Books Table
app.MapGet("/api/books", async (AppDbContext dbContext) =>
{
    var books = await dbContext.Books.ToListAsync();

    List<BookViewModel> bookViewModels = new();

    foreach(var book in books)
    {
        bookViewModels.Add(new BookViewModel
        {

            BookId = book.BookId,
            Title = book.Title,
            ISBN = book.ISBN,
            BookAmount = book.BookAmount,
            UserId = book.UserId,
            GenreId = book.GenreId,
        }
        );
    }

    return Results.Ok(bookViewModels);
}
);


app.MapGet("/api/books/{id}", async (AppDbContext dbContext, int id) =>
{

    var book = await dbContext.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();  
    }

    BookViewModel bookViewModel = new()
        {

            BookId = book.BookId,
            Title = book.Title,
            ISBN = book.ISBN,
            BookAmount = book.BookAmount,
            UserId = book.UserId,
            GenreId = book.GenreId,

        };

    return Results.Ok(bookViewModel);

}
);


app.MapPost("/api/books", async (AppDbContext dbContext, BookViewModel bookViewModel) =>
{

    Book book = new()
    {
            BookId = bookViewModel.BookId,
            Title = bookViewModel.Title,
            ISBN = bookViewModel.ISBN,
            BookAmount = bookViewModel.BookAmount,
            UserId = bookViewModel.UserId,
            GenreId = bookViewModel.GenreId,

    };

    await dbContext.Books.AddAsync(book);
    await dbContext.SaveChangesAsync();
    return Results.Created($"/api/books/{book.BookId}", book);
}
);


app.MapPut("/api/book/{id}", async (AppDbContext dbContext, int id, BookViewModel bookViewModel) =>
{
    var book = await dbContext.Books.FindAsync(id);
    if (book == null)
    {
        return Results.NotFound();
    }

            book.BookId = bookViewModel.BookId;
            book.Title = bookViewModel.Title;
            book.ISBN = bookViewModel.ISBN;
            book.BookAmount = bookViewModel.BookAmount;
            book.UserId = bookViewModel.UserId;
            book.GenreId = bookViewModel.GenreId;

    await dbContext.SaveChangesAsync();
    return Results.Ok(book);
}
);

app.Run();
