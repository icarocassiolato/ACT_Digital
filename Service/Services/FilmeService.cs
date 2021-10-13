using System;
using System.Collections.Generic;
using Domain.Entity;
using Repository.Contracts;
using Service.Contracts;

namespace Service.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmeService(IFilmeRepository filmeRepository)
            => _filmeRepository = filmeRepository;

        public IEnumerable<Filme> PegarTodos()
            => _filmeRepository.PegarTodos();

        public Filme PegarPorId(object id)
            => _filmeRepository.PegarPorId(id);

        public Filme Adicionar(Filme filme)
        {
            if ((filme.Titulo == null) || (filme.Titulo.Length == 0))
                throw new ApplicationException("O título do filme precisa ser informado!");

            if (filme.AnoLancamento == 0)
                throw new ApplicationException("O ano de lançamento do filme precisa ser informado!");

            return _filmeRepository.Adicionar(filme);
        } 

        public int Atualizar(Filme filme)
            => _filmeRepository.Atualizar(filme);

        public bool Remover(object id)
            => _filmeRepository.Remover(id);
    }
}
