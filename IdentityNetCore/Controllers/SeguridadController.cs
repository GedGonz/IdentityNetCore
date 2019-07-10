using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace IdentityNetCore.Controllers
{
    public class SeguridadController : Controller
    {
        private readonly SignInManager<Usuario> signInManager;
        private readonly UserManager<Usuario> userManager;

        public SeguridadController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UsuarioModel usuario)
        {

            var user = new Usuario
            {
                UserName = usuario.UserName,
                Email = "gedgonz7@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                LockoutEnabled = false,
                AccessFailedCount = 0
            };
            //var result0 = await userManager.FindByNameAsync(user.UserName);
            if (!ModelState.IsValid)
                return View(usuario);

            SignInResult result = await signInManager.PasswordSignInAsync(usuario.UserName, usuario.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login Failed");
                return View(usuario);
            }

        }
        [HttpGet]
        public ActionResult NuevoUsuario()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> NuevoUsuario(UsuarioModel usuario)
        {
           
           var user = new Usuario
           {
               UserName = usuario.UserName,
               Email = "gedgonz7@gmail.com",
               EmailConfirmed = true,
               PhoneNumberConfirmed=true,
               LockoutEnabled=false,
               AccessFailedCount=0
           };

           var result = await userManager.CreateAsync(user, usuario.Password);
           if (result.Succeeded)
           {
               return RedirectToAction("Index", "Home");
           }
           else
           {
               ModelState.AddModelError(string.Empty, "Login Failed");
               return View(usuario);
           }
           
        }
    }
}