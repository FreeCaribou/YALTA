using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Yalta.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Yalta.Utils;
using Yalta.Services;

namespace Yalta
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
      string mySqlConnectionStr = "server=" + System.Environment.GetEnvironmentVariable("DB_Host")
      + ";port=" + System.Environment.GetEnvironmentVariable("DB_Port")
      + ";database=" + System.Environment.GetEnvironmentVariable("DB_Name")
      + ";user=" + System.Environment.GetEnvironmentVariable("DB_User")
      + ";password=" + System.Environment.GetEnvironmentVariable("DB_Password");
      services.AddDbContextPool<YaltaContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));
      // services.AddDbContext<YaltaContext>(opt => opt.UseInMemoryDatabase("YaltaDB"));

      services.AddControllers().AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
      );

      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddControllers();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Yalta", Version = "v1" });
      });

      // The service
      services.AddScoped<IUserService, UserService>();
      services.AddScoped<IProfilService, ProfilService>();
      services.AddScoped<IPreferredPeriodService, PreferredPeriodService>();
      services.AddScoped<IAreaService, AreaService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, YaltaContext context)
    {
      Console.WriteLine(System.Environment.GetEnvironmentVariable("Test"));

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Yalta v1"));
      }

      // TODO see condition for futur in prod
      using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
      {
        var contextTmp = serviceScope.ServiceProvider.GetRequiredService<YaltaContext>();
        contextTmp.Database.EnsureCreated();
      }

      context.EnsureSeedDataForContext();

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
