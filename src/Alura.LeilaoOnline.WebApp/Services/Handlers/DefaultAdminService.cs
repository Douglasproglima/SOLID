using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDao _dao;

        public DefaultAdminService(ILeilaoDao dao)
        { 
            _dao = dao;
        }

        public void AddAuction(Leilao auction)
        {
            _dao.Add(auction);
        }

        public void UpdateAuction(Leilao auction)
        {
            _dao.Update(auction);
        }

        public void DeleteAuction(Leilao auction)
        {
            if(auction != null && auction.Situacao != SituacaoLeilao.Pregao)
                _dao.Delete(auction);
        }

        public Leilao GetAuctionById(int id)
        {
            return _dao.GetAuctionId(id);
        }

        public IEnumerable<Leilao> GetAuctions()
        {
            return _dao.GetAuctions();
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _dao.GetCategories();
        }

        public void StartTradingFloorOnTheAuctionId(int id)
        {
            var auction = _dao.GetAuctionId(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Rascunho)
            {
                auction.Situacao = SituacaoLeilao.Pregao;
                auction.Inicio = DateTime.Now;
                _dao.Update(auction);
            }
        }

        public void EndTradingFloorOnTheAuctionId(int id)
        {
            var auction = _dao.GetAuctionId(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Finalizado;
                auction.Termino = DateTime.Now;
                _dao.Update(auction);
            }
        }
    }
}
