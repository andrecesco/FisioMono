using Fisioterapia.Core.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Core.DomainObjects
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAlteracao { get; private set; }
        public DateTime? DataDelecao { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
