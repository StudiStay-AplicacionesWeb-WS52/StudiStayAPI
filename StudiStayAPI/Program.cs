using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using StudiStayAPI.Rooms.Controllers;
using StudiStayAPI.Rooms.Domain.Repositories;
using StudiStayAPI.Rooms.Domain.Services;
using StudiStayAPI.Rooms.Domain.Services.Communication;
using StudiStayAPI.Rooms.Services;
using StudiStayAPI.Security.Domain.Repositories;
using StudiStayAPI.Security.Domain.Services;
using StudiStayAPI.Security.Jwt;
using StudiStayAPI.Security.Persistence.Repositories;
using StudiStayAPI.Security.Services;
using StudiStayAPI.Shared.Exceptions;
using StudiStayAPI.Shared.Persistence.Contexts;
using StudiStayAPI.Shared.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add API Documentation Information
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "StudiStay API",
        Description = "StudiStay RESTful API",
        TermsOfService = new Uri("https://acme-learning.com/tos"),
        Contact = new OpenApiContact
        {
            Name = "StudiStay",
            Url = new Uri("https://acme.studio")
        },
        License = new OpenApiLicense
        {
            Name = "StudiStay Resources License",
            Url = new Uri("https://acme-learning.com/license")
        }
    });
    options.EnableAnnotations();
    options.AddSecurityDefinition("bearerAuth", new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme, Id = "bearerAuth"
                }
            },
            Array.Empty<string>()
        }
    });
});

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseNpgsql(connectionString)
        .LogTo(Console.WriteLine, LogLevel.Information)
        // .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// Shared Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Dependency Injection Configuration
builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUniversityRepository, UniversityRepository>();
builder.Services.AddScoped<IUniversityService, UniversityService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ICalificationService, CalificationService>();
builder.Services.AddScoped<ICalificationRepository, CalificationRepository>();
builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

// Security Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<JwtHandler>();

// Add lowercase routes
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// AutoMapper Configuration
builder.Services.AddAutoMapper(
    typeof(StudiStayAPI.Rooms.Mapping.ModelToDtoProfile), 
    typeof(StudiStayAPI.Rooms.Mapping.DtoToModelProfile),
    typeof(StudiStayAPI.Security.Mapping.ModelToDtoProfile),
    typeof(StudiStayAPI.Security.Mapping.DtoToModelProfile)
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

// JWT Configuration
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
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
    // app.UseSwaggerUI(options =>
    // {
    //     options.SwaggerEndpoint("v1/swagger.json", "v1");
    //     options.RoutePrefix = "swagger";
    // });
// }

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseCors("AllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthentication(); 
app.UseAuthorization();
app.MapControllers();
app.Run();