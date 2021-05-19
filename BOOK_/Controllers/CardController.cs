using BOOK_.Entity;
using BOOK_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOOK_.Controllers
{
    public class CardController : Controller
    {
        private DataContext db = new DataContext(); //ekleyecegğim urune veritabanından ulasabilmekiçin bunu ekeldım buraya
        public ActionResult Index()
        {
            return View(GetCard());  // asagıdaki delete ve add metodunda returnda toaction dedık ve dogal olarak bi view olusturmam gerek ındex viewın
            // o view da zeten var oldugu içim o viewın actoınua metodumu gonderiyorum boyleceındex viewı kullanıcıy bir crd gondermıs oldu
        }

        public ActionResult AddToBasket(int Id) //details viewındaki hiidenfor dan geldi
        {
            var product = db.Books.Where(i => i.Id == Id).FirstOrDefault(); //kullanıcının eklemek ıstediği urun verıtabannda vrı kontrol ediyorum

            if (product != null) //sectiği urun verıtabanında varsa
            {
                GetCard().AddProduct(product, 1); //şimdilik 1 tane urun gondericem adet oalrak
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(int Id) //details viewındaki hiidenfor dan geldi
        {
            var product = db.Books.Where(i => i.Id == Id).FirstOrDefault(); //kullanıcının eklemek ıstediği urun verıtabannda vrı kontrol ediyorum

            if (product != null) //sectiği urun verıtabanında varsa
            {
                GetCard().DeleteProduct(product); //şimdilik 1 tane urun gondericem adet oalrak
            }
            return RedirectToAction("Index");
        }


        public Card GetCard()  //herkese ayru sepet olussun diye oluşturdum
        {
            Card card = (Card)Session["Card"];  //card turundebir sesion nesnesi urettim karttaki her değişiklikte yebı bit kart vermesın diye
            //siteyı her zıyaret edene birsesion ludturulur depo gibi
            if (card == null)  //eger  kart kopyası yoksa yanı iil kez sepete bisey eklenıyosa
            {
                card = new Card();
                Session["Card"] = card;
            }
            return card;  //card kopyası alıde varsa yenı olulturmuyorum ifi içine girmeden kartı kuulanıcıya gonderirirm
        }

        public PartialViewResult Summary() //özet
        {
            return PartialView(GetCard()); //getcard dab cardı alıcak sesiondaysa ordan alıcak yoksa bos halini alcak 0 gosterir
        }

        //bunu autorize yaparsan kullanıcı login olmadan checout goremez yanı alışveriş yapmak için uye olmak zounda olur

        [HttpGet]
        public ActionResult CheckOut()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ActionResult CheckOut(ShippingDetails entity)
        {
            var card = GetCard();

            if (card.CardLines.Count == 0)
            {
                ModelState.AddModelError("UrunYokError", "sepetinizde ürün bulunmamaktadır");
            }
            if (ModelState.IsValid)  //form eksizsizdolduruyduya bu if e gir
            {
                //SİPARİŞİNİZİ VERİTABANINA KAYIT ET SİLMEDEN ÖNCE
                SaveOrder(card,entity);


                card.Clear(); //ve cartı sıfırla
                return View("Completed"); //sabit bir arayuz verip sipariş tamalandı mesajı veririz

            }
            else
            {
                return View(entity);
            }


        }

        private void SaveOrder(Card card, ShippingDetails entity)
        {
            var order = new Order();
            order.OrderNumber = "A" + (new Random()).Next(111111, 999999).ToString(); //her sipariş için benzersiz bir numara uretip basına a eklicel 11111 ie 99999 arasında
            order.Total = card.Total();
            order.OrderDate = DateTime.Now; //o anki tarşh
            order.OrderState = EnumOrderState.Waiting; //siparişindurumu varsayılan olarak bekleyoryazdık.
            order.Username= User.Identity.Name; //sipariş bilgilri index viewında gelsin diye
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;

            //orer ın orderline değişkenleride asagıdaki giibi hazırlarıx
            order.OrderLines = new List<OrderLine>(); //orderın orderlines larını initiaize edelim ve dongude dolduralım bunu yapmadan asagıda ekleme yaparsa mbos oldugu için hata verir
            //meseal 5 urun varsa 5 orderline yanı her satır orderline dır

            foreach (var item in card.CardLines)
            {
                var orderline = new OrderLine();
                //orderline id si eklemye grek yok ustteki tanımlamayla geliyo aten
                orderline.Adet = item.Adet;
                orderline.Price = item.Adet * item.Book.Price;
                orderline.BookId = item.Book.Id;
                order.OrderLines.Add(orderline);

            }

            db.Orders.Add(order);
            db.SaveChanges();


        }
    }
}