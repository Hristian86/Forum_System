﻿namespace ForumSys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Data.Models;
    using ForumSys.Services.Data;
    using ForumSys.Web.ViewModels.OutPutViewModels.Comments;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class CommentsController : Controller
    {
        private readonly ICommentService commentService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentService commentService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentService = commentService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentsInputModel model)
        {
            try
            {
                var user = await this.userManager.GetUserAsync(this.User);
                if (user == null)
                {
                    // Identity/Account/Login
                    return this.Redirect("/Identity/Account/Login");
                }

                await this.commentService.CreateComment(model.PostId, user.Id, model.Content, model.Title);

                return this.RedirectToAction("ById", "Post", new { id = model.PostId });
            }
            catch (Exception ex)
            {
                if (ex.Message == "Content must be at least 5 symbols")
                {
                    this.TempData["error"] = "Content is required";
                    return this.RedirectToAction("ById", "Post", new { id = model.PostId });
                }
                else if (ex.Message == "Content must be under 15000 symbols")
                {
                    this.TempData["error"] = ex.Message;
                    return this.RedirectToAction("ById", "Post", new { id = model.PostId });
                }

                // To Do send message to my email for example
                return this.RedirectToAction("HandleError", "Home");
            }
        }
    }
}
