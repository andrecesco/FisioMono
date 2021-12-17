using System.ComponentModel.DataAnnotations;

namespace Fisioterapia.Core.DomainObjects.Old
{
    public abstract class EntityOld
    {
        [Key]
        public int Id { get; set; }
    }
}
