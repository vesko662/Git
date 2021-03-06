using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;
using System;
using System.Text.RegularExpressions;
using static Git.Data.DataConstants;


namespace Git.Services.Validate
{
    public class Validator : IValidator
    {
        public void ValidateCommit(CommitsCreateFormModel repositoriesCreate)
        {
            if (string.IsNullOrWhiteSpace(repositoriesCreate.Description) || repositoriesCreate.Description.Length < defaultMinLenght)
            {
                throw new InvalidOperationException($"Commit description must be above {defaultMinLenght} characters long!");
            }
        }

        public void ValidateRepository(RepositoriesCreateViewModel repositoriesCreate)
        {
            if (string.IsNullOrWhiteSpace(repositoriesCreate.Name) || repositoriesCreate.Name.Length < defaultMinLenght || repositoriesCreate.Name.Length > defaultMaxLenght)
            {
                throw new InvalidOperationException($"Repository name must be between {repositoriesCreate} and {defaultMaxLenght} characters long!");
            }
        }

        public void ValidateUser(RegisterUserFormModel registerUser)
        {
            if (string.IsNullOrWhiteSpace(registerUser.Username) || registerUser.Username.Length<defaultMinLenght|| registerUser.Username.Length>defaultMaxLenght )
            {
                throw new InvalidOperationException($"Username must be between {defaultMinLenght} and {defaultMaxLenght} characters long!");
            }

            if ( !Regex.IsMatch(registerUser.Email,UserEmailRegularExpression))
            {
                throw new InvalidOperationException($"Email is not valid!");

            }

            if (string.IsNullOrWhiteSpace(registerUser.Password) || registerUser.Password.Length < passwordMinLenght || registerUser.Password.Length > defaultMaxLenght)
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
