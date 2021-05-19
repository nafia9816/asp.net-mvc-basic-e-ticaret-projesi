using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOOK_.Entity
{
    public class Order //siparişin temel bilgileri burda
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }

        public double Total { get; set; }

        public DateTime OrderDate { get; set; }

        //siparişin durumun
        public EnumOrderState OrderState { get; set; }


        //sopingdetay modelindeki kullanıcı bilgikirib de butara kaydederiz 
        public String Username { get; set; }
        public string AdresBasligi { get; set; }
        public string Adres { get; set; } //genelde adre 1 adres2 olaral 2 tane oluşturulur

        public string Sehir { get; set; }

        public string Semt { get; set; }

        public string Mahalle { get; set; }
        public string PostaKodu { get; set; }




        public virtual List<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine //şiparişteki her elaman için işlemleride burdada yazıcsm
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } //lazy loading kavramını etkin hale getşrmek için virtual dedım

        public double Price { get; set; } //bunu eklememmızın amacı urunun o zamanki fiyatınıda kayıt altında tutmaktır belkş 1 ay sonra indrim olur gibi :)
        public int Adet { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
    }
}
