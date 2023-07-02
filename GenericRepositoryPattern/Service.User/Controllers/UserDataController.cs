using BusinessLogic.User;
using BusinessLogic.User.Models;
using Data.AppContext;
using Microsoft.AspNetCore.Mvc;
using Shared.AppContext.Entities;

namespace Service.User.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserDataController: ControllerBase
    {
        private ApplicationContext _context;

        public UserDataController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet("{userName}", Name = "GetUser")]
        public async Task<UserData?> GetUser(string userName)
        {
            using(var service = new UserService(_context))
            {
                return await service.GetUser(userName);
            }
        }

        [HttpPost(Name = "AddUser")]
        public async Task AddUser([FromBody] UserImportModel model)
        {
            using (var service = new UserService(_context))
            {
                await service.AddUser(model.UserData, model.AuthData);
            }
        }
    }
}
