namespace ForumSys.Web.ViewModels.OutPutViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using ForumSys.Data.Models;
    using ForumSys.Services.Mapping;

    public class GetByNameViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public IEnumerable<PostInCategoryViewModel> Posts { get; set; }
    }
}
