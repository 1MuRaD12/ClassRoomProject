using Bootstrap.DAL;
using Bootstrap.Models;
using Bootstrap.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bootstrap.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]

        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser
            {
                UserName = registerVM.UserName,
                LastName = registerVM.LastName,
                Email = registerVM.EmailAddress,
                FirstName = registerVM.FirstName
            };

            IdentityResult result = await userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Show()
        {
            return Content(User.Identity.IsAuthenticated.ToString());
        }
    }
}
