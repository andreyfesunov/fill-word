using game_center_backend_cs;
using game_center_backend_cs.Application;
using game_center_backend_cs.Domain.Repositories;
using game_center_backend_cs.Domain.Services.FillWord;
using game_center_backend_cs.Domain.Services.User;
using game_center_backend_cs.Presentation.Middleware;
using game_center_backend_cs.Presentation.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IFillWordRepository, FillWordRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IUserFillWordRepository, UserFillWordRepository>();

builder.Services.AddSingleton<FillWordCreateService>();
builder.Services.AddSingleton<FillWordUpdateService>();
builder.Services.AddSingleton<FillWordGetService>();
builder.Services.AddSingleton<UserGetService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => options.OperationFilter<SwaggerAuthHeader>());

// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin", corsPolicyBuilder =>
    {
        corsPolicyBuilder.WithOrigins(Config.ClientUrl)
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

app.UseMiddleware<SimpleAuthenticationMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();