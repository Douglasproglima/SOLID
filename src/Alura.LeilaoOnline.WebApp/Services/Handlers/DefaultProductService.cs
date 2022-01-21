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

        public IEnumerable<Leilao> GetAucttionsFromTermAuction(string term)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<CategoriaComInfoLeilao> GetCategoriesWithTotalAuctionOnTheTradingFloor()
        {
            return _categoryDao.GetAuctions()
                .Select(category => new CategoriaComInfoLeilao { 
                    Id = category.Id,
                    Descricao = category.Descricao,
                    Imagem = category.PosterUrl,
                    EmRascunho = category.Leiloes.Where(l => l.Situacao == SituacaoLeilao.Rascunho).Count(),
                    EmPregao = category.Leiloes.Where(l => l. == SituacaoLeilao.Rascunho).Count(),

                });
        }

        public Categoria GetCategoryByIdAuctionOnTheTradingFloor(int id)
        {
            return _categoryDao.GetCategoryId(id);
        }
    }
}
