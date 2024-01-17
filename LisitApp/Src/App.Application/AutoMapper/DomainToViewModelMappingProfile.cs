using App.Application.ViewModels.Asignaciones;
using App.Application.ViewModels.AyudasSociales;
using App.Application.ViewModels.Comuna;
using App.Application.ViewModels.Pais;
using App.Application.ViewModels.Region;
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
            CreateMap<Pais, PaisViewModel>();
            CreateMap<Region, RegionViewModel>();
            CreateMap<Comuna, ComunaViewModel>();
            CreateMap<AyudasSociales, AyudasSocialesViewModel>();
            CreateMap<Asignaciones, AsignacionesViewModel>();
        }
    }
}
