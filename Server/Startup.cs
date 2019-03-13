using GraphQL;
using GraphiQl;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersLib.Schema;
using OrdersLib.Schema.Types;
using OrdersLib.Services;
using GraphQL.Server;

namespace Server
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
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<IOrderService, OrderService>();

            services.AddTransient<CustomerType>();
            services.AddTransient<OrderType>();
            services.AddTransient<OrderCreateInputType>();

            services.AddSingleton<OrderQuery>();
            services.AddSingleton<OrderMutation>();
            services.AddSingleton<OrderSchema>();

            services.AddSingleton<IDependencyResolver>(c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            }).AddWebSockets().AddDataLoader();

            //services.AddGraphQLHttp();
            //services.AddGraphQLWebSocket<OrderSchema>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseWebSockets();
            app.UseWebSockets();
            app.UseGraphiQl();
            app.UseGraphiQLServer();
            app.UseGraphQLWebSockets<OrderSchema>("/graphql");
            app.UseGraphQL<OrderSchema>("/graphql");

            app.UseMvc();
        }
    }
}