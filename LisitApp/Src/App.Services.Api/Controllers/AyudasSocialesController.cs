using App.Application.Interfaces;
using App.Application.ViewModels.AyudasSociales;
using Microsoft.AspNetCore.Mvc;

namespace App.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class AyudasSocialesController : ApiController
    {
        private readonly IAyudasSocialesAppService _ayudasSocialesAppService;

        public AyudasSocialesController(IAyudasSocialesAppService ayudasSocialesAppService)
        {
            _ayudasSocialesAppService = ayudasSocialesAppService;
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear(AyudasSocialesCrearViewModel modelo)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState) : CustomResponse(await _ayudasSocialesAppService.Crear(modelo));
        }

        [HttpGet("BuscaPorId/{id:guid}")]
        public async Task<AyudasSocialesViewModel> BuscaPorId(Guid id)
        {
            return await _ayudasSocialesAppService.BuscaPorId(id);
        }
    }
}
