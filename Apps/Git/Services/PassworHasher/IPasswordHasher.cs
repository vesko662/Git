using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services.PassworHasher
{
    public interface IPasswordHasher
    {
        string PasswordHash(string password);
    }
}
