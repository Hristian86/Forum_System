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
                return this.View(viewModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // To Do send message to my email for example
                return this.RedirectToAction("Home", "HandleError");
            }
        }

        [Authorize]
        public IActionResult Create(int? id)
        {
            try
            {
                var categoriesList = this.categories.GetAll<CategoryDropDownViewModel>();
                var viewModel = new PostCreateInputModel();
                viewModel.Categories = categoriesList;
                if (id != null)
                {
                    viewModel.Id = (int)id;
                }

                return this.View(viewModel);
            }
            catch (Exception)
            {
                // To Do send message to my email for example
                return this.RedirectToAction("HandleError", "Home");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                // Global message for not created post
                return this.RedirectToAction("Index", "Categories");
            }

            try
            {
                var currUser = await this.userManager.GetUserAsync(this.User);
                var postId = await this.postService.CreateAsync(model.Title, model.Content, model.Id, currUser.Id);
                return this.RedirectToAction("ById", new { id = postId });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // To Do send message to my email for example
                return this.RedirectToAction("HandleError", "Home");
            }
        }
    }
}
