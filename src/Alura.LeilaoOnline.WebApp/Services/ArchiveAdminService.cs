using System.Collections.Generic;
using System.Linq;
using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class ArchiveAdminService : IAdminService
    {
        IAdminService _defaultService;
        public ArchiveAdminService(ILeilaoDao dao)
        {
            _defaultService = new DefaultAdminService(dao);
        }

        public void AddAuction(Leilao auction)
        {
            _defaultService.AddAuction(auction);
        }

        public void UpdateAuction(Leilao auction)
        {
            _defaultService.UpdateAuction(auction);
        }

        public void DeleteAuction(Leilao auction)
        {
            if (auction != null && auction.Situacao != SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Arquivado;
                _defaultService.DeleteAuction(auction);
            }
        }

        public Leilao GetAuctionById(int id)
        {
            return _defaultService.GetAuctionById(id);
        }

        public IEnumerable<Leilao> GetAuctions()
        {
            return _defaultService
                .GetAuctions()
                .Where(auction => auction.Situacao != SituacaoLeilao.Arquivado);
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _defaultService.GetCategories();
        }

        public void EndTradingFloorOnTheAuctionId(int id)
        {
            _defaultService.EndTradingFloorOnTheAuctionId(id);
        }

        public void StartTradingFloorOnTheAuctionId(int id)
        {
            _defaultService.StartTradingFloorOnTheAuctionId(id);
        }
    }
}
