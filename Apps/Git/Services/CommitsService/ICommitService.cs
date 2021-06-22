using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services.CommitsService
{
    public interface ICommitService
    {
        void CreateCommit(string description,string repId, string userId);


    }
}
