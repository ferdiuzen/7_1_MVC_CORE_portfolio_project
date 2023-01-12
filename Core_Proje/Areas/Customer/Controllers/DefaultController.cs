using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]//Sistem Authantike olması için bunu yapıyoruz yani kullnıcı login olmadan bu sayfa açılmayacak
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
