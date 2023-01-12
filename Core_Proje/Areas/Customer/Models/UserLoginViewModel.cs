﻿using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Customer.Models
{
    public class UserLoginViewModel
    {
        [Display(Name ="Kullanıcı Adı")]
        [Required(ErrorMessage ="Lütfen Kullanıcı Adını Giriniz")]
        public string UserName { get; set; }

        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Lütfen Şifreyi Giriniz")]
        public string Password { get; set; }    



    }
}

