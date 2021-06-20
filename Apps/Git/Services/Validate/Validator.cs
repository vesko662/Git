using Git.ViewModels.Repositories;
using Git.ViewModels.Users;
using System;
using System.Text.RegularExpressions;
using static Git.Data.DataConstants;


namespace Git.Services.Validate
{
    public class Validator : IValidator
    {
        public void ValidateRepository(RepositoriesCreateViewModel repositoriesCreate)
        {
            if (repositoriesCreate.Name.Length < defaultMinLenght || repositoriesCreate.Name.Length > defaultMaxLenght)
            {
                throw new InvalidOperationException($"Repository name must be between {defaultMinLenght} and {defaultMaxLenght} characters long!");
            }
        }

        public void ValidateUser(RegisterUserFormModel registerUser)
        {
            if (registerUser.Username.Length<defaultMinLenght|| registerUser.Username.Length>defaultMaxLenght )
            {
                throw new InvalidOperationException($"Username must be between {defaultMinLenght} and {defaultMaxLenght} characters long!");
            }

            if (!Regex.IsMatch(registerUser.Email,UserEmailRegularExpression))
            {
                throw new InvalidOperationException($"Email is not valid!");

            }

            if (registerUser.Password.Length < passwordMinLenght || registerUser.Password.Length > defaultMaxLenght)
            {
                throw new InvalidOperationException($"Password must be between {passwordMinLenght} and {defaultMaxLenght} characters long!");
            }

            if (registerUser.Password != registerUser.ConfirmPassword)
            {
                throw new InvalidOperationException("Password and confirm password must be equal!");
            }
        }
    }
}
