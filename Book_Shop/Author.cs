using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }      
        public virtual ICollection<Book> Books { get; set; }
    }
}
