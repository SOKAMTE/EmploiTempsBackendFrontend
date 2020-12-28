
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;         
using emploiTemps.Data;
using Microsoft.EntityFrameworkCore;
using emploiTemps.Repository;

namespace emploiTemps 
{
    public class Startup
    {

        // Configuration de swagger pour la sécurité cors origin
        private readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connection = Configuration.GetConnectionString("DefaultConnection");

            services.AddMvc();

            // Configuration de swagger pour la sécurité cors origin
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                builder =>
                                {
                                    builder.WithOrigins("http://localhost:5000")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod();
                                });
            });

            services.AddControllers();

            services.AddRazorPages();

            services.AddDbContext<EmploiTempsContext>(options =>
                options.UseMySql(connection));

            //services.AddControllers();

            //Configure Swagger
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo {Title = "SwaggerDemo", Version = "v1"});
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "SwaggerDemo API",
                }); 
                var filePath = System.IO.Path.Combine(System.AppContext.BaseDirectory, "SwaggerDemo.xml");
 
                c.IncludeXmlComments(filePath);
            });

            //Configuration du namespace repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDepartementRepository, DepartementRepository>();
            services.AddScoped<IEnseignantRepository, EnseignantRepository>();
            services.AddScoped<ISalleRepository, SalleRepository>();
            services.AddScoped<IPeriodeRepository, PeriodeRepository>();
            services.AddScoped<IUniteRepository, UniteRepository>();
            services.AddScoped<ISemestreRepository, SemestreRepository>();
            services.AddScoped<IOptionRepository, OptionRepository>();
            services.AddScoped<INiveauRepository, NiveauRepository>();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerDemo v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "SwaggerDemo v2");
            });
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // Configuration de swagger pour la sécurité cors origin
            app.UseCors(MyAllowSpecificOrigins);
            //app.UseAuthorization();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            //app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");   
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
