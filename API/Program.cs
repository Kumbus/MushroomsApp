
using Application.Helpers;
using Application.Helpers.Interfaces;
using Application.Mappings;
using Application.Services;
using Application.ServicesInterfaces;
using Domain.Entities;
using Domain.Helpers.Interfaces;
using Domain.RepositoriesInterfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MushroomsDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 0;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<MushroomsDbContext>().AddDefaultTokenProviders();

            builder.Services.AddAuthentication("Bearer").AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                        return Task.CompletedTask;
                    },
                    OnTokenValidated = context =>
                    {
                        Console.WriteLine("Token validated successfully");
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<ILocationRepository, LocationRepository>();
            builder.Services.AddScoped<IMushroomingRepository, MushroomingRepository>();
            builder.Services.AddScoped<IMushroomRepository, MushroomRepository>();
            builder.Services.AddScoped<ISpeciesRepository, SpeciesRepository>();
            builder.Services.AddScoped<IMushroomingMushroomRepository, MushroomingMushroomRepository>();
            builder.Services.AddScoped<IMushroomingMushroomPhotoRepository, MushroomingMushroomPhotoRepository>();
            builder.Services.AddScoped<IUserReviewRepository, UserReviewRepository>();

            builder.Services.AddScoped(typeof(IBaseService<,,,>), typeof(BaseService<,,,>));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IMushroomingService, MushroomingService>();
            builder.Services.AddScoped<IMushroomService, MushroomService>();
            builder.Services.AddScoped<ISpeciesService, SpeciesService>();
            builder.Services.AddScoped<ILocationService, LocationService>();
            builder.Services.AddScoped<IMushroomingMushroomService, MushroomingMushroomService>();
            builder.Services.AddScoped<IMushroomingMushroomPhotoService, MushroomingMushroomPhotoService>();
            builder.Services.AddScoped<IUserReviewService, UserReviewService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            builder.Services.AddScoped<IGoogleTokenValidator, GoogleTokenValidator>();
            builder.Services.AddHttpClient<IGoogleTokenValidator, GoogleTokenValidator>();
            builder.Services.AddScoped<IFacebookTokenValidator, FacebookTokenValidator>();
            builder.Services.AddHttpClient<IFacebookTokenValidator, FacebookTokenValidator>();

            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });


            builder.Services.AddControllers();
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

            app.UseAuthentication();
            app.UseAuthorization();



            app.MapControllers();

            app.Run();
        }
    }
}
