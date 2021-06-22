using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using Git.ViewModels.Users;


namespace Git.Services.Validate
{
   public interface IValidator
    {
        void ValidateUser(RegisterUserFormModel registerUser);

        void ValidateRepository(RepositoriesCreateViewModel repositoriesCreate);

        void ValidateCommit(CommitsCreateFormModel repositoriesCreate);
    }
}
