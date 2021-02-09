using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using apshop.Repositories.Interfaces;
using apshop.Data;
using Microsoft.EntityFrameworkCore;
using apshop.Repositories.Repositories;
using AutoMapper;
using apshop.Repositories.UnitOfWork;
using apshop.Mapper;
using apshop.BLL.Services;
using apshop.BLL;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;

namespace apshop
{
    public class Startup
    {

        private IConfigurationRoot _configurationRoot;
        public Startup(IHostEnvironment hostEnvironment)
        {
            _configurationRoot = new ConfigurationBuilder()
               .SetBasePath(hostEnvironment.ContentRootPath)
               .AddJsonFile("appsettings.json")
               .Build();
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
       
      
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

           
            services.AddSingleton<IHashingService, HashingService>();

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IOrderService, OrderService>();

          
            services.AddDbContext<ApShopContext>(options => options.UseSqlServer(_configurationRoot.GetConnectionString("DefaultConnection")));
        

            services.AddMemoryCache();
            services.AddRazorPages();
            services.AddControllers().AddNewtonsoftJson(); ;
            services.AddMvc();

            MapperConfiguration mapperConfig = new AutoMapper.MapperConfiguration(c => c.AddProfile(new MapperProfiles()));
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddSingleton(mapper);

            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllers();
            });
        }
    }
}
