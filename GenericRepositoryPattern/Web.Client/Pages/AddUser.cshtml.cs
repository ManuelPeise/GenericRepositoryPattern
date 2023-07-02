using BusinessLogic.User.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.Http;

namespace Web.Client.Pages
{
    public class AddUserModel : PageModel
    {
        private const string Controller = "https://localhost:44385/UserData/";

        public AddUserModel()
        {
           
        }

        public void OnGet()
        {
        }

        public async void OnPost()
        {
            var userData = new UserImportModel
            {
                UserData = new UserImportData
                {
                    Id = Guid.NewGuid(),
                    FirstName = Request.Form["firstName"],
                    LastName = Request.Form["lastName"],
                    UserName = Request.Form["userName"],
                    Email = Request.Form["email"],
                },
                AuthData = new UserImportAuthData
                {
                    Id = Guid.NewGuid(),
                    EncodedPassword = Request.Form["password"],
                    Salt = Guid.NewGuid()
                }
            };

            using (var client = new HttpClientWrapper<UserImportModel>())
            {
                await client.Post(Controller, "AddUser", userData);
            }
        }

      
    }
}
