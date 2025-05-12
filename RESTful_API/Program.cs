using Common.Configurations;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Repository.Product;
using Domain.Services.Product;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region App Configurations
builder.Services.Configure<RestfulApiOptions>(
    builder.Configuration.GetSection("RestfulApi")
);
#endregion

#region Services & Repositories
builder.Services.AddHttpClient<ProductRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();
#endregion

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
