using Microsoft.AspNetCore.Mvc;
using Alura.LeilaoOnline.WebApp.Models;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Services;

namespace Alura.LeilaoOnline.WebApp.Controllers
{
    [ApiController]
    [Route("/api/leiloes")]
    public class LeilaoApiController : ControllerBase
    {
        IAdminService _service;

        public LeilaoApiController(IAdminService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult EndpointGetLeiloes()
        {
            var leiloes = _service.GetAuctions();

            return Ok(leiloes);
        }

        [HttpGet("{id}")]
        public IActionResult EndpointGetLeilaoById(int id)
        {
            var leilao = _service.GetAuctionById(id);
            if (leilao == null) return NotFound();

            return Ok(leilao);
        }

        [HttpPost]
        public IActionResult EndpointPostLeilao(Leilao leilao)
        {
            _service.AddAuction(leilao);

            return Ok(leilao);
        }

        [HttpPut]
        public IActionResult EndpointPutLeilao(Leilao leilao)
        {
            if (_service.GetAuctionById(leilao.Id) == null) return NotFound();
            _service.UpdateAuction(leilao);
            return Ok(leilao);
        }

        [HttpDelete("{id}")]
        public IActionResult EndpointDeleteLeilao(int id)
        {
            var leilao = _service.GetAuctionById(id);
            if (leilao == null) return NotFound();
            _service.DeleteAuction(leilao);

            return NoContent();
        }

        [HttpPost("{id}/pregao")]
        public IActionResult EndpointIniciaPregao(int id)
        {
            var leilao = _service.GetAuctionById(id);
            if (leilao == null) return NotFound();
            _service.StartTradingFloorOnTheAuctionId(id);
            return Ok();
        }

        [HttpDelete("{id}/pregao")]
        public IActionResult EndpointFinalizaPregao(int id)
        {
            var leilao = _service.GetAuctionById(id);
            if (leilao == null) return NotFound();
            _service.EndTradingFloorOnTheAuctionId(id);
            return Ok();
        }
    }
}
