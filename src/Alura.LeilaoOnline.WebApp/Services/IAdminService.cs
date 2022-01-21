using Alura.LeilaoOnline.WebApp.Models;
using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Services
{
    public interface IAdminService
    {
        IEnumerable<Categoria> GetCategories();
        IEnumerable<Leilao> GetAuctions();
        Leilao GetAuctionById(int id);
        void AddAuction(Leilao auction);
        void UpdateAuction(Leilao auction);
        void DeleteAuction(Leilao auction);
        void StartTradingFloorOnTheAuctionId(int id);
        void EndTradingFloorOnTheAuctionId(int id);

    }
}
