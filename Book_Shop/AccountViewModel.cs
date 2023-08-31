using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Shop
{
    class AccountViewModel : ViewModelBase
    {
        private Account account;

        public AccountViewModel(Account account_)
        {
            account = account_;
        }

        public int Id
        {
            get { return account.Id; }
            set
            {
                account.Id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        public string Lastname
        {
            get { return account.LastName; }
            set
            {
                account.LastName = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public string Firstname
        {
            get { return account.FirstName; }
            set
            {
                account.FirstName = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }

        public string Login
        {
            get { return account.Login; }
            set
            {
                account.Login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string Password
        {
            get { return account.Password; }
            set
            {
                account.Password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string Position
        {
            get { return account.Position.Name; }
           
        }

        public int CountBookInOrder
        {
            get {
                using (var db = new ContextDB())
                {

                    int idaccount = account.Id;
                    var queryAccount = (from b in db.Orders
                                        where b.Account.Id == idaccount
                                        select b.Count_Book).Sum();
                    return queryAccount;
                }

                }

        }
        public double PriceBooksInOrder
        {
            get
            {
                double priceBIO = 0;
                foreach (Order i in account.Orders)
                {
                    if (i.Book.Stock == null)
                    {
                        priceBIO += (i.Book.Cost_price + i.Book.Cost_price * 0.3) * i.Count_Book;
                    }
                    else
                    {
                        priceBIO += (i.Book.Cost_price + i.Book.Cost_price * 0.3 - i.Book.Cost_price/100* i.Book.Stock.PercentageDiscount) * i.Count_Book;
                    }
                    
                }
                return priceBIO;
               
            }

        }
        
    }
}
