using Git.Services.UserService;
using Git.Services.Validate;
using Git.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;

namespace Git.Controllers
{
    public class UsersController : Controller
    {
        private readonly IValidator validator;
        private readonly IUsersService usersService;

        public UsersController(IValidator validator, IUsersService usersService)
        {
            this.validator = validator;
            this.usersService = usersService;
        }


        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Login(LoginUserFormModel loginUser)
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            var id = usersService.GetUserId(loginUser.Username, loginUser.Password);

            if (id == null)
            {
                return Error("Invalid username or passwor!");
            }

            this.SignIn(id);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            return View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel registerUser)
        {
            if (this.IsUserSignedIn())
            {
                return Redirect("/Repositories/All");
            }

            try
            {
                validator.ValidateUser(registerUser);
                usersService.CreateUser(registerUser.Username, registerUser.Email, registerUser.Password);
            }
            catch (InvalidOperationException ex)
            {
                return Error(ex.Message);
            }

            return Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            if (this.IsUserSignedIn() != true)
            {
                return Redirect("/Users/Login");
            }

            this.SignOut();
            return Redirect("/");
        }
    }
}
