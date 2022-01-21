using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoEFCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoEFCore()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Leilao> GetAuctions()
        {
            return _context.Leiloes.Include(auction => auction.Categoria).ToList();
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _context.Categorias.ToList();
        }

        public Categoria GetCategoryId(int id)
        {
            return _context.Categorias.First(category => category.Id == id);
        }

        public void Add(Categoria category)
        {
            _context.Categorias.Add(category);
            _context.SaveChanges();
        }

        public void Update(Categoria category)
        {
            _context.Categorias.Update(category);
            _context.SaveChanges();

        }

        public void Delete(Categoria category)
        {
            _context.Categorias.Remove(category);
            _context.SaveChanges();
        }
    }
}
