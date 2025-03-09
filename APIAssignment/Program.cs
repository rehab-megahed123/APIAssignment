
using System.Text;
using API.BLL.Manager.Abstraction;
using API.BLL.Manager.Implementation;
using API.BLL.Repository.Abstraction;
using API.DAL.Models;
using API.DAL.Repository.Abstraction;
using API.DAL.Repository.Implementation;
using APIAssignment.MiddleWares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace APIAssignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IProductManager, ProductManager>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<ICustomerManager, CustomerManager>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
            });
            builder.Services.AddAuthentication(options =>
            {
                // Use JWT
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;  // require https
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    // (exp)  ==> expiration
                    ValidateLifetime = true,

                    ValidateIssuer = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],

                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]))
                };
            });
            var myPolicy = "myPolicy";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: myPolicy, policy =>
                {
                    policy
                        .AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();

                    policy
                        .WithOrigins("http://127.0.0.1:5500/")
                        .WithMethods("Get", "Post")
                        .WithHeaders("token");
                });
            });

            var app = builder.Build();
            app.UseMiddleware<GlobalExceptionHandling>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("myPolicy");
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
