using Git.Data.Models;
using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services.RepositoriesService
{
    public interface IRepositoriesService
    {
        void CreateRepository(string name, bool isPublic, string userId);

        Repository GetRepository(string repId);

        IEnumerable<RepositoriesViewModel> GetAllPublicRepositories();

    }
}
