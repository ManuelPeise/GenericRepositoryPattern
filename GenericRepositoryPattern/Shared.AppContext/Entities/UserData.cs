using Shared.AppContext.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.AppContext.Entities
{
    public class UserData : IEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [ForeignKey("Id")]
        public UserAuthenticationData AuthenticationData { get; set; } = new UserAuthenticationData();
    }
}
