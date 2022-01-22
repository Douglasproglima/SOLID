using Alura.LeilaoOnline.WebApp.Dados.CQRS;
using Alura.LeilaoOnline.WebApp.Models;

namespace Alura.LeilaoOnline.WebApp.Dados
{
    public interface ICategoriaDao : IQuery<Categoria>
    {
    }
}
