using Shared.AppContext.Entities;

namespace BusinessLogic.User.Models
{
    public class UserModel
    {
        public UserData UserData { get; set; } = new UserData();
        public UserAuthenticationData? AuthData { get; set; } = new UserAuthenticationData();
    }
}
