using App.Application.Interfaces;
using App.Application.Services;
using App.Domain.Commands.Asignaciones.Commands;
using App.Domain.Commands.Asignaciones.Handlers;
using App.Domain.Commands.AyudasSociales.Commands;
using App.Domain.Commands.AyudasSociales.Handlers;
using App.Domain.Commands.Comuna.Commands;
using App.Domain.Commands.Comuna.Handlers;
using App.Domain.Commands.Pais.Commands;
using App.Domain.Commands.Pais.Handlers;
using App.Domain.Commands.Region.Commands;
using App.Domain.Commands.Region.Handlers;
using App.Domain.Commands.Usuario.Commands;
using App.Domain.Commands.Usuario.Handlers;
using App.Domain.Core.Events;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Events.Asignaciones.Events;
using App.Domain.Events.Asignaciones.Handlers;
using App.Domain.Events.AyudasSociales.Events;
using App.Domain.Events.AyudasSociales.Handlers;
using App.Domain.Events.Comuna.Events;
using App.Domain.Events.Comuna.Handlers;
using App.Domain.Events.Pais.Events;
using App.Domain.Events.Pais.Handlers;
using App.Domain.Events.Region.Events;
using App.Domain.Events.Region.Handlers;
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
            services.AddScoped<IPaisAppService, PaisAppService>();
            services.AddScoped<IRegionAppService, RegionAppService>();
            services.AddScoped<IComunaAppService, ComunaAppService>();
            services.AddScoped<IAyudasSocialesAppService, AyudasSocialesAppService>();
            services.AddScoped<IAsignacionesAppService, AsignacionesAppService>();
            services.AddScoped<IServiciosDeDominioAppService, ServiciosDeDominioAppService>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Events

            //Dominio
            services.AddScoped<INotificationHandler<UsuarioCrearEvent>, UsuarioCrearEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioModificarEvent>, UsuarioModificarEventHandler>();
            services.AddScoped<INotificationHandler<UsuarioEliminarEvent>, UsuarioEliminarEventHandler>();

            services.AddScoped<INotificationHandler<PaisCrearEvent>, PaisCrearEventHandler>();
            //services.AddScoped<INotificationHandler<PaisModificarEvent>, PaisModificarEventHandler>();
            //services.AddScoped<INotificationHandler<PaisEliminarEvent>, PaisEliminarEventHandler>();

            services.AddScoped<INotificationHandler<RegionCrearEvent>, RegionCrearEventHandler>();
            //services.AddScoped<INotificationHandler<RegionModificarEvent>, RegionModificarEventHandler>();
            //services.AddScoped<INotificationHandler<RegionEliminarEvent>, RegionEliminarEventHandler>();

            services.AddScoped<INotificationHandler<ComunaCrearEvent>, ComunaCrearEventHandler>();
            //services.AddScoped<INotificationHandler<ComunaModificarEvent>, ComunaModificarEventHandler>();
            //services.AddScoped<INotificationHandler<ComunaEliminarEvent>, ComunaEliminarEventHandler>();

            services.AddScoped<INotificationHandler<AyudasSocialesCrearEvent>, AyudasSocialesCrearEventHandler>();

            services.AddScoped<INotificationHandler<AsignacionesCrearEvent>, AsignacionesCrearEventHandler>();



            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Domain Commands

            //Dominio
            services.AddScoped<IRequestHandler<UsuarioCrearCommand, CommandResponse>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioModificarCommand, CommandResponse>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioEliminarCommand, CommandResponse>, UsuarioCommandHandler>();

            services.AddScoped<IRequestHandler<PaisCrearCommand, CommandResponse>, PaisCommandHandler>();
            services.AddScoped<IRequestHandler<PaisModificarCommand, CommandResponse>, PaisCommandHandler>();
            services.AddScoped<IRequestHandler<PaisEliminarCommand, CommandResponse>, PaisCommandHandler>();

            services.AddScoped<IRequestHandler<RegionCrearCommand, CommandResponse>, RegionCommandHandler>();
            //services.AddScoped<IRequestHandler<RegionModificarCommand, CommandResponse>, RegionCommandHandler>();
            //services.AddScoped<IRequestHandler<RegionEliminarCommand, CommandResponse>, RegionCommandHandler>();

            services.AddScoped<IRequestHandler<ComunaCrearCommand, CommandResponse>, ComunaCommandHandler>();
            //services.AddScoped<IRequestHandler<ComunaModificarCommand, CommandResponse>, ComunaCommandHandler>();
            //services.AddScoped<IRequestHandler<ComunaEliminarCommand, CommandResponse>, ComunaCommandHandler>();

            services.AddScoped<IRequestHandler<AyudasSocialesCrearCommand, CommandResponse>, AyudasSocialesCommandHandler>();

            services.AddScoped<IRequestHandler<AsignacionesCrearCommand, CommandResponse>, AsignacionesCommandHandler>();


            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //InfraData
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPaisRepository, PaisRepository>();
            services.AddScoped<IRegionRepository, RegionRepository>();
            services.AddScoped<IComunaRepository, ComunaRepository>();
            services.AddScoped<IAyudasSocialesRepository, AyudasSocialesRepository>();
            services.AddScoped<IAsignacionesRepository, AsignacionesRepository>();

            services.AddScoped<LisitContext>();

            //---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //Infra Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSqlContext>();
        }
    }
}
