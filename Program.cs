using CreditCardManager.Data;
using CreditCardManager.Middlewares;
using CreditCardManager.Repositories.Movements;
using CreditCardManager.Repositories.Payers;
using CreditCardManager.Services.Movements;
using CreditCardManager.Services.Payers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IMovementRepository, MovementRepository>();
builder.Services.AddScoped<IMovementService, MovementService>();
builder.Services.AddScoped<IPayerRepository, PayerRepository>();
builder.Services.AddScoped<IPayerService, PayerService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
