using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados.EFCore
{
    public class CategoriaDaoEFCore : ICategoriaDao
    {
        AppDbContext _context;

        public CategoriaDaoEFCore(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Categoria> GetCategories()
        {
            return _context
                .Categorias
                .Include(c => c.Leiloes);
        }

        public Categoria GetCategoryId(int id)
        {
            return _context.Categorias
                .Include(category => category.Leiloes)
                .First();
        }
    }
}
