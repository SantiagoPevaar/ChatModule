﻿using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace Test1.IdentityService.Controllers;

public class HomeController : AbpController
{
    public ActionResult Index()
    {
        return Redirect("/swagger");
    }
}
