using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using nhmatsumoto.financial.api.Context;
using nhmatsumoto.financial.api.Context.Interfaces;
using nhmatsumoto.financial.api.Context.Repository;
using nhmatsumoto.financial.api.Context.Tables;
using nhmatsumoto.financial.api.Domain.Entities;
using nhmatsumoto.financial.api.Services;
using nhmatsumoto.financial.api.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

Boostrapper.RegisterServices(builder.Services, builder.Configuration);

var app = builder.Build();

//Middleware de tratamento de erros
app.UseStatusCodePages(async statusCodeContext =>
    await Results.Problem(statusCode: statusCodeContext.HttpContext.Response.StatusCode)
       .ExecuteAsync(statusCodeContext.HttpContext));

//Configura middleware HTTP
app.UseStatusCodePages(async statusCodeContxt =>
    await Results.Problem(statusCode: statusCodeContxt.HttpContext.Response.StatusCode)
    .ExecuteAsync(statusCodeContxt.HttpContext));

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/register", async (AccountTable account, IAccountService _accountService) =>
{
    await _accountService.AddAccount(account);
})
    .WithName("AddAccount")
    .RequireAuthorization()
    .WithOpenApi(x => new OpenApiOperation(x)
    {
        Summary = "Register a new account",
        Description = "Register a new account",
        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Financial" } }
    });

app.MapGet("/account", async (int accountId, IAccountService _accountService) =>
{
    var account = _accountService.GetAccount(accountId);

    if(account is not null)
    {
        return Results.Ok(account);
    }

    return Results.NotFound();
})
    .WithName("GetAccount")
    .RequireAuthorization()
    .WithOpenApi(x => new OpenApiOperation(x)
    {
        Summary = "Get account by id",
        Description = "Get account by id",
        Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Financial" } }
    });

app.MapGroup("/auth/").MapIdentityApi<AppUser>();

app.Run();
