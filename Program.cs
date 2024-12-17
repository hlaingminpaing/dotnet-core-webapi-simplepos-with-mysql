// using Microsoft.EntityFrameworkCore;
// using PosWebApi.Data;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();
// builder.Services.AddDbContext<AppDbContext>(options =>
//     options.UseMySql(
//         builder.Configuration.GetConnectionString("DefaultConnection"),
//         new MySqlServerVersion(new Version(8, 0, 39)) // Replace with your MySQL version
        
//         ));
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// ///listen port 80
// builder.WebHost.UseKestrel(options =>
// {
//     options.ListenAnyIP(80);
// });


// var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }


// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();
// app.Run();

using Microsoft.EntityFrameworkCore;
using PosWebApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Configure CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());
});

// Configure the DbContext to use MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 39)) // Replace with your MySQL version
    )
);

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Use the CORS policy
app.UseCors("AllowAll");

// Ensure HTTPS redirection
app.UseHttpsRedirection();

// Add Authorization middleware
app.UseAuthorization();

// Map controllers to endpoints
app.MapControllers();

// Listen on port 80 (set before building the app)
app.Run("http://0.0.0.0:80");
