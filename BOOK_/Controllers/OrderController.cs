using BOOK_.Entity;
using BOOK_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOOK_.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        //bu index metodu o anda verilen tüm siparişleri gostersin
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).OrderByDescending(i => i.OrderDate).ToList();

            return View(orders);
        }

        public ActionResult Details(int id)
        {
            var entity = db.Orders.Where(i => i.Id == id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    UserName = i.Username,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    OrderDate = i.OrderDate,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    Mahalle = i.Mahalle,
                    PostaKodu = i.PostaKodu,
                    Orderlines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        BookId = a.BookId,
                        BookName = a.Book.Name.Length > 50 ? a.Book.Name.Substring(0, 47) + "..." : a.Book.Name,
                        Image = a.Book.Image,
                        Adet = a.Adet,
                        Price = a.Price
                    }).ToList()
                }).FirstOrDefault();

            return View(entity);
        }

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);

            if (order != null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();

                TempData["message"] = "Bilgileriniz Kayıt Edildi";

                return RedirectToAction("Details", new { id = OrderId });
            }

            return RedirectToAction("Index");
        }
    }
}