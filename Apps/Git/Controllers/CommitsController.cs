using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Controllers
{
    public class CommitsController:Controller
    {
        public HttpResponse All()
        {
            return View();
        }

        public HttpResponse Create()
        {
            return View();
        }
    }
}
