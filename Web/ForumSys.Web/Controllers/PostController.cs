namespace ForumSys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Data.Common.Repositories;
    using ForumSys.Data.Models;
    using ForumSys.Services.Data;
    using ForumSys.Web.ViewModels.OutPutViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICategoryService categories;
        private readonly IPostService postService;

        public PostController(
            UserManager<ApplicationUser> userManager,
            ICategoryService categories,
            IPostService postService)
        {
            this.userManager = userManager;
            this.categories = categories;
            this.postService = postService;
        }

        public IActionResult ById(int id)
        {
            try
            {
                var viewModel = this.postService.GetById<PostViewModel>(id);
                if (viewModel == null)
                {
                    return this.NotFound();
                }

                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction("Home", "Error");
            }
        }

        [Authorize]
        public IActionResult Create()
        {
            var categoriesList = this.categories.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel();
            viewModel.Categories = categoriesList;

            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest();
            }

            try
            {
                var currUser = await this.userManager.GetUserAsync(this.User);
                var postId = await this.postService.CreateAsync(model.Title, model.Content, model.CategoryId, currUser.Id);
                return this.RedirectToAction("ById", new { id = postId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return this.RedirectToAction("Home", "Error");
            }
        }
    }
}
