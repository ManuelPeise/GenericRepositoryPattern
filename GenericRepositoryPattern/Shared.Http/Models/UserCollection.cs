using Shared.AppContext.Entities;
using Shared.Http.Interfaces;

namespace Shared.Http.Models
{
    public class UserCollection : IRequestModel
    {
        public Guid RequestId { get; set; }
        public List<UserData?> UserDataCollection { get; set; } = new List<UserData?>();
    }
}
