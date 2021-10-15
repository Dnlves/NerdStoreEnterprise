using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Extensions;
using NSE.WebApp.MVC.Services;
using NSE.WebApp.MVC.Services.Handlers;
using Polly;
using Polly.Extensions.Http;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependecyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<HttpClientAuthorizationDelegatingHandler>();

            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
            
            var retryWaitPolicy = HttpPolicyExtensions
                                    .HandleTransientHttpError()
                                    .WaitAndRetryAsync(
                                        sleepDurations: new [] { 
                                            TimeSpan.FromSeconds(1),
                                            TimeSpan.FromSeconds(5),
                                            TimeSpan.FromSeconds(10),
                                        },
                                        onRetry: (outcome, TimeSpan, retryCount, context) => 
                                        {
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.WriteLine($"Tentando pela {retryCount} vez!");
                                            Console.ForegroundColor = ConsoleColor.White;
                                        }
                                    );
            
            services
                .AddHttpClient<ICatalogoService, CatalogoService>()
                .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
                // .AddTransientHttpErrorPolicy(p => p.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(600)));
                .AddPolicyHandler(retryWaitPolicy);

            // services
            //     .AddHttpClient(name: "Refit", configureClient: options => 
            //     {
            //         options.BaseAddress = new Uri(configuration.GetSection(key: "CatalogoUrl").Value);
            //     })
            //     .AddHttpMessageHandler<HttpClientAuthorizationDelegatingHandler>()
            //     .AddTypedClient(Refit.RestService.For<ICatalogoServiceRefit>);

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<IUser, AspNetUser>();
        }
    }
}