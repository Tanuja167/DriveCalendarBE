using DriveCalendarBE.Repository;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null;
});
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings:DefaultConnections").Value));
builder.Services.AddCors(options => options.AddDefaultPolicy(
                builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
            ));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DriveCalendarBE", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description="Jwt Authentication",
        Name="Authorization",
        In=ParameterLocation.Header,
        Type=SecuritySchemeType.ApiKey,
        Scheme="Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference=new OpenApiReference
            {
                Type=ReferenceType.SecurityScheme,
                Id="Bearer"
            }
        },
        new string[]{ }
    }
    });
});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
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

builder.Services.AddScoped<IDriveRepository, DriveRepository>();
builder.Services.AddScoped<IDriveService, DriveService>();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
builder.Services.AddScoped<IDriveStatusRepository, DriveStatusRepository>();
builder.Services.AddScoped<IDriveStatusService, DriveStatusService>();
builder.Services.AddScoped<IStudentDriveStatusRepository, StudentDriveStatusRepository>();
builder.Services.AddScoped<IStudentDriveStatusService, StudentDriveStatusService>();
builder.Services.AddScoped<IStudentDriveRepository, StudentDriveRepository>();
builder.Services.AddScoped<IStudentDriveService, StudentDriveService>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IBatchRepository, BatchRepository>();
builder.Services.AddScoped<IBatchService, BatchService>();
builder.Services.AddScoped<ICommonRepository, CommonRepository>();
builder.Services.AddScoped<ICommonService, CommonService>();
builder.Services.AddScoped<IUpdateStudentProfileRepository, UpdateStudentProfileRepository>();
builder.Services.AddScoped<IUpdateStudentProfileService, UpdateStudentProfileService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DriveCalendarBE v1"));

app.Run();
