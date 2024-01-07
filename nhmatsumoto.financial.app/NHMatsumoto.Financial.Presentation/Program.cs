using Microsoft.EntityFrameworkCore;
using nhmatsumoto.financial.infrastructure.CrossCutting.IoC;
using NHMatsumoto.Financial.Infrastructure.CrossCutting.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

BootStrapper.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

//Middleware de tratamento de exce��es
app.UseMiddleware<GlobalExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
