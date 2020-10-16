namespace ForumSys.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSys.Data.Models;
    using ForumSys.Services.Data;
    using ForumSys.Web.ViewModels.OutPutViewModels.Votes;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class VotesController : ControllerBase
    {
        private readonly IVoteService voteService;
        private readonly UserManager<ApplicationUser> userManager;

        public VotesController(
            IVoteService voteService,
            UserManager<ApplicationUser> userManager)
        {
            this.voteService = voteService;
            this.userManager = userManager;
        }

        public ActionResult Get(int postId)
        {
            var votes = this.voteService.GetVotes(postId);

            var responceModel = new ResponceViewModel()
            {
                VotesCount = votes,
            };

            return this.Ok(responceModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Post(InputVoteModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("Index", "Category");
            }

            try
            {
                var userId = await this.userManager.GetUserAsync(this.User);

                await this.voteService.VoteAsync(model.PostId, userId.Id, model.IsUpVote);

                var votes = this.voteService.GetVotes(model.PostId);

                var responceModel = new ResponceViewModel()
                {
                    VotesCount = votes,
                };

                return this.Ok(responceModel);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                // To Do send message to my email for example
                return this.RedirectToAction("Home", "Error");
            }
        }
    }
}
