using Git.Data;
using Git.Data.Models;
using Git.Services.PassworHasher;
using System;
using System.Linq;

namespace Git.Services.UserService
{
    public class UserService : IUsersService
    {
        private readonly GitDbContext context;
        private readonly IPasswordHasher hasher;
        public UserService(GitDbContext context, IPasswordHasher hasher)
        {
            this.context = context;
            this.hasher = hasher;
        }
        public void CreateUser(string username, string email, string password)
        {
            if (IsUsernameAvailable(username))
                throw new InvalidOperationException($"User with {username} username already exist!");

            if (IsEmailAvailable(email))
                throw new InvalidOperationException($"User with {email} email already exist!");

            var user = new User()
            {
                Username = username,
                Email = email,
                Password = hasher.PasswordHash(password)
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        public string GetUserId(string username, string password)
        => context
            .Users
            .FirstOrDefault(x => x.Username == username && x.Password == hasher.PasswordHash(password)) == null ?
            null : context.Users.FirstOrDefault(x => x.Username == username && x.Password == hasher.PasswordHash(password)).Id;

        public bool IsEmailAvailable(string email)
            => context.Users.Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username)
            => context.Users.Any(x => x.Username == username);
    }
}
