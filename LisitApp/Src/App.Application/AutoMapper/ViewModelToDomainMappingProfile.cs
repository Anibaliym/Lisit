using App.Application.ViewModels.Usuario;
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
        }
    }
}
