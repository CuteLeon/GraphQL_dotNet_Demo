using GraphiQl;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.GraphQLAction;
using GraphQLWebAPIwithEFCore.GraphQLTypes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace GraphQLWebAPIwithEFCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseInMemoryDatabase("DefaultMemoryDB")
                    .UseLazyLoadingProxies();
            }, ServiceLifetime.Singleton);

            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<PropertyQuery>();
            services.AddSingleton<PropertyMutation>();
            services.AddSingleton<PropertyType>();
            services.AddSingleton<PropertyInputType>();
            services.AddSingleton<PaymentType>();
            services.AddSingleton<ISchema, APISchema>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DatabaseContext dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            // 使用此框架以在线调试
            app.UseGraphiQl("/GraphQLDemo", "/GraphQL/Query");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            dbContext.Initial();
        }
    }
}
