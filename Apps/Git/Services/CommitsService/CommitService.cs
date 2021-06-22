using Git.Data;
using Git.Data.Models;
using System;
using System.Collections.Generic;
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
        public void CreateCommit(string description, string repId,string userId)
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
    }
}
