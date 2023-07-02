using Shared.AppContext.Interfaces;

namespace Shared.AppContext.Entities
{
    public class UserAuthenticationData : IEntity
    {
        public Guid Id { get; set; }
        public string EncodedPassword { get; set; } = string.Empty;
        public Guid Salt { get; set; }
    }
}
