﻿using BlogSystem.Web.ViewModels;

namespace BlogSystem.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using BlogSystem.Web.Infrastructure.Mapping;
    using BlogSystem.Data.UnitOfWork;
    using BlogSystem.Web.ViewModels.Home;
    using BlogSystem.Common;

    public class HomeController : BaseController
    {
        public HomeController(IBlogSystemData data) 
            : base(data)
        {
        }

        public ActionResult Index(int page = 1, int perPage = GlobalConstants.PostsPerPageDefaultValue)
        {
            int pagesCount = (int) Math.Ceiling(this.Data.Posts.All().Count() / (decimal) perPage);

            var posts = this.Data.Posts
                .All()
                .Where(p => !p.IsDeleted)
                .OrderByDescending(p => p.CreatedOn)
                .To<BlogPostConciseViewModel>()
                .Skip(perPage * (page - 1))
                .Take(perPage);

            var model = new IndexPageViewModel
            {
                Posts = posts.ToList(),
                CurrentPage = page,
                PagesCount = pagesCount
            };

            return this.View(model);
        }

       /* [ChildActionOnly]
        public ActionResult Menu()
        {
            var menu = this.Data.Pages
                .All()
                .To<MenuItemViewModel>()
                .ToList();

            return this.PartialView("_Menu", menu);
        }*/
    }
}