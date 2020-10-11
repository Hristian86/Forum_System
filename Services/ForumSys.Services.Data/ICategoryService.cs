namespace ForumSys.Services.Data
{
    using System.Collections.Generic;
    using System.Text;

    public interface ICategoryService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        T GetByName<T>(string name);
    }
}
