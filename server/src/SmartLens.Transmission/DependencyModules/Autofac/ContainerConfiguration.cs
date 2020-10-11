using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SmartLens.Business.Abstract;
using SmartLens.Business.Concrete;
using SmartLens.Business.Services;
using SmartLens.Client;
using SmartLens.DataAccess.Services.Api;
using SmartLens.Listener.Abstract;
using SmartLens.Listener.Concrate;
using SmartLens.Transmission.Abstract;
using SmartLens.Transmission.ClientEndPoint;
using SmartLens.Transmission.Concrate;
using SmartLens.Transmission.Tdo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartLens.Transmission.DependencyModules.Autofac
{
    static class ContainerConfiguration
    {
        public static IContainer Configure()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(l => l.AddConsole())
                .Configure<LoggerFilterOptions>(c => c.MinLevel = LogLevel.Trace);
            var containerBuilder = new ContainerBuilder();
            containerBuilder.Populate(serviceCollection);

            containerBuilder.RegisterType<ImageDetectedManager>().As<IImageDetectedManager>().SingleInstance();

            containerBuilder.RegisterType<Server>().As<IServer>().SingleInstance();
            containerBuilder.RegisterType<ResponseClient>().As<IResponseClient>().SingleInstance();
            containerBuilder.RegisterType<AsyncUdpListener>().As<IListener>().SingleInstance();
            containerBuilder.RegisterType<ImageDetectedManager>().As<IImageDetectedManager>().SingleInstance();
            containerBuilder.RegisterType<PythonImageDetectedService>().As<IImageDetectedService>().SingleInstance();
            containerBuilder.RegisterType<Udp>().As<IClient>().SingleInstance();
            containerBuilder.RegisterType<ClientEp>().As<IClientEp>().SingleInstance();
            containerBuilder.RegisterType<Settings>().As<ISettings>().SingleInstance();

            return containerBuilder.Build();
        }
    }
}
