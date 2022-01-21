using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IProductService
    {
        IEnumerable<Leilao> GetAucttionsFromTermAuction(string term);
        IEnumerable<CategoriaComInfoLeilao> GetCategoriesWithTotalAuctionOnTheTradingFloor();
        Categoria GetCategoryByIdAuctionOnTheTradingFloor(int id);
    }
}
