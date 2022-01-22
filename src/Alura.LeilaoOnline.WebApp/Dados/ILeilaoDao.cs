using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ILeilaoDao
    {
        Leilao GetAuctionId(int id);
        IEnumerable<Leilao> GetAuctions();
        IEnumerable<Categoria> GetCategories();
        void Add(Leilao auction);
        void Update(Leilao auction);
        void Delete(Leilao auction);
    }
}
