using burguermania_backend.Context;
using Microsoft.EntityFrameworkCore;
using DotNetEnv; // Para carregar o .env

var builder = WebApplication.CreateBuilder(args);

// Carregar variáveis de ambiente do arquivo .env (caso esteja usando DotNetEnv)
Env.Load();

// Obtém as variáveis de ambiente
string dbHost = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
string dbName = Environment.GetEnvironmentVariable("DB_NAME") ?? "burguermaniadb";
string dbUsername = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "postgres";
string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "123456";

// Monta a connection string
string postgreSQLConnectionString = $"Host={dbHost};Database={dbName};Username={dbUsername};Password={dbPassword}";

// Adiciona serviços ao contêiner
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BurguerManiaDbContext>(options => 
    options.UseNpgsql(postgreSQLConnectionString)
);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();

app.UseCors("AllowAngular");

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        c.RoutePrefix = "swagger";  
    });
}

if (!app.Environment.IsDevelopment()) 
{
    app.UseHttpsRedirection(); 
}

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.Run();
