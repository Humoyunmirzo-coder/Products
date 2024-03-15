using Aplication.Service;
using Infrastructure.DataAccess;
using Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddConfigurationServices(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddDbContext<ProductDbContext>( options => 
options.UseNpgsql("Host= ::1; Port=5432 ;Database = Production; UserId = postgres; Password = 2244")) ;


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
