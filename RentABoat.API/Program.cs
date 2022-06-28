using Microsoft.EntityFrameworkCore;
using RentABoat.Core.Services;
using RentABoat.Infrastructure.Context;
using RentABoat.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainContext>(options =>
    options.UseSqlite("DataSource=dbo.RentABoat.db",
        sqlOptions => sqlOptions.MigrationsAssembly("RentABoat.Infrastructure")
    )
);

builder.Services.AddScoped<IBoatRepository, BoatRepository>();
builder.Services.AddScoped<IBoatService, BoatService>();
builder.Services.AddScoped<ISailorAccountRepository, SailorAccountRepository>();
builder.Services.AddScoped<ISailorAccountService, SailorAccountService>();

var app = builder.Build();

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