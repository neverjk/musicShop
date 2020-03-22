using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _02._11_exam.Data.EFContext;
using _02._11_exam.Data.Models;
using _02._11_exam.Models;
using _02._11_exam.Services;
using _02._11_exam.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace _02._11_exam.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<DbUser> _userManager;
        private readonly SignInManager<DbUser> _signInManager;
        private readonly RoleManager<DbRole> _roleManager;
        private readonly EFDbContext _context;
        //private readonly IEmailSender _myEmailSender;


        public AccountController(UserManager<DbUser> userManager, SignInManager<DbUser> signInManager,
            RoleManager<DbRole> roleManager, EFDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            //_myEmailSender = myEmailSender;
        }

        [Authorize]
        [Route("Account/PersonalAccount")]
        public ViewResult PersonalAccount()
        {
            var info = HttpContext.Session.GetString("UserInfo");
            if (info != null)
            {
                var result = JsonConvert.DeserializeObject<UserInfo>(info);
                var id = result.UserId;
                var userObj = new PersonalAccountViewModel()
                {
                    GetUserInfo = result
                };
                return View(userObj);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpGet]
        [Route("Account/ChangePassword/{id}")]
        public IActionResult ChangePassword(string id)
        {
            return View();
        }

        [HttpPost]
        [Route("Account/ChangePassword/{id}")]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model, string id)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Id == id);
                if (user == null)
                {
                    ModelState.AddModelError("", "This User not register");
                    return View(model);
                }
                var hash_password = _userManager.PasswordHasher.HashPassword(user, model.Password);
                user.PasswordHash = hash_password;
                var result = await _userManager.UpdateAsync(user);

            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _context.Users
                .Include(x => x.UserProfile)
                .FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Incorrect email");
                return View(model);
            }
            var userName = user.UserProfile.FirstName;

            EmailService emailService = new EmailService();
            string url = "http://localhost:50560/Account/ChangePassword/" + user.Id;

            await emailService.SendEmailAsync(model.Email, "ForgotPassword",
                $" Dummie {userName}," +
                $" <br/>" +
                $" To change your password" +
                $" <br/>" +
                $" you should visit this link <a href='{url}'>press</a>");

            //string url = "http://localhost:51286/Account/ChangePassword/" + user.Id;

            //await _myEmailSender.SendEmailAsync(model.Email, "ForgotPassword",
            //    $" Dummie {userName}," +
            //        $" <br/>" +
            //        $" To change your password" +
            //        $" <br/>" +
            //        $" you should visit this link <a href='{url}'>press</a>"



            //    );

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = _context.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Incorrect login");
                return View(model);
            }

            var result = _signInManager.PasswordSignInAsync(user, model.Password, false, false).Result;
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Incorrect password");
                return View(model);
            }
            await _signInManager.SignInAsync(user, isPersistent: false);
            await Authenticate(model.Email);

            var userInfo = new UserInfo()
            {
                UserId = user.Id,
                Email = user.Email
            };
            HttpContext.Session.SetString("UserInfo", JsonConvert.SerializeObject(userInfo));

            return RedirectToAction("PersonalAccount", "Account");
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login", "Account");
        }


        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var roleName = "User";

            UserProfile userProfile = new UserProfile()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                RegistrationDate = DateTime.Now,
            };

            DbUser dbUser = new DbUser()
            {
                Email = model.Email,
                UserName = model.Email,
                UserProfile = userProfile,
            };

            var result = await _userManager.CreateAsync(dbUser, model.Password);
            result = _userManager.AddToRoleAsync(dbUser, roleName).Result;


            if (result.Succeeded)
            {
                // установка куки
                await _signInManager.SignInAsync(dbUser, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}