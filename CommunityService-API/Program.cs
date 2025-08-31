using CommunityService_API;
<<<<<<< HEAD
using CommunityService_API.Services; 
=======
using CommunityService_API.Services; // thêm namespace chứa PostService
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

<<<<<<< HEAD
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CommunityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


=======
// Add services to the container.
builder.Services.AddControllers();

// Đăng ký Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký DbContext
builder.Services.AddDbContext<CommunityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Đăng ký PostService
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598
builder.Services.AddScoped<PostService>();

var app = builder.Build();

<<<<<<< HEAD

app.UseSwagger();
app.UseSwaggerUI();
=======
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
>>>>>>> 8c48d16e9746ad0292d5a3b553f68c5e827c2598

app.UseAuthorization();

app.MapControllers();

app.Run();
