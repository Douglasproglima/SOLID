using Alura.LeilaoOnline.WebApp.Dados;
using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.WebApp.Services.Handlers
{
    public class DefaultProductService : IProductService
    {
        ILeilaoDao _auctionDao;
        ICategoriaDao _categoryDao;

        public DefaultProductService(ILeilaoDao auctionDao, ICategoriaDao categoryDao)
        {
            _auctionDao = auctionDao;
            _categoryDao = categoryDao;
        }

        public Categoria GetCategoryByIdAuctionOnTheTradingFloor(int id)
        {
            return _categoryDao.GetById(id);
        }

        public IEnumerable<CategoriaComInfoLeilao> GetCategoriesWithTotalAuctionOnTheTradingFloor()
        {
            return _categoryDao.GetAll()
                .Select(category => new CategoriaComInfoLeilao { 
                    Id = category.Id,
                    Descricao = category.Descricao,
                    Imagem = category.Imagem,
                    EmRascunho = category.Leiloes.Where(auction => auction.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = category.Leiloes.Where(auction => auction.Situacao == SituacaoLeilao.Pregao).Count(),
                    Finalizados = category.Leiloes.Where(auction => auction.Situacao == SituacaoLeilao.Finalizado).Count(),

                });
        }

        public IEnumerable<Leilao> GetAucttionsFromTermAuction(string term)
        {
            var termNormalized = term.ToUpper();
            return _auctionDao.GetAll()
                .Where(c =>
                    c.Titulo.ToUpper().Contains(termNormalized) ||
                    c.Descricao.ToUpper().Contains(termNormalized) ||
                    c.Categoria.Descricao.ToUpper().Contains(termNormalized));
        }
    }
}
