﻿using Git.Services.CommitsService;
using Git.Services.RepositoriesService;
using Git.Services.Validate;
using Git.ViewModels.Commits;
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
        private readonly IValidator validator;
        private readonly ICommitService commitService;
        public CommitsController(IRepositoriesService repositoriesService, IValidator validator,ICommitService commitService)
        {
            this.repositoriesService = repositoriesService;
            this.validator = validator;
            this.commitService = commitService;
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
        public HttpResponse Create(CommitsCreateFormModel commitsCreate)
        {
            try
            {
                validator.ValidateCommit(commitsCreate);
            }
            catch (InvalidOperationException ex)
            {
                return Error(ex.Message);
            }

            commitService.CreateCommit(commitsCreate.Description, commitsCreate.Id, this.GetUserId());
            

            return Redirect("/Repositories/All");
        }

        public HttpResponse Delete()
        {
            return Redirect("");
        }
    }
}
