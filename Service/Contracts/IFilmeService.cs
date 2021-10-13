using System.Collections.Generic;
using Domain.Entity;

namespace Service.Contracts
{
    public interface IFilmeService
    {
        IEnumerable<Filme> PegarTodos();

        Filme PegarPorId(object id);

        Filme Adicionar(Filme Filme);

        int Atualizar(Filme Filme);

        bool Remover(object id);
    }
}
