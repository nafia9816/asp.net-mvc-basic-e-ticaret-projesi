using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_.Entity
{
    public class Category
    {
        public int Id { get; set; }

        [DisplayName("Kategori adı")]
        //bi tane kural yazdım bu kurallara data annotıonus denir
        [StringLength(maximumLength: 20, ErrorMessage = "fazla karakter girdiniz")]
        public string Name { get; set; }

        [DisplayName("Açıklama")] //view da html helper metodu bunu karsılarsa ekrana değişkenın orjinal adı yerine bunu yazar
        public string Description { get; set; }

        public List<Book> Books { get; set; } //tablolar arası ilişki
    }
}