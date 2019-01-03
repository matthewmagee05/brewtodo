using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Orders.Schema;
using Orders.Schema.InputTypes;
using Orders.Schema.Mutations;
using Orders.Services;
using Orders.Services.Interfaces;

namespace Server
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IBreweryService, BreweryService>();
            services.AddSingleton<IBeerTypeService, BeerTypeService>();
            services.AddSingleton<IBeerService, BeerService>();
            services.AddSingleton<IReviewService, ReviewService>();
            services.AddSingleton<IUserBeerTriedService, UserBeerTriedService>();
            services.AddSingleton<IUserPurchasedItemService, UserPurchasedItemService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<BeerTypeType>();
            services.AddSingleton<BreweryType>();
            services.AddSingleton<BeerType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<UserBeerTriedType>();
            services.AddSingleton<UserPurchasedItemType>();
            services.AddSingleton<ReviewType>();
            services.AddSingleton<BreweryQuery>();
            services.AddSingleton<BrewerySchema>();
            services.AddSingleton<BreweryCreateInputType>();
            services.AddSingleton<BeerInputType>();
            services.AddSingleton<BeerTypeInputType>();
            services.AddSingleton<ReviewInputType>();
            services.AddSingleton<UserBeerTriedInputType>();
            services.AddSingleton<UserInputType>();
            services.AddSingleton<UserPurchasedItemInputType>();
            services.AddSingleton<BreweryMutation>();
            services.AddSingleton<IDependencyResolver>(
                c => new FuncDependencyResolver(type => c.GetRequiredService(type))
            );
             services.AddGraphQL(options =>
            {
                options.EnableMetrics = true;
            })
            .AddWebSockets()
            .AddDataLoader();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseWebSockets();
            app.UseGraphQLWebSockets<BrewerySchema>();
            app.UseGraphQL<BrewerySchema>("/graphql");
        }
    }
}
