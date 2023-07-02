using System.ComponentModel.DataAnnotations;

namespace Shared.AppContext.Interfaces
{
    public interface IEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
