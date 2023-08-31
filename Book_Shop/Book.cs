using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year_edit { get; set; }
        public double Cost_price { get; set; }
        public int Pages { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Publishing Publishing { get; set; }
        public virtual Language Language { get; set; }
        public virtual Author Author { get; set; }
        public virtual Genre Genre { get; set; }
       
    }
}
