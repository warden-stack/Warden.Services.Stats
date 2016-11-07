﻿using Autofac;
using Microsoft.Extensions.Configuration;
using RawRabbit;
using RawRabbit.vNext;
using RawRabbit.Configuration;
using Warden.Common.Events;
using Warden.Common.Events.Wardens;
using Warden.Common.Nancy;
using Warden.Common.Extensions;
using Warden.Services.Stats.Handlers.Events;

namespace Warden.Services.Stats.Framework
{
    public class Bootstrapper : AutofacNancyBootstrapper
    {
        private readonly IConfiguration _configuration;
        public static ILifetimeScope LifetimeScope { get; private set; }

        public Bootstrapper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void ConfigureApplicationContainer(ILifetimeScope container)
        {
            base.ConfigureApplicationContainer(container);
            container.Update(builder =>
            {
                var rawRabbitConfiguration = _configuration.GetSettings<RawRabbitConfiguration>();
                builder.RegisterInstance(rawRabbitConfiguration).SingleInstance();
                builder.RegisterInstance(BusClientFactory.CreateDefault(rawRabbitConfiguration))
                    .As<IBusClient>();
                builder.RegisterType<WardenCheckResultProcessedHandler>().As<IEventHandler<WardenCheckResultProcessed>>();
            });
            LifetimeScope = container;
        }
    }
}