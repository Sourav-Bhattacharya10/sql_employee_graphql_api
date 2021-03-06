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
using sql_employee_graphql_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using sql_employee_graphql_api.Repositories;
using Microsoft.Extensions.Options;
// using HotChocolate.AspNetCore;

namespace sql_employee_graphql_api
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
            services.Configure<StoredProcedureConfigurations>(options => Configuration.GetSection(nameof(StoredProcedureConfigurations)).Bind(options));

            // requires using Microsoft.Extensions.Options
            services.AddSingleton<IStoredProcedureConfigurations>(sp => {
                return sp.GetRequiredService<IOptions<StoredProcedureConfigurations>>().Value;
            });

            services.AddControllers();

            services.AddDbContext<WorkDBContext>(opt => {
                    var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));
                    builder.Password = Configuration["DbPassword"]; // dotnet user-secrets set "DbPassword" "***value***"
                    opt.UseSqlServer(builder.ConnectionString);
                });

            services.AddScoped<IRepository<Employee>, Repository<Employee>>();

            // services.AddScoped<IQuery<Employee>, Query<Employee>>();

            services.AddGraphQLServer().AddQueryType<Query<Employee>>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                // By default the GraphQL server is mapped to /graphql
                // This route also provides you with our GraphQL IDE. In order to configure the
                // the GraphQL IDE use endpoints.MapGraphQL().WithToolOptions(...).
                endpoints.MapGraphQL();
            });
        }
    }
}
