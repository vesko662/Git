using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services.RepositoriesService
{
    public class ReppositoriesService : IRepositoriesService
    {
        private readonly GitDbContext context;
        public ReppositoriesService(GitDbContext context)
        {
            this.context = context;
        }
        public void CreateRepository(string name, bool isPublic, string userId)
        {
            var repository = new Repository()
            {
                Name = name,
                CreatedOn = DateTime.UtcNow,
                IsPublic = isPublic,
                Owner=context.Users.Find(userId),
                OwnerId = userId,
            };

            context.Repositories.Add(repository);
            context.SaveChanges();
        }

        public IEnumerable<RepositoriesViewModel> GetAllPublicRepositories()
        => context.Repositories
            .Where(x => x.IsPublic == true)
            .Include(x=>x.Owner)
            .Include(x=>x.Commits)
            .Select(s => new RepositoriesViewModel()
            {
                Name = s.Name,
                CreatedOn = s.CreatedOn,
                Owner = s.Owner.Username,
                ComitsCount = s.Commits.ToList().Count,
                Id = s.Id
            })
            .ToList();
    }
}
