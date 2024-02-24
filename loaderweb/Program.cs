using System.Text;
using loaderweb.Data;
using loaderweb.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Configuration.AddJsonFile("appsettings.json", optional: true, reloadOnChange: false);
builder.Configuration.AddJsonFile("appsettinngs.Development.json", optional: true, reloadOnChange: false);
builder.Configuration.AddJsonFile("appsettings.k8s.json", optional: true, reloadOnChange: false);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddSingleton<IUserService, UserService>();

builder.Services.AddControllers();
var appSettingsSection = builder.Configuration.GetSection("AppSettings").GetChildren();
var value = appSettingsSection.Select(b => b.Value);
//// configure jwt authentication
//var appSettings = appSettingsSection.GetValue<AppSettings>("Secret");
var key = Encoding.ASCII.GetBytes(value.FirstOrDefault());
builder.Services.AddAuthentication(x =>
                                    {
                                        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                    })
    .AddJwtBearer(v =>
    {
        v.RequireHttpsMetadata = false;
        v.SaveToken = true;
        v.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateAudience = false,
            ValidateIssuer = false,
        };

    }
   ); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
