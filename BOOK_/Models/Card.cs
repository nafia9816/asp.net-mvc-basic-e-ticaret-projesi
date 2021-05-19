using BOOK_.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOOK_.Models
{
    //sepetin tamamını ise bu metod temsil ediyor
    public class Card
    {
        //liste oluşturdum
        private List<CardLine> _cardlines = new List<CardLine>();

        //listeyi dısarıya gondermek için bir public metodunu oluşturdum
        public List<CardLine> CardLines
        {
            get { return _cardlines; }
        }

        //sepete bir eleman yanı bir satır ekliyorum
        public void AddProduct(Book product, int adet)
        {
            //ilk önce bu urunu kontrol ediyom boyle bir urun varmı
            var line = _cardlines.FirstOrDefault(i => i.Book.Id == product.Id);

            //eger urun yoksa sepette o ürünü ekle egerki varsa adetitni artır
            if (line == null) //urun yokmus
            {
                _cardlines.Add(new CardLine() { Book = product, Adet = adet });
            }
            else
            {
                line.Adet += adet;
            }
        }

        public void DeleteProduct(Book product)
        {
            //silmekistediğim elamanı yolluyprum onu siliyo
            _cardlines.RemoveAll(i => i.Book.Id == product.Id);
        }

        //urunlerin toplam fiyatını hesaplıyoruz
        public double Total()
        {
            return _cardlines.Sum(i => i.Book.Price * i.Adet);
        }

        //butun elemanlarını silmek için olusturdum
        public void Clear() //sepeti boşalt
        {
            _cardlines.Clear();
        }

    }

    //herbir ürünü temsil eden bir object cardline dır
    public class CardLine
    {
        //alesveriş sepetinni bir satrını temsil eden bir obje bu
        public Book Book { get; set; }
        public int Adet { get; set; }  //sepett kac urun var
    }
}