using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;
using SkillsTest.Domain.Models;
using SkillsTest.Web.ViewModels.Account;
using SkillsTest.Domain.Services;
using SkillsTest.Web.Infrastructure;
using Recaptcha.Web;
using Recaptcha.Web.Mvc;
using System.Threading.Tasks;

namespace SkillsTest.Web.Controllers
{
    public class AccountController : BaseController
    {
        #region #region CTOR // DTOR

        protected IUserService _userSertvice;

        public AccountController(IUserService userSertvice)
        {
            this._userSertvice = userSertvice;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            this._userSertvice.Dispose();
        }

        #endregion

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel vm, string returnUrl)
        {
            #region Recaptcha
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return View(vm);
            }
            RecaptchaVerificationResult recaptchaResult = await recaptchaHelper.VerifyRecaptchaResponseTaskAsync();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
            }
            #endregion

            if (!ModelState.IsValid)
                return View(vm);


            var user = this._userSertvice.Verify(vm.EmailAddress, vm.Password);

            if (user != null)
            {
                this.SignIn(user, true);
                return RedirectToLocal(returnUrl).Success(string.Format("Welcome back {0}!", user.Fullname));
            }

            ModelState.AddModelError("", "Invalid email or password.");
            return View(vm);
        }

        [HttpGet, AllowAnonymous]
        public ActionResult Logoff(string returnUrl)
        {
            AuthenticationManager.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home").Success("You have successfully logged out!");
        }
        
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePasswordViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = this._userSertvice.Verify(this.GetUserId().Value, vm.OldPassword);

                if (user == null)
                {
                    ModelState.AddModelError("OldPassword", "Old password is invalid.");
                    return View(vm);
                }

                this._userSertvice.UpdatePassword(this.GetUserId().Value, vm.Password);

                return RedirectToAction("Index", "Home").Success("Password successfully updated.");
            }

            return View(vm);
        }
        
        [HttpGet, AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel vm)
        {
            #region Recaptcha
            RecaptchaVerificationHelper recaptchaHelper = this.GetRecaptchaVerificationHelper();
            if (String.IsNullOrEmpty(recaptchaHelper.Response))
            {
                ModelState.AddModelError("", "Captcha answer cannot be empty.");
                return View(vm);
            }
            RecaptchaVerificationResult recaptchaResult = await recaptchaHelper.VerifyRecaptchaResponseTaskAsync();
            if (recaptchaResult != RecaptchaVerificationResult.Success)
            {
                ModelState.AddModelError("", "Incorrect captcha answer.");
            }
            #endregion

            if (!ModelState.IsValid)
                return View(vm);

            if(this._userSertvice.EmailExist(vm.EmailAddress))
            {
                ModelState.AddModelError("EmailAddress", "Email already in use.");
                return View(vm);
            }
           
            var user = new User()
            {
                Firstname = vm.Firstname,
                Lastname = vm.Lastname,
                EmailAddress = vm.EmailAddress,
                ClearTextPassword = vm.Password
            };

            this._userSertvice.Add(user);

            return RedirectToAction("Login")
                .Success("Account successfully created.");
        }
        
        #region Helpers

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void SignIn(User user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);

            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, string.Format("{0} {1}", user.Firstname, user.Lastname)),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var identity = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        [AllowAnonymous]
        protected ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}