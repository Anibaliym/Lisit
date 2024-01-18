using App.Application.Interfaces;
using App.Application.ViewModels.AyudasSociales;
using App.Application.ViewModels.ServiciosDeDominio;
using App.Domain.Core.Messaging;
using Microsoft.AspNetCore.Mvc;

namespace App.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AyudasSocialesController : ApiController
    {
        private readonly IAyudasSocialesAppService _ayudasSocialesAppService;
        private readonly IServiciosDeDominioAppService _serviciosDeDominioAppService;

        public AyudasSocialesController(IAyudasSocialesAppService ayudasSocialesAppService, IServiciosDeDominioAppService serviciosDeDominioAppService)
        {
            _ayudasSocialesAppService = ayudasSocialesAppService;
            _serviciosDeDominioAppService = serviciosDeDominioAppService;
        }

        [HttpPost("CrearAyudaSocialAdministrador")]
        public async Task<IActionResult> CrearAyudaSocialAdministrador(CrearAyudasSocialViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _serviciosDeDominioAppService.CrearAyudaSocialAdministrador(modelo));
        }

        [HttpPost("RegistrarAsignacion")]
        public async Task<IActionResult> RegistrarAsignacion(RegistrarAsignacionViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _serviciosDeDominioAppService.RegistrarAsignacion(modelo));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<AyudasSocialesViewModel> BuscaPorId(Guid id)
        {
            return await _ayudasSocialesAppService.BuscaPorId(id);
        }

        [HttpGet("VerAyudasSocialesUsuarioAdmin")]
        public async Task<CommandResponse> VerAyudasSocialesUsuarioAdmin(Guid idUsuarioGestionador, Guid idUsuarioAConsultar)
        {
            return await _serviciosDeDominioAppService.VerAyudasSocialesUsuarioAdmin(idUsuarioGestionador, idUsuarioAConsultar);
        }

        [HttpGet("VerAyudasSocialesVigentePorAnio")]
        public async Task<CommandResponse> VerAyudasSocialesVigentePorAnio(Guid idUsuario)
        {
            return await _serviciosDeDominioAppService.VerAyudasSocialesVigentePorAnio(idUsuario);
        }
    }
}
