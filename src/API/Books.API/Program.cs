using Books.API.Endpoints;
using Books.Application;
using Books.Application.Exceptions;
using Books.Infrastructure;
using Books.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var basePath = AppContext.BaseDirectory;
    var appXmlFile = Path.Combine(basePath, "Books.Application.xml");

    if (File.Exists(appXmlFile))
    {
        options.IncludeXmlComments(appXmlFile);
    }
    else
    {
        Console.WriteLine($"Warning: XML comments file not found: {appXmlFile}");
    }
});

builder.Services
    .AddApplicationServices()
    .AddInfrastructureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost5173", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapBookEndpoints();

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionMiddleware>();

app.UseCors("AllowLocalhost5173");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.EnsureCreated();
}

app.Run();