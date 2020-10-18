namespace ForumSys.Web.Controllers
{
    using System.Diagnostics;

    using ForumSys.Web.ViewModels;

    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        //[Route("/Home/HandleError/{code:int}")]
        public IActionResult HandleError(int code = 404)
        {
            this.ViewData["ErrorMessage"] = $"Error occurred. Error: {code}";
            return this.View("~/Views/Shared/HandleError.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
