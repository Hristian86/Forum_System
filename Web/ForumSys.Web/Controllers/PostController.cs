namespace ForumSys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Web.ViewModels.OutPutViewModels.Posts;
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        public PostController()
        {
        }

        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Create(PostCreateInputModel model)
        {
            return this.View();
        }
    }
}
