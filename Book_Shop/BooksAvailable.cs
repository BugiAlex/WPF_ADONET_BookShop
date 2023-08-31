using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class BooksAvailable
    {
        public int Id { get; set; }
        public int Count_Book { get; set; }
        public virtual Book Book { get; set; }
    }
}
