using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        IEnumerable<Categoria> GetCategories();
        IEnumerable<Leilao> GetAuctions();
        Leilao GetAuctionId(int id);
        void Add(Leilao auction);
        void Update(Leilao auction);
        void Delete(Leilao auction);
    }
}
