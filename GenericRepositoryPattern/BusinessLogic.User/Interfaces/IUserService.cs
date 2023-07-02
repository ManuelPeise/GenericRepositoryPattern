using BusinessLogic.User.Models;
using Shared.AppContext.Entities;

namespace BusinessLogic.User.Interfaces
{
    public interface IUserService: IDisposable
    {
        Task<int> AddUser(UserImportData userData, UserImportAuthData authData);
        Task<UserData?> GetUser(string userName);
        Task<List<UserData>> GetUsers();
    }
}
