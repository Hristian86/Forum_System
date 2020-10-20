namespace ForumSys.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserService
    {
        Task<bool> IpAddress(string ip, string email);
    }
}
