﻿namespace BlogSystem.Web.Controllers
{
    using System.Web.Mvc;

    using BlogSystem.Services.Web.Caching;
    using BlogSystem.Services.Web.Mapping;

    using BlogSystem.Web.Infrastructure.Identity;
    using BlogSystem.Web.Infrastructure.Attributes;

    [PassSettingsToViewData]
    public abstract class BaseController : Controller
    {
        public ICurrentUser CurrentUser { get; set; }

        public IMappingService Mapper { get; set; }

        public ICacheService Cache { get; set; }
    }
}