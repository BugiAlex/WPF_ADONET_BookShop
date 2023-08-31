using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class Order
    {
        public int Id { get; set; }
        public int Count_Book { get; set; }
        public virtual Book Book { get; set; }
        public virtual Account Account { get; set; }

        public string Name
        {
            get { return Book.Name; }
        }

        public int Year_edit
        {
            get { return Book.Year_edit; }
        }
        public int Pages
        {
            get { return Book.Pages; }
        }
        public string Language
        {
            get { return Book.Language.Name; }
        }
        public string Publishing
        {
            get { return Book.Publishing.Name; }
        }
        public string Author
        {
            get { return Book.Author.Name; }
        }
        public string Genre
        {
            get { return Book.Genre.Name; }
        }
        public string Stock
        {
            get { return Book.Stock.Name; }
        }
        public double Price
        {
            get
            {
                if (Book.Stock == null)
                {
                    return Book.Cost_price + Book.Cost_price * 0.3;
                }
                else
                {
                    return Book.Cost_price + Book.Cost_price * 0.3 - Book.Cost_price/100*Book.Stock.PercentageDiscount;
                }
            }
        }
        public double Cost_price
        {
            get { return Book.Cost_price; }
        }
    }
}
