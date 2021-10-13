using Domain.Contracts;
using Domain.Enums;

namespace Domain.Entity
{
    public class Usuario : IIdentityEntity
    {
        public int ID { get; set; }

        public string Nome { get; set; }

        public EAcesso? Acesso { get; set; }
    }
}
