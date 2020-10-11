namespace ForumSys.Web.ViewModels.OutPutViewModels.Category
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CategoryViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public string ImageURL { get; set; }

        public string URL => $"/f/{this.Name.Replace(' ', '-')}";
    }
}
