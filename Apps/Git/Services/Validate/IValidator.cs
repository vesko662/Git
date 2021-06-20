using Git.ViewModels.Repositories;
using Git.ViewModels.Users;


namespace Git.Services.Validate
{
   public interface IValidator
    {
        void ValidateUser(RegisterUserFormModel registerUser);

        void ValidateRepository(RepositoriesCreateViewModel repositoriesCreate);
    }
}
