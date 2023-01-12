using Core_Proje.Areas.Customer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("Customer/[Controller]/[Action]")]

    public class LoginController : Controller
    {

        private readonly SignInManager<CustomerUser> _signInManager;
        //Login Controller dan ctrl. ile generate constructure yoluyla dependency injection yapdık ve sing in Manager clasını field ımıza atadık.
        public LoginController(SignInManager<CustomerUser> signInManager)
        {
            _signInManager = signInManager;
        }

        //signinManager identity paketi ile beraber gelen login class ıdır. Entity değeri olarak CustomerUser dan gelen proporty leri veriyoruz  bunu da _signInManager field ine atıyoruz

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserLoginViewModel p)
        {
            if (ModelState.IsValid)
            {


                var result = await _signInManager.PasswordSignInAsync(p.UserName, p.Password, true, true);
                //signInManager klasında oluşturmuş olduğumuz asenkron metot kullanıcı adı, password,kullanıcı hatırlama durumu(çerez),ve lockout(Hatalı giriş sayısı) kontrolü ister

                if (result.Succeeded) { 
                return RedirectToAction("Index", "Default");

                }
                else
                {
                    ModelState.AddModelError("", "Hatalı kullanıcı adı ya da şifre");
                }
            }
            return View();
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }

    }
}
