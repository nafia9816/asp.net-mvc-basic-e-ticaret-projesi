using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_.Models
{
    public class Login
    {
        [DisplayName("Kullanıcı Adınız")]
        [Required]
        public string UserName { get; set; }



        [DisplayName("şifre")]
        [Required]
        public string Password { get; set; }


        [DisplayName("Beni Hatırla")] //taryıcıda şireyi cookie seklinde saklayımı diye soruyoz

        public bool RememberMe { get; set; }
    }
}