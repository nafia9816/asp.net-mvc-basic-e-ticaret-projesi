using BOOK_.Entity;
using BOOK_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOOK_.Controllers
{
    public class HomeController : Controller
    {
        DataContext _context = new DataContext(); //kontrollerdan veritabanına ulaşabilmek için olusturdum
        public ActionResult Index()
        {

            //burayı basta acıklamada kosuk yapmak için yaptım bilgileri paketledık view a gondercez ama view bnde entity classını degğil productModel ı bekliyo
            var urunler = _context.Books
                .Where(i => i.IsApproved)
                .Select(i => new BookModel()
                {
                    Id = i.Id,
                    Name = i.Name.Length > 20 ? i.Name.Substring(0, 19) + "..." : i.Name,
                    Author=i.Author,
                    Price = i.Price,
                    Description = i.Description.Length > 70? i.Description.Substring(0, 69) + "..." : i.Description,

                    Stock = i.Stock,
                    Image = i.Image,
                    CategoryId = i.CategoryId

                }).ToList();  //buradan ilgili viewa liste gönderdiğim için view tarfında modeli listeformaunda (ienumarable)
            return View(urunler);

        }



        public ActionResult Details(int id)
        {
            return View(_context.Books.Where(i => i.Id == id).FirstOrDefault());
        }

        
            public ActionResult List(int? id)
            {
                //listeye tum satısdaki urunler gelsin
                var urunler = _context.Books
                   .Where(i => i.IsApproved)
                   .Select(i => new BookModel()
                   {
                       Id = i.Id,
                       Name = i.Name,
                       Description = i.Description.Length > 50 ? i.Description.Substring(0, 47) + "..." : i.Description,
                       Price = i.Price,
                       Stock = i.Stock,
                       Image = i.Image,
                       CategoryId = i.CategoryId


                   }).AsQueryable(); //burayı asqueryble işaretledimli baska filtrelemelerde yaapbileyim 

                //egerki home/list değilse burası calışıcak yum urunler gelcek
                if (id != null)
                {
                    urunler = urunler.Where(i => i.CategoryId == id);
                }

                return View(urunler.ToList());
            }

        //KATEGORİ PARCALİ VİEW İÇİN OLUŞTURDUM viewıda partial view olcak
        public PartialViewResult GetCategories()
        {
            return PartialView(_context.Categories.ToList());   //context üzerinden bütün kategorileri partial view a yolladık
        }
    }
    }
