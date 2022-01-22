using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.CQRS
{
    public interface IQuery<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
