using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Commands.Usuario.Commands;
using App.Domain.Commands.Usuario.Handlers;
using App.Domain.Core.Events;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Events.Usuario.Events;
using App.Domain.Events.Usuario.Handlers;
using App.Domain.Interfaces;
using App.Infra.CrossCutting.Bus;
using App.Infra.Data.Context;
using App.Infra.Data.EventSourcing;
using App.Infra.Data.Repository;
using App.Infra.Data.Repository.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace App.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //App Service
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Events

            //Dominio
            services.AddScoped<INotificationHandler<UsuarioCrearEvent>, UsuarioCrearEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioModificarEvent>, UsuarioModificarEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioEliminarEvent>, UsuarioEliminarEventHandler>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Commands

            //Dominio
            services.AddScoped<IRequestHandler<UsuarioCrearCommand, CommandResponse>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioModificarCommand, CommandResponse>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioEliminarCommand, CommandResponse>, UsuarioCommandHandler>();


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //InfraData
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<LisitContext>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Infra Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
