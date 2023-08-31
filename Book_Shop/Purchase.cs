using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class Purchase
    {
        public int Id { get; set; }
        public int Count_Book { get; set; }
        public DateTime DateTime { get; set; }
        public virtual Book Book { get; set; }
        public virtual Account Account { get; set; }
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
        
       
    }
}
