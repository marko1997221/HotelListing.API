using HotelListing.Configuration;
using HotelListing.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using HotelListing.Contracts;
using HotelListing.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var cnnString = builder.Configuration.GetConnectionString("HotelListingDbCnnString");
builder.Services.AddDbContext<HotelListingDbContext>(options =>
{
    options.UseSqlServer(cnnString);
});
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b =>
    {
        b.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    });
});
builder.Host.UseSerilog((ctx, lc) =>
{
    lc.WriteTo.Console().ReadFrom.Configuration(ctx.Configuration);
});
// ovo je bitno kada hocemo da povezujemo interfejs sa klasom na kojoj se izvrsava interfejs
builder.Services.AddScoped(typeof(IGenericContract<>), typeof(GenericRepositary<>));
builder.Services.AddScoped<ICountryInterface,CountryRepository>();
builder.Services.AddAutoMapper(typeof(MapperConfing));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
