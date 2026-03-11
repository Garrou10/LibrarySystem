using LibrarySystem.Data;
using LibrarySystem.Core;
using Microsoft.EntityFrameworkCore;

using LibrarySystem.Web.Components;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<LibraryContext>();


builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IMemberRepository, MemberRepository>(); 

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

    using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<LibraryContext>();
    db.Database.Migrate();
}

app.Run();
