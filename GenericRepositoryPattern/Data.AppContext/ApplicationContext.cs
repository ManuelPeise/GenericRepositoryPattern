using Microsoft.EntityFrameworkCore;
using Shared.AppContext.Entities;

namespace Data.AppContext
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options): base(options) 
        {
            
        }

        public DbSet<UserData> UserDataTable { get; set; }
        public DbSet<UserAuthenticationData> AuthenticationData { get; set; }
    }
}