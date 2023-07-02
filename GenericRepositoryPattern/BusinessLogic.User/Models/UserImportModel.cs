namespace BusinessLogic.User.Models
{
    public class UserImportModel
    {
        public UserImportData UserData { get; set; } = new UserImportData();
        public UserImportAuthData AuthData { get; set; } = new UserImportAuthData();
    }

    public class UserImportData
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class UserImportAuthData
    {
        public Guid Id { get; set; }
        public string EncodedPassword { get; set; } = string.Empty;
        public Guid Salt { get; set; }
    }
}
