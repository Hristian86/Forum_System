namespace ForumSys.Web.ViewModels.OutPutViewModels.Posts
{
    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;

    public class CategoryDropDownViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
