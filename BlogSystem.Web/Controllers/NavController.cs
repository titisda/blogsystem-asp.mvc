﻿namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using Infrastructure.Mapping;
    using ViewModels.Nav;

    public class NavController : BaseController
    {
        public NavController(IBlogSystemData data) 
            : base(data)
        {
        }

        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            var menu = this.Data.Pages
                .All()
                .To<MenuItemViewModel>()
                .ToList();

            return this.PartialView(menu);
        }
    }
}