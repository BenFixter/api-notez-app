using Microsoft.EntityFrameworkCore;
using api_notez_app.Models;

var Policy = "_Policy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Policy,
                      builder =>
                      {
                      builder
                        .WithOrigins("http://localhost:5173") // specifying the allowed origin
                        .WithMethods("GET", "POST", "PUT", "DELETE") // defining the allowed HTTP method
                        .AllowAnyHeader(); // allowing any header to be sent
                      });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<NoteContext>(opt =>
opt.UseSqlServer(builder.Configuration.GetConnectionString("NotesContext")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(Policy);

app.UseAuthorization();

app.MapControllers();

app.Run();
