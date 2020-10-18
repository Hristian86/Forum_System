namespace ForumSys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Common;
    using ForumSys.Services.Data;
    using ForumSys.Services.Mapping;
    using ForumSys.Web.ViewModels.OutPutViewModels.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 5;

        private readonly ICategoryService categoryService;
        private readonly IPostService postService;

        public CategoriesController(
            ICategoryService categoryService,
            IPostService postService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
        }

        public ActionResult ByName(string name, int? page)
        {
            if (!page.HasValue || page <= 0)
            {
                page = 1;
            }

            try
            {
                var viewModel = this.categoryService.GetByName<GetByNameViewModel>(name);
                var count = viewModel.PostsCount;
                if (count == 0)
                {
                    return this.View(viewModel);
                }

                var pageCount = (int)Math.Ceiling((double)count / ItemsPerPage);
                if (page > pageCount)
                {
                    page = pageCount;
                }

                viewModel.PagesCount = pageCount;

                viewModel.ForumPosts = this.postService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (int)((page - 1) * ItemsPerPage));
                viewModel.CurrentPage = (int)page;

                if (viewModel == null)
                {
                    return this.RedirectToAction("Index", "Categories");
                }

                return this.View(viewModel);
            }
            catch (Exception)
            {
                // To Do send message to my email for example
                return this.RedirectToAction("HandleError", "Home");
            }
        }

        // GET: Categories
        public ActionResult Index()
        {
            try
            {
                var viewModel = new CategoryProectionViewModel();

                var categories = this.categoryService.GetAll<CategoryViewModel>();
                viewModel.Categories = categories;

                return this.View(viewModel);
            }
            catch (Exception)
            {
                // To Do send message to my email for example
                return this.RedirectToAction("HandleError", "Home");
            }
        }

        // GET: Categories/Details/5
        [Authorize(GlobalConstants.AdministratorRoleName)]
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: Categories/Create
        [Authorize(GlobalConstants.AdministratorRoleName)]
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Categories/Create
        [Authorize(GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Categories/Edit/5
        [Authorize(GlobalConstants.AdministratorRoleName)]
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: Categories/Edit/5
        [Authorize(GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }

        // GET: Categories/Delete/5
        [Authorize(GlobalConstants.AdministratorRoleName)]
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Categories/Delete/5
        [Authorize(GlobalConstants.AdministratorRoleName)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
