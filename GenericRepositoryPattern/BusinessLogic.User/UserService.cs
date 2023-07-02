using BusinessLogic.Shared;
using BusinessLogic.Shared.Interfaces;
using BusinessLogic.User.Interfaces;
using BusinessLogic.User.Models;
using Data.AppContext;
using Shared.AppContext.Entities;
using System.Text;

namespace BusinessLogic.User
{
    public class UserService : IUserService
    {
        private bool disposedValue;

        private IGenericRepo<UserData> _userDataRepo;
        private IGenericRepo<UserAuthenticationData> _userAuthDataRepo;

        public UserService(ApplicationContext context)
        {
            _userDataRepo = new GenericRepository<UserData>(context);
            _userAuthDataRepo = new GenericRepository<UserAuthenticationData>(context);
        }

        public async Task<int> AddUser(UserImportData userData, UserImportAuthData authData)
        {
            var id = Guid.NewGuid();

            userData.Id = id;

            var salt = Guid.NewGuid();

            return await _userDataRepo.AddAsync(new UserData
            {
                Id = id,
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                UserName = userData.UserName,
                Email = userData.Email,
                AuthenticationData = new UserAuthenticationData
                {
                    Id = id,
                    EncodedPassword = GetEncodedPassword(authData.EncodedPassword, salt),
                    Salt = salt
                }
            }, x => x.UserName.ToLower().Equals(userData.UserName.ToLower()));
        }

        public async Task<UserData?> GetUser(string userName)
        {
            var userData = await _userDataRepo.GetEntityAsync(x => x.UserName.Equals(userName));

            if (userData == null)
            {
                return null;
            }

            var authData = await _userAuthDataRepo.GetEntityAsync(x => x.Id == userData.Id);

            return await Task.FromResult(userData);
        }

        public async Task<List<UserData>> GetUsers()
        {
            return await _userDataRepo.GetAllEntitiesAsync();
        }

        #region private members

        private string GetEncodedPassword(string encodedPassword, Guid salt)
        {
            var bytes = Encoding.ASCII.GetBytes(encodedPassword).ToList();
            bytes.AddRange(Encoding.ASCII.GetBytes(salt.ToString()));

            return Convert.ToBase64String(bytes.ToArray());
        }

        #endregion

        #region dispose
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _userDataRepo.Dispose();
                    _userAuthDataRepo.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Ändern Sie diesen Code nicht. Fügen Sie Bereinigungscode in der Methode "Dispose(bool disposing)" ein.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }


        #endregion
    }
}