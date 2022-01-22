using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class LeilaoDaoEFCore : ILeilaoDao
    {
        AppDbContext _context;

        public LeilaoDaoEFCore(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _context.Categorias.ToList();
        }

        public IEnumerable<Leilao> GetAuctions()
        {
            return _context.Leiloes.Include(auction => auction.Categoria).ToList();
        }

        public Leilao GetAuctionId(int id)
        {
            return _context.Leiloes.First(auction => auction.Id == id);
        }

        public void Add(Leilao auction)
        {
            _context.Leiloes.Add(auction);
            _context.SaveChanges();
        }

        public void Update(Leilao auction)
        {
            _context.Leiloes.Update(auction);
            _context.SaveChanges();

        }

        public void Delete(Leilao auction)
        {
            _context.Leiloes.Remove(auction);
            _context.SaveChanges();
        }
    }
}
