namespace Git
{
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;

    using Data;
    using Services;
    using SUS.HTTP;
    using SUS.MvcFramework;
    using Git.Services.Validate;
    using Git.Services.UserService;
    using Git.Services.PassworHasher;
    using Git.Services.RepositoriesService;
    using Git.Services.CommitsService;

    public class Startup : IMvcApplication
    {
        public void Configure(List<Route> routeTable)
        {
            new GitDbContext().Database.Migrate();
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IValidator, Validator>();
            serviceCollection.Add<IUsersService,UserService>();
            serviceCollection.Add<IPasswordHasher, PasswordHasher>();
            serviceCollection.CreateInstance(typeof(GitDbContext));
            serviceCollection.Add<IRepositoriesService, ReppositoriesService>();
            serviceCollection.Add<ICommitService, CommitService>();
        }
    }
}
