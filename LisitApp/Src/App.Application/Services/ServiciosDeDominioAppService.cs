using App.Application.Interfaces;
using App.Application.ViewModels.ServiciosDeDominio;
using App.Application.ViewModels.Usuario;
using App.Domain.Commands.Asignaciones.Commands;
using App.Domain.Commands.AyudasSociales.Commands;
using App.Domain.Commands.Usuario.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Entities;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;
using System.Net.WebSockets;

namespace App.Application.Services
{
    public class ServiciosDeDominioAppService : IServiciosDeDominioAppService
    {
        private readonly IMapper _mapper;

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPaisRepository _paisRepository;
        private readonly IRegionRepository _regionRepository;
        private readonly IComunaRepository _comunaRepository;
        private readonly IAsignacionesRepository _asignacionesRepository;
        private readonly IAyudasSocialesRepository _ayudasSocialesRepository;

        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public ServiciosDeDominioAppService(IMapper mapper, IUsuarioRepository usuarioRepository, IPaisRepository paisRepository, IRegionRepository regionRepository, IComunaRepository comunaRepository, IAsignacionesRepository asignacionesRepository, IAyudasSocialesRepository ayudasSocialesRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _paisRepository = paisRepository;
            _regionRepository = regionRepository;
            _comunaRepository = comunaRepository;
            _asignacionesRepository = asignacionesRepository;
            _ayudasSocialesRepository = ayudasSocialesRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<CommandResponse> CrearAyudaSocialAdministrador(CrearAyudasSocialViewModel modelo)
        {
            CommandResponse response = new CommandResponse();
            CommandResponse responseCrearAyudaSocial = new CommandResponse();

            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();

            var esUsuarioAdmin = await _usuarioRepository.EsUsuarioAdministrador(modelo.IdUsuario);

            if (esUsuarioAdmin == false) {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no posee permisos de usuario 'ADMINISTRADOR'. Operación canselada.";
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            var createCommand = _mapper.Map<AyudasSocialesCrearCommand>(modelo.AyudasSociales);
            responseCrearAyudaSocial = await _mediator.SendCommand(createCommand);

            if (responseCrearAyudaSocial.Result) 
                response = responseCrearAyudaSocial;
            
            return response;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<CommandResponse> LoginUsuario(string rut, string contrasena)
        {
            CommandResponse response = new();

            var informacionUsuario = await _usuarioRepository.BuscaPor_Rut_Contrasena(rut, contrasena);

            if (informacionUsuario != null)
            {
                response.Result = true;

                response.Data = new
                {
                    Acceso = true,
                    DatosUsuario = new
                    {
                        Nombre = informacionUsuario.Nombre,
                        ApellidoPaterno = informacionUsuario.ApellidoPaterno,
                        Rol = informacionUsuario.Rol
                    },
                    Info = "Acceso Permisito"
                };
            }
            else
            {
                response.Result = true;

                response.Data = new
                {
                    Acceso = false,
                    DatosUsuario = new { },
                    Info = "Acceso Denegado. El rut y la contraseña con coinciden."
                };
            }

            return response;
        }

        public async Task<CommandResponse> RegistrarAsignacion(RegistrarAsignacionViewModel modelo)
        {
            int anioEntrante = modelo.Asignacion.FechaAsignacion.Year;
            CommandResponse response = new CommandResponse();
            CommandResponse responseRegistrarAsignacion = new CommandResponse();
            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();

            var anioAyudaSocial = await _ayudasSocialesRepository.Busca_AnioAyudaSocial(modelo.Asignacion.IdAyudaSocial);

            var existeAsignacionUsuario = await _asignacionesRepository.Busca_AyudaSocialUsuario(modelo.Asignacion.IdAyudaSocial, modelo.Asignacion.IdUsuario);

            if (existeAsignacionUsuario != null) {
                if (modelo.Asignacion.FechaAsignacion.Year == anioAyudaSocial) {
                    response.Result = false;
                    item.ErrorMessage = $"No se le puede asignar a un mismo usuario la misma ayuda social, el mismo año.";
                    response.ValidationResult.Errors.Add(item);
                }
            }

            if (anioAyudaSocial == modelo.Asignacion.FechaAsignacion.Year) {
                response.Result = false;
                item.ErrorMessage = $"";
                response.ValidationResult.Errors.Add(item);

                return response;
            }


            var esUsuarioAdmin = await _usuarioRepository.EsUsuarioAdministrador(modelo.IdUsuario);

            if (esUsuarioAdmin == false)
            {
                response.Result = false;
                item.ErrorMessage = $"El usuario con el id '{modelo.IdUsuario}', no posee permisos de usuario 'ADMINISTRADOR'. Operación canselada.";
                response.ValidationResult.Errors.Add(item);

                return response;
            }

            var createCommand = _mapper.Map<AsignacionesCrearCommand>(modelo.Asignacion);
            responseRegistrarAsignacion = await _mediator.SendCommand(createCommand);

            if (responseRegistrarAsignacion.Result)
                response = responseRegistrarAsignacion;

            return response;
        }

        public async Task<CommandResponse> RegistrarUsuario(UsuarioCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<UsuarioCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> VerAyudasSocialesUsuarioAdmin(Guid idUsuarioGestionador, Guid idUsuarioAConsultar)
        {
            CommandResponse response = new CommandResponse();
            FluentValidation.Results.ValidationFailure item = new FluentValidation.Results.ValidationFailure();

            var esUsuarioAdmin = await _usuarioRepository.EsUsuarioAdministrador(idUsuarioGestionador);

            if (esUsuarioAdmin)
            {
                response.Result = true; 
                response.Data = await _asignacionesRepository.BuscaPorIdUsuario(idUsuarioAConsultar);
            }
            else
            {
                response.Result = false;
                item.ErrorMessage = $"El usuario con id { idUsuarioGestionador }, no posee permisos de administrador.";
                response.ValidationResult.Errors.Add(item);
            }

            return response; 
        }

        public async Task<CommandResponse> VerAyudasSocialesVigentePorAnio(Guid idUsuario)
        {
            CommandResponse response = new CommandResponse();
            response.Data = await _ayudasSocialesRepository.Busca_AnioAyudayAsignacionesUsuario(idUsuario);

            return response;
        }
    } 
} 
