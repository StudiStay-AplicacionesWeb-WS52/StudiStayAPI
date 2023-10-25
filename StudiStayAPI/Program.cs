using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Mapping;
using StudiStayAPI.Rooms.Services;
using StudiStayAPI.Shared.Persistence.Contexts;
using StudiStayAPI.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        // .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// Dependency Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(ModelToDtoProfile), 
    typeof(DtoToModelProfile)
);

// CORS Configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", policy =>
    {
        policy
            .WithOrigins("http://localhost:5173", "http://localhost:5174", "https://studistay-app.vercel.app")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Validation for ensuring Database Objects are created
using (var scope = app.Services.CreateScope())
using (var context = scope.ServiceProvider.GetService<AppDbContext>())
{
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();