using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_.Models
{
    public class Register
    {

        [DisplayName("Adınız")] //formda değişkenın orjinal adı yerine gorunecekler
        [Required] //bu lan bosgerçilemez
        public string Name { get; set; }

        [DisplayName("Soyadınız")]
        [Required]
        public string SurName { get; set; }

        [DisplayName("Kullanıcı Adınız")]
        [Required]
        public string UserName { get; set; }



        [DisplayName("e postanız")]
        [Required]
        [EmailAddress(ErrorMessage = "e posta adresinizi hatalı girdinniz")]
        public string Email { get; set; }

        [DisplayName("Parola")]
        [Required]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor")] //şifreleri karşılastırır
        public string RePassword { get; set; }
    }
}