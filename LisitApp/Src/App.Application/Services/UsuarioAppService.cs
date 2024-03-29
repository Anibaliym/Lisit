﻿using App.Application.EventSourcedNormalizers;
using App.Application.EventSourcedNormalizers.Usuario;
using App.Application.Interfaces;
using App.Application.ViewModels.Usuario;
using App.Domain.Commands.Usuario.Commands;
using App.Domain.Core.Mediator;
using App.Domain.Core.Messaging;
using App.Domain.Interfaces;
using App.Infra.Data.Repository.EventSourcing;
using AutoMapper;

namespace App.Application.Services
{
    public class UsuarioAppService : IUsuarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _mediator;

        public UsuarioAppService(IMapper mapper, IUsuarioRepository usuarioRepository, IEventStoreRepository eventStoreRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _usuarioRepository = usuarioRepository;
            _eventStoreRepository = eventStoreRepository;
            _mediator = mediator;
        }

        public async Task<UsuarioViewModel> BuscaPorId(Guid id)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorId(id));

        }

        public async Task<UsuarioViewModel> BuscaPorRut(string rut)
        {
            return _mapper.Map<UsuarioViewModel>(await _usuarioRepository.BuscaPorRut(rut));
        }

        public async Task<CommandResponse> Crear(UsuarioCrearViewModel modelo)
        {
            var createCommand = _mapper.Map<UsuarioCrearCommand>(modelo);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<CommandResponse> Eliminar(Guid id)
        {
            var deleteCommand = new UsuarioEliminarCommand(id);
            return await _mediator.SendCommand(deleteCommand);
        }

        public async Task<CommandResponse> Modificar(UsuarioModificarViewModel modelo)
        {
            var updateCommand = _mapper.Map<UsuarioModificarCommand>(modelo);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<IList<UsuarioHistoryData>> GetAllHistory(Guid id)
        {
            return UsuarioHistory.ToJavaScriptCustomerHistory(await _eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
