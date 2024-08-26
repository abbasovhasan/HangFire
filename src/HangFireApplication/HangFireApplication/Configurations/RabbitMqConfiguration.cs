﻿using HangFireApplication.MqServices;
using MassTransit;

namespace HangFireApplication.Configurations;

public static class RabbitMqConfiguration
{
    public static void ConfigureRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        var rabbitMqConfig = configuration
            .GetSection("RabbitMq")
            .Get<RabbitMqConfig>();

        services.AddSingleton(rabbitMqConfig);

        services.AddMassTransit(x =>
        {
            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rabbitMqConfig.Host, u =>
                {
                    u.Username(rabbitMqConfig.Username);
                    u.Password(rabbitMqConfig.Password);
                });

                cfg.ReceiveEndpoint("hellojob-queue", e =>
                {
                    //e.Consumer<JobSearchConsumer>(context);
                });

                cfg.ReceiveEndpoint("jobsearch-queue", e =>
                {
                    //e.Consumer<JobSearchConsumer>(context);
                });
                cfg.ReceiveEndpoint("boss-az-queue", e =>
                {
                    //e.Consumer<JobSearchConsumer>(context);
                });
            });
        });

        services.AddHostedService<RabbitMqHostedService>();
    }
}


public class RabbitMqConfig
{
    public string Host { get; set; }
    public int Port { get; set; } = 5672;  // varsayılan port
    public string Username { get; set; } // default username -> guest
    public string Password { get; set; } // default password -> guest
    public string VirtualHost { get; set; } // -> "/"
}