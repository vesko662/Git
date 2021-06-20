using Git.Services.RepositoriesService;
using Git.Services.Validate;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Git.Controllers
{
    public class RepositoriesController : Controller
    {
        private readonly IValidator validator;
        private readonly IRepositoriesService repositoriesService;
        public RepositoriesController(IValidator validator, IRepositoriesService repositoriesService)
        {
            this.validator = validator;
            this.repositoriesService = repositoriesService;
        }
        public HttpResponse All()
        {

            return View(repositoriesService.GetAllPublicRepositories());
        }
        public HttpResponse Create() => View();

        [HttpPost]
        public HttpResponse Create(RepositoriesCreateViewModel repositoriesCreate)
        {
            try
            {
                validator.ValidateRepository(repositoriesCreate);
            }
            catch (InvalidOperationException ex)
            {
                return Error(ex.Message);
            }

            var isPublic = repositoriesCreate.RepositoryType == "Public" ? true : false;

            repositoriesService.CreateRepository(repositoriesCreate.Name, isPublic, this.GetUserId());

            return Redirect("/Repositories/All");
        }
    }
}
