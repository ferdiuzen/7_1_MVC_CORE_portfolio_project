using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Core_Proje.Controllers
{
    [Authorize]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //Partial view kullanarak sayfanın belirlenen alanını farklı bir sayfa gibi kullanarak bölüp,parçalayıp,yönetebiliriz...
        public PartialViewResult HeaderPartial() //PartialViewResult - HeaderPartial isimli partialın çalışltırılmasını sağlar (IActionResult gibi)
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return NavbarPartial();
        }

        public PartialViewResult SendMessage(Message p)
        {
            MessageManager messageManager = new MessageManager(new EfMessageDal());

            p.Date = Convert.ToDateTime(DateTime.Now.ToShortTimeString());
            p.Status = true;
            messageManager.TAdd(p);
            return PartialView();
        }

        public IActionResult IndexDeneme()
        {
            return View();
        }

    }
}
