using Domain.Contracts;

namespace Domain.Entity
{
    public class Filme : IIdentityEntity
    {
        public int ID { get; set; }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public int AnoLancamento { get; set; }
    }
}