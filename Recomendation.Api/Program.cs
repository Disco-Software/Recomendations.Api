using Recomendation.Domain.Configurations;
using Recomendation.Domain.Extentions;
using Recomendation.EventListener.Extentions;
using Recomendation.EventListener.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<RecommendationDatabaseSettings>(builder.Configuration.GetSection("RecommendationDatabase"));
builder.Services.AddRepositories();
builder.Services.AddEventListener();

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

var listener = app.Services.GetRequiredService<IEventListener>();

listener.RunAsync();

app.Run();
