using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Shared.AppContext.Entities;
using Shared.Http;

namespace Web.Client.Pages
{
    public class UsersModel : PageModel
    {
        private const string Controller = "https://localhost:44385/UserData/";

        [BindProperty]
        public List<UserData> UserCollection { get; set; } = new List<UserData>();

        public UsersModel()
        {
            
        }

        public void OnGet()
        {
            using(var client = new HttpClientWrapper<List<UserData>>())
            {
                var response = client.GetAsync(Controller, new List<string> { "GetAllUsers" }).Result;

                UserCollection = new List<UserData>(response);
            }
          
        }
    }
}
