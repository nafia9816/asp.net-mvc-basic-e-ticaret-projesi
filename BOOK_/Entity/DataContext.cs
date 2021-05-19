using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BOOK_.Entity
{
   
        public class DataContext : DbContext
        {
            // veritabanımız yazdıgımız connection stringde belirrtiğimiz yolda olşşsun diye yapıcı metodumu ekledım
            public DataContext() : base("Connection") //connection string de verdiğimiz isim
            {
               // Database.SetInitializer(new DataInitializer()); //globalasax ın içine yazdık
            }

            public DbSet<Book> Books { get; set; }
            public DbSet<Category> Categories { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<OrderLine> OrderLines { get; set; }

    }
    
}