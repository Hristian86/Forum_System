namespace ForumSys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ForumSys.Data.Common.Repositories;
    using ForumSys.Data.Models;

    public class VoteService : IVoteService
    {
        private readonly IRepository<Vote> voteRepository;

        public VoteService(IRepository<Vote> voteRepository)
        {
            this.voteRepository = voteRepository;
        }

        public int GetVotes(int postId)
        {
            var votes = this.voteRepository.All()
                .Where(x => x.PostId == postId).Sum(x => (int)x.Type);
            return votes;
        }

        public async Task VoteAsync(int postId, string userId, bool isUpVote)
        {
            var vote = this.voteRepository.All()
                .FirstOrDefault(x => x.PostId == postId && x.UserId == userId);
            if (vote != null)
            {
                vote.Type = isUpVote ? VoteType.UpVote : VoteType.DownVote;
            }
            else
            {
                vote = new Vote()
                {
                    PostId = postId,
                    UserId = userId,
                    Type = isUpVote ? VoteType.UpVote : VoteType.DownVote,
                };

                await this.voteRepository.AddAsync(vote);
            }

            await this.voteRepository.SaveChangesAsync();
        }
    }
}
