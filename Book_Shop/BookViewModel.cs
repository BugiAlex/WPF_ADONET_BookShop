using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class BookViewModel : ViewModelBase
    {
        private Book book;
        public BookViewModel(Book book_)
        {
            book = book_;
        }
        public int Id
        {
            get { return book.Id; }
            set
            {
                book.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get { return book.Name; }
            set
            {
                book.Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int Year_Edit
        {
            get { return book.Year_edit; }
            set
            {
                book.Year_edit = value;
                OnPropertyChanged(nameof(Year_Edit));
            }
        }
        public double Cost_Piece
        {
            get { return book.Cost_price; }
            set
            {
                book.Cost_price = value;
                OnPropertyChanged(nameof(Cost_Piece));
            }
        }

        public double Price
        {
            get {
                if (book.Stock == null)
                {
                    return book.Cost_price + book.Cost_price * 0.3;
                }
                else
                {
                    return book.Cost_price + book.Cost_price * 0.3 - book.Cost_price * book.Stock.PercentageDiscount / 100;
                }
            
            }
        
        }
        public int Pages
        {
            get { return book.Pages; }
            set
            {
                book.Pages = value;
                OnPropertyChanged(nameof(Pages));
            }
        }

        public int CountBooks
        {
            get {
                using (var db = new ContextDB())
                {
                    
                    int idbook = book.Id;
                    var queryAccount = (from b in db.BooksAvailables
                                        where b.Book.Id == book.Id
                                        select b).Single();
                    return queryAccount.Count_Book;
                }
            }      
        }
        
        public string Edit
        {
            get { return book.Publishing.Name; }
            set
            {
                book.Publishing.Name = value;
                OnPropertyChanged(nameof(Edit));
            }        
        }
        public string Author
        {
            get { return book.Author.Name; }
            set
            {
                book.Author.Name = value;
                OnPropertyChanged(nameof(Author));
            }
        }
       
        public string Genre
        {
            get { return book.Genre.Name; }
            set
            {
                book.Genre.Name = value;
                OnPropertyChanged(nameof(Genre));
            }
        }
        public string Stock
        {
            get 
            { if (book.Stock == null)
                { 
                    return null;
                }
                return book.Stock.Name;
            }
            set
            {
                book.Stock.Name = value;
                OnPropertyChanged(nameof(Stock));
            }
        }
        public string Language
        {
            get { return book.Language.Name; }
            set
            {
                book.Language.Name = value;
                OnPropertyChanged(nameof(Language));
            }
        }
        
    }
}
