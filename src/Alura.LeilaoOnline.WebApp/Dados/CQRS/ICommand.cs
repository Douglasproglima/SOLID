using System.Collections.Generic;

namespace Alura.LeilaoOnline.WebApp.Dados.CQRS
{
    public interface ICommand<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
