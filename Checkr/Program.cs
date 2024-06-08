using Checkr.Entities;
using Checkr.Repositories.Abstract;
using Checkr.Repositories.Concrete;
using Checkr.Services.Abstract;
using Checkr.Services.Concrete;
using Checkr.Services.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;

services.AddScoped<IBoardRepository, BoardRepository>();
services.AddScoped<IBoxRepository, BoxRepository>();
services.AddScoped<ICardRepository, CardRepository>();
services.AddScoped<ITagRepository, TagRepository>();
services.AddScoped<IMessageRepository, MessageRepository>();
services.AddScoped<IToDoItemRepository, ToDoItemRepository>();

services.AddScoped<IBoardService, BoardService>();
services.AddScoped<IBoxService, BoxService>();
services.AddScoped<ICardService, CardService>();
services.AddScoped<IToDoItemService, ToDoItemService>();

services.AddScoped<IFileService, FileService>();

services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext") ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");
    options.UseSqlServer(connectionString);
});

services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
