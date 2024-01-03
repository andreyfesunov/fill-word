using game_center_backend_cs.Application;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Domain.Services.FillWord;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IFillWordRepository, FillWordRepository>();
builder.Services.AddSingleton<FillWordCreateService>();
builder.Services.AddSingleton<FillWordUpdateService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins("http://localhost:8080") // Укажите адрес вашего клиентского приложения
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Database configuration
var app = builder.Build();

// В методе Configure() добавьте вызов CORS:
app.UseCors("AllowOrigin");

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