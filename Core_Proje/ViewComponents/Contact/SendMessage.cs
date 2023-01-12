using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using System;

namespace Core_Proje.ViewComponents.Contact
{
    public class SendMessage:ViewComponent
    {
        MessageManager messageManager=new MessageManager(new EfMessageDal());

     
        public IViewComponentResult Invoke()
        {
            
            return View();


        }


        //public IViewComponentResult Invoke(Message p)
        //{
           
           
        //    return View();
        //}


    }
}
