using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public class LeilaoDao
    {
        AppDbContext _context;

        public LeilaoDao()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Leilao> GetAucttions()
        {
            return _context.Leiloes.Include(auction => auction.Categoria).ToList();
        }

        public Leilao GetAuctionId(int id)
        {
            return _context.Leiloes.First(auction => auction.Id == id);
        }
    }
}
