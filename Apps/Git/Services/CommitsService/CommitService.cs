using Git.Data;
using Git.Data.Models;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services.CommitsService
{
    public class CommitService : ICommitService
    {
        private readonly GitDbContext context;
        public CommitService(GitDbContext context)
        {
            this.context = context;
        }
        public void CreateCommit(string description, string repId, string userId)
        {
            var commit = new Commit()
            {
                Description = description,
                CreatedOn = DateTime.UtcNow,
                RepositoryId = repId,
                CreatorId = userId
            };

            context.Commits.Add(commit);

            context.SaveChanges();
        }

        public void DeleteCommit(string commitId, string userId)
        {
            var commit = this.GetCommit(commitId);

            if (commit.CreatorId == userId)
            {
                context.Commits.Remove(commit);
                context.SaveChanges();
            }

        }

        public IEnumerable<CommitViewModel> GetAllCommits()
        => context
            .Commits
            .Select(s => new CommitViewModel()
            {
                Id = s.Id,
                CreatedOn = s.CreatedOn,
                RepositoryName = s.Repository.Name,
                Description = s.Description
            }).ToList();

        public Commit GetCommit(string commitId)
        => context.Commits.Find(commitId);
    }
}
