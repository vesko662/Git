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


        public HttpResponse Login() => View();
        [HttpPost]
        public HttpResponse Login(LoginUserFormModel loginUser)
        {
            var id = usersService.GetUserId(loginUser.Username, loginUser.Password);

            if (id==null)
            {
                return Error("Invalid username or passwor!");
            }

            this.SignIn(id);

            return Redirect("/Repositories/All");
        }

        public HttpResponse Register() => View();

        [HttpPost]
        public HttpResponse Register(RegisterUserFormModel registerUser)
        {
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
            this.SignOut();
            return Redirect("/");
        }
    }
}
