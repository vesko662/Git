using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services.RepositoriesService
{
    public interface IRepositoriesService
    {
        void CreateRepository(string name, bool isPublic, string userId);

        IEnumerable<RepositoriesViewModel> GetAllPublicRepositories();

    }
}
