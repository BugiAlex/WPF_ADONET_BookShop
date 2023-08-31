using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PercentageDiscount { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
