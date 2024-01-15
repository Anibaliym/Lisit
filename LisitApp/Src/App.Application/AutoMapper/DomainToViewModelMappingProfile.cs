using App.Application.ViewModels.Usuario;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
