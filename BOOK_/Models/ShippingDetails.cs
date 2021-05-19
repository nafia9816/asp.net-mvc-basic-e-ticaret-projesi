using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_.Models
{
    public class ShippingDetails
    {

            public String Username { get; set; }  //kullanıcı login olmuşşa direkt alıcam olmamıssa burdan alıcam

            [Required(ErrorMessage = "lutfen adres tanımını giriniz. İş/Ev")] //iş ev
            public string AdresBasligi { get; set; }

            [Required(ErrorMessage = "lutfen adresi giriniz")]
            public string Adres { get; set; } //genelde adre 1 adres2 olaral 2 tane oluşturulur

            [Required(ErrorMessage = "lutfen şehiri giriniz")]
            public string Sehir { get; set; }

            [Required(ErrorMessage = "lutfen semti giriniz")]
            public string Semt { get; set; }

            [Required(ErrorMessage = "lutfen mahalleyi giriniz")]
            public string Mahalle { get; set; }
            public string PostaKodu { get; set; }

        
    }
}