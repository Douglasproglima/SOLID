using System.Collections.Generic;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDao
    {
        IEnumerable<Leilao> GetAuctions();
        IEnumerable<Categoria> GetCategories();
        Categoria GetCategoryId(int id);
        void Add(Categoria category);
        void Update(Categoria category);
        void Delete(Categoria category);
    }
}
