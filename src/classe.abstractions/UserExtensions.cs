namespace ClassE
{
    internal static class UserExtensions
    {
        public static Entities.User? Users(this Data.IDataContext dataContext, Types.Options options, string username)
        {
            if (!"admin".Equals(username, StringComparison.OrdinalIgnoreCase))
                return null;

            return dataContext.Users(options);
        }

        public static Entities.User Users(this Data.IDataContext _, Types.Options options)
        {
            return new()
            {
                Id = 1,
                Name = "Admin",
                Email = "Admin",
                Password = options.Password,
                IsAdmin = true,
            };
        }

        public static Types.TokenResult ToResult(this Entities.User user, string token) => new()
        {
            Success = true,
            Token = token,
            IsAdmin = user.IsAdmin,
            Expires = DateTimeOffset.UtcNow.AddMinutes(5)
        };
    }
}