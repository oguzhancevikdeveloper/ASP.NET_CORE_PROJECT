﻿using ASP.NET_CORE_PROJECT.Models;
using DataAccessLayer;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ASP.NET_CORE_PROJECT.Controllers
{
  [AllowAnonymous]
  public class LoginController : Controller
  {
    private readonly SignInManager<AppUser> _signInManager;

    public LoginController(SignInManager<AppUser> signInManager)
    {
      _signInManager = signInManager;
    }

    public IActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public async Task<IActionResult> Index(UserSignInViewModel p)
    {
      if (ModelState.IsValid)
      {
        var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);

        if (result.Succeeded)
        {
          return RedirectToAction("Index", "Dashboard");
        }
        else
        {
          return RedirectToAction("Index", "Login");
        }
      }
      return View();
    }

  }
}
