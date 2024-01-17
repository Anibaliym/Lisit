using App.Application.Interfaces;
using App.Application.ViewModels.Usuario;
using App.Domain.Core.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace App.Services.Api.Controllers
{
    [Route("api/[controller]")]

    public class AutentificacionController : ApiController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AutentificacionController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost("RegistrarUsuario")]
        public async Task<IActionResult> RegistrarUsuario(UsuarioCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _usuarioAppService.Crear(modelo));
        }

        [HttpGet("LoginUsuario")]
        public async Task<CommandResponse> LoginUsuario(string rut, string contrasena)
        {
            return await _usuarioAppService.LoginUsuario(rut, contrasena);
        }
    }
}
