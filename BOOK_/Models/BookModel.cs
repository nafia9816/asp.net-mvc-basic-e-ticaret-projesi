using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOOK_.Models
{
    public class BookModel
    {
        //ihtiyacım olan değişkenlerl(hoedaki index actionunda kullanacagım selectte lazım olan değişkenleri) aldım
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public int Stock { get; set; }
        public string Author { get; set; }



        // eğerki her bir urunekategori vermek istemiyosa fk yı nullable tanımlarsa ? koyarsın olr nullable
        public int? CategoryId { get; set; }
    }
}