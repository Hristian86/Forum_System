namespace ForumSys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using ForumSys.Data.Common.Repositories;
    using ForumSys.Data.Models;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public UserService(IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> IpAddress(string ip, string email)
        {
            var user = this.userRepository.All()
                .FirstOrDefault(u => u.Email == email);

            if (user == null)
            {
                throw new ArgumentNullException("User does not exists");
            }

            var address = new IpAddress()
            {
                Ip = ip,
                UserId = user.Id,
                User = user,
            };

            if (user.IpAddresses.Contains(address))
            {
                return true;
            }

            user.IpAddresses.Add(address);
            this.userRepository.Update(user);
            await this.userRepository.SaveChangesAsync();
            return false;
        }
    }
}
