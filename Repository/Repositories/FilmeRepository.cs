using Domain.Entity;
using Repository.Connection;
using Repository.Contracts;
using System.Linq;

namespace Repository.Repositories
{
    public class FilmeRepository : PaiRepository<Filme>, IFilmeRepository
    {

        public FilmeRepository(ApplicationContext dbContext) : base(dbContext)
        {

        }
    }
}
