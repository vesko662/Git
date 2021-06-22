using Git.Data.Models;
using Git.ViewModels.Commits;
using System.Collections.Generic;

namespace Git.Services.CommitsService
{
    public interface ICommitService
    {
        void CreateCommit(string description,string repId, string userId);

        Commit GetCommit(string commitId);

        IEnumerable<CommitViewModel> GetAllCommits();

        void DeleteCommit(string commitId,string userId);
    }
}
