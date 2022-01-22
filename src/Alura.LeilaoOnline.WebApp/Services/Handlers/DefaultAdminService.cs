using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultAdminService : IAdminService
    {
        ILeilaoDao _auctionDao;
        ICategoriaDao _categoriaDao;

        public DefaultAdminService(ILeilaoDao dao, ICategoriaDao categoriaDao)
        {
            _auctionDao = dao;
            _categoriaDao = categoriaDao;
        }

        public void AddAuction(Leilao auction)
        {
            _auctionDao.Add(auction);
        }

        public void UpdateAuction(Leilao auction)
        {
            _auctionDao.Update(auction);
        }

        public void DeleteAuction(Leilao auction)
        {
            if(auction != null && auction.Situacao != SituacaoLeilao.Pregao)
                _auctionDao.Delete(auction);
        }

        public Leilao GetAuctionById(int id)
        {
            return _auctionDao.GetById(id);
        }

        public IEnumerable<Leilao> GetAuctions()
        {
            return _auctionDao.GetAll();
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _categoriaDao.GetAll();
        }

        public void StartTradingFloorOnTheAuctionId(int id)
        {
            var auction = _auctionDao.GetById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Rascunho)
            {
                auction.Situacao = SituacaoLeilao.Pregao;
                auction.Inicio = DateTime.Now;
                _auctionDao.Update(auction);
            }
        }

        public void EndTradingFloorOnTheAuctionId(int id)
        {
            var auction = _auctionDao.GetById(id);
            if (auction != null && auction.Situacao == SituacaoLeilao.Pregao)
            {
                auction.Situacao = SituacaoLeilao.Finalizado;
                auction.Termino = DateTime.Now;
                _auctionDao.Update(auction);
            }
        }
    }
}
