using System;
using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Core.DomainObjects
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public DateTime? DataDelecao { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
