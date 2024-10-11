using BlazorApp.Components;
using Core.Abstractions;
using Core.EmptyObject;
using HumanResources;
using HumanResources.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IUserContext, TestUserContext>();

// TODO: smazat az budu mit nejake service
builder.Services.AddEmptyObject();

builder.Services
    .AddHumanResources()
    .AddHumanResourcesEntityFramework(builder.Configuration);

var app = builder.Build();

app.MigrateHumanResourcesDatabase();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
