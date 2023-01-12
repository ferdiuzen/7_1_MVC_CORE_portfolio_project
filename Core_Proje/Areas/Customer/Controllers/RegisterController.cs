using Core_Proje.Areas.Customer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Customer.Controllers
{
    //Eğer Area kullanıyorsak sayfanın controller bölümünde attribute routing yapılmalı ve hangi area kullanılıyorsa belirtilmelidir
    //Ayrıca area eklerken areanıın scaffoldingReadMe sayfasındaki vermiş olduğu Routing kodunu da startup içindeki routing alanına eklememiz gerekir

    [Area("Customer")]
    [Route("Customer/[Controller]/[Action]")]//Attribute Routing yapıyoruz ,Area kullandığımız için çalıştığımız sayfaların başına Customer ekledik
    public class RegisterController : Controller
    {//UserManager Class ı Identity paketi ile beraber gelmiş bir class

        private readonly UserManager<CustomerUser> _userManager;//Oluşturmuş olduğumuz CustomerUser class ını UserManager ile generik yaptık ve _userManager fieldına aşağıda CRUD işlemleri için kullanılmak üzere atadık

        
        public RegisterController(UserManager<CustomerUser> userManager)
        {
            _userManager = userManager;
            //    _userManager = userManager;//UserManager üzerinden dependency injection yaparak CRUD işlemlerini gerçekleştireceğiz
        }



   

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Index(UserRegisterViewModel p)
        {
            if (ModelState.IsValid)
            {

                CustomerUser w = new CustomerUser() //CustomerUser bizim ASPNETUSERS tablosundaki alanları taşıyan metodumuz ,buraya biz 3 alan daha eklemiştik aşağıda formdan gelen değerler bu metod içindeki alanlara atanır
                {
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Mail,
                    UserName = p.UserName,
                    ImageURL = p.ImageURL

                    //Forma yazdığımız değerler sırayla veritabanına kaydolmak üzere burada ilgili değişkenlere atanır
                    //Aspnetuser isimli tablodaki değerler buradan alınır
                };


                var result = await _userManager.CreateAsync(w, p.Password);//Bu kodu yeni bir kullanıcı oluşturmak için yazdık, yeni kullanıcı oluşması için de CreateAsync metodu kullanılır bu metod bir usera karşılık gelen w ve formdan gelen p.password u kullanır.
    //Alt kısımda;
    //Eğer geçerli ise yani kullanıcı oluşturulduysa login/index isimli sayfa açılır - kullanıcının giriş yapacağı sayfaya yönlendirilir
    //Identity mimarisine göre Identity kütüphanesindeki metotlar asenkrondur o nedenle asenkron olarak oluşturduk(create async....)
    //Asenkronik metod kullandığımız için IActionResult async Task<IActionResult> şeklinde oluşuruldu.

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "Login");//Kullanıcı kaydı başarılı ise Login/Index sayfasına yönlendirir
                }
                else
                {
                    foreach (var item in result.Errors)//eğer yeni kullanıcı oluşturulmadıysa hata mesajı ver
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);//eğer returne geldiyse form içinde eksik var demektir o zaman önceki yazılan değerler tekrar görünsün bu yüzden view içine p parametresini yazdık kullanıcı onaylanmadan önceki girdiği değerleri formda görür
        }
    }
}
