using System.Threading.Tasks;
using Edu.webui.EmailService;
using Edu.webui.Extensions;
using Edu.webui.Identity;
using Edu.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Edu.webui.Controllers
{
    public class PanelController:Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private IEmailSender _emailSender;
        public PanelController(UserManager<User> userManager, SignInManager<User> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Login(string returnUrl=null){
            return View(new LoginModel(){ReturnUrl=returnUrl});
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);
            if(user==null)
            {
                ModelState.AddModelError("", "User not found.");
                return View(model);
            }
            if(!await _userManager.IsEmailConfirmedAsync(user))
            {
                ModelState.AddModelError("", "Need to confirm email");
                return View(model);
            }
            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if(result.Succeeded)
            {
                System.Console.WriteLine(model.ReturnUrl);
                return Redirect(model.ReturnUrl??"~/");
            }
            ModelState.AddModelError("","Login Failed. Password is wrong.");
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Panel");
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if(userId == null || token == null)
            {
                TempData.Put("message", new AlertMessage(){Message="Token is invalid" ,AlertType="danger"});
                return RedirectToAction("Login", "Panel");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user==null)
            {
                TempData.Put("message", new AlertMessage(){Message="Token is invalid" ,AlertType="danger"});
                return RedirectToAction("Login", "Panel");
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if(result.Succeeded)
            {
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                var url = Url.Action("PasswordReset", "Panel", new{userId=user.Id, token=code});
                TempData.Put("message", new AlertMessage(){Message="You Can set Password." ,AlertType="success"});
                return Redirect(url);
            }
            TempData.Put("message", new AlertMessage(){Message="Token is invalid" ,AlertType="danger"});
            return RedirectToAction("Login", "Panel");
        }
        [HttpPost]
        public async Task<IActionResult> PasswordForgot(string Email)
        {
            if(string.IsNullOrEmpty(Email))
            {
                TempData.Put("message", new AlertMessage(){Message="Mail is Invalid." ,AlertType="danger"});
                return View();
            }
            var user = await _userManager.FindByEmailAsync(Email);
            if(user==null)
            {
                TempData.Put("message", new AlertMessage(){Message="Mail is Invalid." ,AlertType="danger"});
                return View();
            }
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("PasswordReset", "Panel", new{userId=user.Id, token=code});
            await _emailSender.SendEmailAsync(Email,"Eduvizyon Panel Parola Sıfırlama", $"Eduvizyon Şifrenizi Değiştirmek için <a href='https://localhost:5001{url}'>Tıklayınız.</a>");
            TempData.Put("message", new AlertMessage(){Message="Yeni Şifre için mail gönderildi." ,AlertType="success"});
            return RedirectToAction("Login", "Panel");
        }
        public async Task<IActionResult> PasswordReset(string UserId, string Token)
        {
            if(UserId == null || Token == null)
            {
                return RedirectToAction("Login", "Panel");
            }
            var user = await _userManager.FindByIdAsync(UserId);
            if(user == null)
            {
                return RedirectToAction("Login", "Panel");
            }
            return View(new PasswordResetModel(){userId=UserId, token=Token});
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(PasswordResetModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByIdAsync(model.userId);
            if(user == null)
            {
                return RedirectToAction("Login", "Panel");
            }
            var result = await _userManager.ResetPasswordAsync(user,model.token,model.password);
            if(result.Succeeded)
            {
                TempData.Put("message", new AlertMessage(){Message="Şifreniz Değiştirildi! Giriş Yapabilirsiniz." ,AlertType="success"});
                return Redirect("/panel/login");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("",error.Description);
            }
            return View(model);
        }
    }
}