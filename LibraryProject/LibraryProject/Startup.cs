using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using LibraryProject.Entities;
using AutoMapper;
using LibraryProject.Services;
using LibraryProject.Middleware;

namespace LibraryProject
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LibraryProject", Version = "v1" });
            });
            services.AddDbContext<LibraryDbContext>();
            services.AddScoped<LibrarySeeder>();
            services.AddAutoMapper(this.GetType().Assembly);
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IBorrowedBookService, BorrowedBookService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeMiddleware>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, LibrarySeeder seeder)
        {
            seeder.SeedBookStatus();
            seeder.SeedBooks();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryProject v1"));
            }

            app.UseMiddleware<ErrorHandlingMiddleware>();

            app.UseMiddleware<RequestTimeMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();
                       
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}