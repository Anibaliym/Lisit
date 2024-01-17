using App.Application.ViewModels.AyudasSociales;
using App.Application.ViewModels.Comuna;
using App.Application.ViewModels.Pais;
using App.Application.ViewModels.Region;
using App.Application.ViewModels.Usuario;
using App.Domain.Commands.AyudasSociales.Commands;
using App.Domain.Commands.Comuna.Commands;
using App.Domain.Commands.Pais.Commands;
using App.Domain.Commands.Region.Commands;
using App.Domain.Commands.Usuario.Commands;
using AutoMapper;

namespace App.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            #region Usuario
            
            CreateMap<UsuarioCrearViewModel, UsuarioCrearCommand>().ConstructUsing(usuario => new UsuarioCrearCommand(
                usuario.Rut, 
                usuario.Nombre, 
                usuario.ApellidoPaterno, 
                usuario.Contrasena,
                usuario.Rol
            ));

            CreateMap<UsuarioModificarViewModel, UsuarioModificarCommand>().ConstructUsing(usuario => new UsuarioModificarCommand(
                usuario.Id, 
                usuario.Rut, 
                usuario.Nombre, 
                usuario.ApellidoPaterno, 
                usuario.Contrasena, 
                usuario.Rol
            ));

            #endregion

            #region Pais

            CreateMap<PaisCrearViewModel, PaisCrearCommand>().ConstructUsing(pais => new PaisCrearCommand(pais.Nombre));

            CreateMap<PaisViewModel, PaisModificarCommand>().ConstructUsing(pais => new PaisModificarCommand(pais.Id, pais.Nombre));

            #endregion

            #region Region

            CreateMap<RegionCrearViewModel, RegionCrearCommand>().ConstructUsing(region => new RegionCrearCommand(region.IdPais, region.Nombre));

            #endregion

            #region Comuna
            CreateMap<ComunaCrearViewModel, ComunaCrearCommand>().ConstructUsing(comuna => new ComunaCrearCommand(comuna.IdRegion, comuna.Nombre));
            #endregion

            #region AyudasSociales
            CreateMap<AyudasSocialesCrearViewModel, AyudasSocialesCrearCommand>().ConstructUsing(item => new AyudasSocialesCrearCommand(item.IdComuna, item.Descripcion, item.Anio));
            #endregion
        }
    }
}
