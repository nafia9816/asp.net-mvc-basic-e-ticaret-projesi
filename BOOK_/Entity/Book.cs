using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BOOK_.Entity
{
    public class Book
    {
        public int Id { get; set; }

        [DisplayName("Kitap Adı")]
        public string Name { get; set; }

        [DisplayName("Kitap Açıklama")]  //özet
        public string Description { get; set; }

        [DisplayName("Kitap Fiyatı")]
        public double Price { get; set; }

        [DisplayName("Kitap Yazarı")]
        public string Author { get; set; }

        [DisplayName("Yazar Hakkında")]
        public string AuthorAbout { get; set; }
       
        public string Image { get; set; }
        public int Stock { get; set; }

        [DisplayName("Onay Durumu")]
        public bool IsApproved { get; set; } // urun satısdamı
        

        // eğerki her bir urune kategori vermek istemiyosak fk yı nullable tanımlarız. bunu dA ? koyarak  nullable yaparız
        public int? CategoryId { get; set; } //bu yabancı anahtar adını diğer classın adıId sekline koyarız buyuk kolaylık :)
        public Category Category { get; set; } //tablolar arası ilşki
    }
}