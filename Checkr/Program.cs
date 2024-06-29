using Checkr.Data;
using Checkr.Entities;
using Checkr.Middleware;
using Checkr.Policies;
using Checkr.Repositories.Abstract;
using Checkr.Repositories.Concrete;
using Checkr.Services.Abstract;
using Checkr.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
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
services.AddScoped<IInvitationRepository, InvitationRepository>();

services.AddScoped<IBoardService, BoardService>();
services.AddScoped<IBoxService, BoxService>();
services.AddScoped<ICardService, CardService>();
services.AddScoped<ITagService, TagService>();
services.AddScoped<IMessageService, MessageService>();
services.AddScoped<IToDoItemService, ToDoItemService>();
services.AddScoped<IInvitationService, InvitationService>();

services.AddScoped<IUserService, UserService>();
services.AddScoped<IFileService, FileService>();

services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("ApplicationDbContext")
        ?? throw new InvalidOperationException("Connection string 'ApplicationDbContext' not found.");
    options.UseSqlServer(connectionString);
});

services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

services.AddControllersWithViews();

services.AddAuthorizationBuilder()
    .AddPolicy("IsOwnerPolicy", policy =>
    {
        policy.Requirements.Add(new BoardOwnerRequirement());
    })
    .AddPolicy("IsUserPolicy", policy =>
    {
        policy.Requirements.Add(new BoardUserRequirement());
    });

services.AddScoped<IAuthorizationHandler, BoardOwnerHandler>();
services.AddScoped<IAuthorizationHandler, BoardUserHandler>();

services.AddHttpContextAccessor();

services.AddRouting(options => options.LowercaseUrls = true);

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

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
