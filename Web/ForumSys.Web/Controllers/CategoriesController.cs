namespace ForumSys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Services.Data;
    using ForumSys.Services.Mapping;
    using ForumSys.Web.ViewModels.OutPutViewModels.Category;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        public ActionResult ByName(string name)
        {
            var viewModel = this.categoryService.GetByName<GetByNameViewModel>(name);
            return this.View(viewModel);
        }

        // GET: Categories
        public ActionResult Index()
        {
            var viewModel = new CategoryProectionViewModel();

            var categories = this.categoryService.GetAll<CategoryViewModel>();
            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            return this.View();
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return this.View();
        }

        // POST: Categories/Create
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
        public ActionResult Edit(int id)
        {
            return this.View();
        }

        // POST: Categories/Edit/5
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
        public ActionResult Delete(int id)
        {
            return this.View();
        }

        // POST: Categories/Delete/5
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
