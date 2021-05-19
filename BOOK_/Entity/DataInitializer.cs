using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BOOK_.Entity
{

    //test classı oluşturmamız amacı bida veritabanınagidio verş girmemizegerek klamadan işlemlerimizi yapabilşriz
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var kategoriler = new List<Category>
            {
                new Category(){Name="Macera",Description="Macera Kitapları"},
                new Category(){Name="Romantik",Description="Roman Kitapları"},
                new Category(){Name="Aksiyon-Gerilim",Description="Aksiyon-Gerilim Kitapları"},
                new Category(){Name="Edebiyat",Description="Edebiyat Kitapları"},
                new Category(){Name="İnanç",Description="İnanç Kitapları"},
                new Category(){Name="Kişisel Gelişim",Description="Kişisel Gelişim Kitapları"},
                new Category(){Name="Tarihi",Description="Tarihi Kitapları"}

            };

            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);
            }
            context.SaveChanges();
            //urunler içinde ekliyotuz veri
            var books = new List<Book>
            {
                new Book(){Name="Paristen Çiçeklerle",Description="Ünlü Glamour dergisinin başyazarlarından biri olarak tanınan Sarah Jio’nun popüler ve son kitabıdır. Paris’te iki farklı dönemde yaşayan iki ayrı kadının ilham verecek hikayelerini ele alıyor. Caroline 2009 yılında Paris’in sokaklarında gezinirken, Celine 1943 yılında aynı şehirde ailesiyle beraber yaşayan bir karakter. 1940’ların Paris’inde yaşayan Celine ve döneminde Nazi işgallerine tanık oluyoruz. Caroline ve döneminde gördüklerimiz ise daha çok karakterin içsel durumları. ‘’Bu kitap, benim Paris’e aşk mektubum’’ diyen yazar, eserini yazmak için uzun süre Paris’te konaklar. Biri toplumsal, diğeri daha bireysel sorunlar içinde mücadele eden iki güçlü kadının öyküsü, geçmişle günümüz arasında bir bağ kurma açısından da oldukça başarılı. Kitabın tanıtım bülteninden bir parça: ‘’1940’ların işgal altındaki Paris’inde Paris’in tüm çiçeklerini beklerken Paris’in tüm acılarını kendinde bulan bir kadın… 2000’lerde Işığın Şehri Paris’in nostaljik havasında ve aydınlığında kendi acılarıyla ve geçmişiyle yüzleşebilmek için başka bir kadının geçmişinin peşinde iz süren başka bir kadın…",Author="Sarah Jio",AuthorAbout="Sarah Jio 18 Şubat 1978 yılında doğmuştur. Çocukluğu Washington'da geçmiş olan Amerikalı yazar İletişim Fakültesi mezunudur. ... Sarah Jio'nun Yitik Kalpler İstasyonu isimli bir hikaye kitabı bulunmaktadır. Mart Menekşeleri, Yeşil Deniz Kabuğu, Böğürtlen Kışı isimli kitapları ülkemizde en beğenilen eserleridir.", Price=35, Stock=2000, IsApproved=true, CategoryId=2 ,Image="p_s.jpg"},
                 new Book(){Name="Aynı Yıldızın Altında",Description="New York Times Bestseller listesinde birinci sıraya kadar yükselen, yazarın en sevilen kitaplarından biri olan eser toplam 6 ödülün de sahibi. Roman ayrıca filme de uyarlanmış ve beyaz perde versiyonu da oldukça ilgi toplamıştı. Ne peki onun bu kadar sükse yapmasını sağlayan? Aynı Yıldızın Altında, 16 yaşındaki kanser hastası bir gencin duygu yüklü hikâyesini işliyor. Ölümcül ve geri dönüşü olmayan derecelere ulaşan hastalığı, münferit bir tıp mucizesiyle biraz daha uzasa da, bu sadece hazin sonu ertelemek oluyor. Genç kızın ölüm döşeğindeyken hayatına giren yeni biriyle yaşadığı narin ilişki romantik kitap sevdalıları için can alıcı olsa gerek. Tanıtımından bir alıntı: ‘’Aynı Yıldızın Altında konusu ile ilgi çeken bir eser olarak kitabın anlatıcısı Hazel Grace’in bir destek grubunda tanıştığı bedensel engelli Augustus Waters’la yaşadığı aşkı işlemektedir. Yazar kitabın adını Shakespeare’in Julius Caesar adlı eserindeki ‘Kusur (the fault), sevgili Brutus, yıldızlarda (stars) değil ama bizde’ repliğinden esinlenmiştir.",Author="John Green" ,AuthorAbout="24 Ağustos 1977 Indianapolis' te doğan John Green eşi ve iki çocuğuyla birlikte Indianapolis'te yaşamaktadır. Yazarlık kariyerine Alaska'nın Peşinde romanı ile hızlı bir giriş yaptı. ... 2012 yılında yayınladığı Aynı Yıldızın Altında romanı ile ise kariyerinin en büyük çıkışını yaptı." ,Price=30, Stock=2000, IsApproved=true, CategoryId=2 , Image="a_y.jpg"}

            };

            foreach (var book in books)
            {
                context.Books.Add(book);
            }
            context.SaveChanges();
            base.Seed(context);

        }
    }
}