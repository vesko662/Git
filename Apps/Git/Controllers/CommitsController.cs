using Git.Services.RepositoriesService;
using Git.ViewModels.Repositories;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController : Controller
    {
        private readonly IRepositoriesService repositoriesService;
        public CommitsController(IRepositoriesService repositoriesService)
        {
            this.repositoriesService = repositoriesService;
        }
        public HttpResponse All()
        {
            return View();
        }

        public HttpResponse Create(string Id)
        {
            var repository = repositoriesService.GetRepository(Id);

            var repDetails = new RepositoryDetailsViewModel() { Name = repository.Name, Id = repository.Id };

            return View(repDetails);
        }
        [HttpPost]
        public HttpResponse Create()
        {
            return Redirect("/Repositories/All");
        }

        public HttpResponse Delete()
        {
            return Redirect("");
        }
    }
}
