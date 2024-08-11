using desafioCheckList.DAO.Data;
using Microsoft.AspNetCore.Connections;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Add conection to DBs
string connDbDesafioCheckList = builder.Configuration.GetConnectionString("connDbDesafioCheckList")!;

builder.Services.AddScoped<IDbConnectionFactory>(sp =>
{
    var connectionFactory = new DbConnectionFactory(connDbDesafioCheckList);
    return connectionFactory;
});

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
