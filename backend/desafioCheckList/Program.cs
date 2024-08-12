using desafioCheckList.DAO;
using desafioCheckList.DAO.Data;
using desafioCheckList.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add conection to DBs
string connDbDesafioCheckList = builder.Configuration.GetConnectionString("connDbDesafioCheckList")!;

builder.Services.AddScoped<IDbConnectionFactory>(sp =>
{
    var connectionFactory = new DbConnectionFactory(connDbDesafioCheckList);
    return connectionFactory;
});

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICheckListService, CheckListService>();
builder.Services.AddScoped<ICheckListItemService, CheckListItemService>();
builder.Services.AddScoped<IInspectionListService, InspectionListService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IVehicle_InspectionListService, Vehicle_InspectionListService>();
builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();

// Add DAO to the container.
builder.Services.AddScoped<ICheckListDAO, CheckListDAO>();
builder.Services.AddScoped<ICheckListItemDAO, CheckListItemDAO>();
builder.Services.AddScoped<IInspectionListDAO, InspectionListDAO>();
builder.Services.AddScoped<IUserDAO, UserDAO>();
builder.Services.AddScoped<IVehicle_InspectionListDAO, Vehicle_InspectionListDAO>();
builder.Services.AddScoped<IVehicleTypeDAO, VehicleTypeDAO>();

// Configure CORS policy
var hostsAllowed = new string[] { };
string myPolicy = "MyPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(myPolicy,
    builder =>
    {
        builder.WithOrigins(hostsAllowed)
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(myPolicy);

app.UseAuthorization();

app.MapControllers();

app.Run();
