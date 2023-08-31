using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Text.RegularExpressions;
using Microsoft.Win32;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Controls;




namespace Book_Shop
{
    class MainViewModel : ViewModelBase
    {       
        public ObservableCollection<AccountViewModel> AccountsList { get; set; }
        public ObservableCollection<BookViewModel> BooksList { get; set; }
        public ObservableCollection<Stock> StocksList { get; set; }
        public ObservableCollection<Publishing> PublishingsList { get; set; }
        public ObservableCollection<Language> LanguagesList { get; set; }
        public ObservableCollection<Author> AuthorsList { get; set; }
        public ObservableCollection<Genre> GenresList { get; set; }
        public ObservableCollection<Position> PositionsList { get; set; }
        public ObservableCollection<Order> OrdersList { get; set; }
        public ObservableCollection<Purchase> PurchasesList { get; set; }
        public ObservableCollection<BooksAvailable> BooksAvailablesList { get; set; }
        public ObservableCollection<AccountViewModel> BuyerList { get; set; }
        public ObservableCollection<Order> BooksInOrder { get; set; }
        public ObservableCollection<Order> AccountBookInOrder { get; set; }
        public ObservableCollection<string> ParamPopularSearch { get; set; }
        public ObservableCollection<string> TimePopularSearch { get; set; }

        ContextDB db = null;
        public MainViewModel()
        {           
            AccountsList = new ObservableCollection<AccountViewModel>();
            BooksList = new ObservableCollection<BookViewModel>();
            StocksList = new ObservableCollection<Stock>();
            PublishingsList = new ObservableCollection<Publishing>();
            LanguagesList = new ObservableCollection<Language>();
            AuthorsList = new ObservableCollection<Author>();           
            GenresList = new ObservableCollection<Genre>();
            PositionsList = new ObservableCollection<Position>();
            OrdersList = new ObservableCollection<Order>();
            PurchasesList = new ObservableCollection<Purchase>();
            BooksAvailablesList = new ObservableCollection<BooksAvailable>();
            BooksInOrder = new ObservableCollection<Order>();
            BuyerList = new ObservableCollection<AccountViewModel>();
            AccountBookInOrder = new ObservableCollection<Order>();
            ParamPopularSearch = new ObservableCollection<string>();
            TimePopularSearch = new ObservableCollection<string>();

            db = new ContextDB();
            LoadPositions();
            LoadAccounts();
            LoadBooks();
            LoadAuthors();
            LoadLanguages();
            LoadPublishings();
            LoadStocks();
            LoadGenres();
            LoadOrders();
            LoadPurchases();
            LoadBooksAvailable();
            LoadPopularParam();           
        }

        private void LoadAccounts()
        {
            AccountsList.Clear();
            var query = (from c in db.Accounts.Include("Position") select c).ToList();
            foreach (var i in query)
            {
                Account tmp = new Account
                {
                    Id = i.Id,
                    Login = i.Login,
                    Password = i.Password,
                    LastName = i.LastName,
                    FirstName = i.FirstName,
                    Position = i.Position


                };
                AccountViewModel tmpA = new AccountViewModel(tmp);
                AccountsList.Add(tmpA);
            }
        }
        private void LoadPositions()
        {
            PositionsList.Clear();

            var query = (from c in db.Positions select c).ToList();


            foreach (var i in query)
            {
                Position tmp = new Position
                {
                    Id = i.Id,
                    Name = i.Name,                    
                };

                PositionsList.Add(tmp);
            }
        }
        private void LoadBooks()
        {
            BooksList.Clear();
            var query = (from c in db.Books.Include("Language").Include("Publishing").Include("Stock").Include("Author").Include("Genre") select c).ToList();
            foreach (var i in query)
            {
                Book tmp = new Book
                {
                    Id = i.Id,
                    Name = i.Name,
                    Year_edit = i.Year_edit,
                    Cost_price = i.Cost_price,
                    Pages = i.Pages,
                    Stock = i.Stock,
                    Publishing = i.Publishing,
                    Language = i.Language,
                    Author = i.Author,
                    Genre = i.Genre

                };
                BookViewModel tmpA = new BookViewModel(tmp);
                BooksList.Add(tmpA);
            }
        }
        private void LoadStocks()
        {
            StocksList.Clear();
           
            var query = (from c in db.Stocks select c).ToList();


            foreach (var i in query)
            {
                Stock tmp = new Stock
                {
                    Id = i.Id,
                    Name = i.Name,
                    PercentageDiscount = i.PercentageDiscount
                };
                
                StocksList.Add(tmp);
            }
        }
        private void LoadPublishings()
        {
            PublishingsList.Clear();
            var query = (from c in db.Publishings select c).ToList();
            foreach (var i in query)
            {
                Publishing tmp = new Publishing
                {
                    Id = i.Id,
                    Name = i.Name
                   
                };

                PublishingsList.Add(tmp);
            }
        }
        private void LoadLanguages()
        {
            LanguagesList.Clear();
            var query = (from c in db.Languages select c).ToList();
            foreach (var i in query)
            {
                Language tmp = new Language
                {
                    Id = i.Id,
                    Name = i.Name

                };

               LanguagesList.Add(tmp);
            }
        }
        private void LoadAuthors()
        {
            AuthorsList.Clear();
            var query = (from c in db.Authors select c).ToList();
            foreach (var i in query)
            {
                Author tmp = new Author
                {
                    Id = i.Id,
                    Name = i.Name,
                };                
                AuthorsList.Add(tmp);               
            }
        }
        private void LoadGenres()
        {
            GenresList.Clear();
            var query = (from c in db.Genres select c).ToList();
            foreach (var i in query)
            {
                Genre tmp = new Genre
                {
                    Id = i.Id,
                   Name = i.Name

                };

                GenresList.Add(tmp);
            }
        }
        private void LoadOrders()
        {
            OrdersList.Clear();
            var query = (from c in db.Orders.Include("Book").Include("Account")
                         select c).ToList();
            foreach (var i in query)
            {
                Order tmp = new Order
                {
                    Id = i.Id,
                    Account = i.Account,
                    Book = i.Book,
                    Count_Book = i.Count_Book
                };

                OrdersList.Add(tmp);
            }
        }
        private void LoadPurchases()
        {
            PurchasesList.Clear();
            var query = (from c in db.Purchases.Include("Book").Include("Account")
                         select c).ToList();
            foreach (var i in query)
            {
                Purchase tmp = new Purchase
                {
                    Id = i.Id,
                    Account = i.Account,
                    Book = i.Book,
                    Count_Book = i.Count_Book,
                    DateTime = i.DateTime
                    
                };
                PurchasesList.Add(tmp);
            }
        }
        private void LoadBooksAvailable()
        {
            BooksAvailablesList.Clear();
            var query = (from c in db.BooksAvailables.Include("Book") select c).ToList();
            foreach (var i in query)
            {
                BooksAvailable tmp = new BooksAvailable
                {
                    Id = i.Id,
                   Book = i.Book,
                   Count_Book = i.Count_Book
                };

                BooksAvailablesList.Add(tmp);
            }
        }
        private void LoadBuyersList()
        {
            BuyerList.Clear();
            var quyryAccountBuyer = (from c in db.Accounts.Include("Position")  
                                     where c.Position.Name == "Buyer"
                                     select c).ToList();

            foreach (var i in quyryAccountBuyer)
            {
               Account tmp = new Account
                {   
                   FirstName = i.FirstName,
                   LastName = i.LastName,
                   Position = i.Position,
                   Id = i.Id,
                   Login = i.Login,
                   Password = i.Password,
                   Orders = i.Orders,
                   
                };
                AccountViewModel tmpV = new AccountViewModel(tmp);
                BuyerList.Add(tmpV);
            }
        }
        private void LoadBookInOrder()
        {
            BooksInOrder.Clear();
            int idAcoount = BuyerList[index_listview_position_buyer_sellerWin].Id;
           
                var queryAccount = (from b in db.Accounts.Include("Orders")
                                    where b.Id == idAcoount
                                    select b).Single();

            if (queryAccount.Orders.Count != 0)
            {
                foreach (Order i in queryAccount.Orders)
                {
                    BooksInOrder.Add(i);
                }
            }         
        }
        private void LoadAccountBookInOrder()
        {
            AccountBookInOrder.Clear();
            int idAccount = Id_for_Account_OrderList;

            var queryOrders = (from b in db.Orders.Include("Account")
                                where b.Account.Id == idAccount
                                select b).ToList();
            foreach (Order i in queryOrders)
            {
                AccountBookInOrder.Add(i);
            }

        }
        private void LoadPopularParam()
        {
            ParamPopularSearch.Add("Books");
            ParamPopularSearch.Add("Autors");
            ParamPopularSearch.Add("Genres");
            TimePopularSearch.Add("Day");
            TimePopularSearch.Add("Week");
            TimePopularSearch.Add("Month");
            TimePopularSearch.Add("Year");
        
        }

        private int id_for_Account_OrderList = -1;
        public int Id_for_Account_OrderList
        {
            get { return id_for_Account_OrderList; }
            set
            {
                id_for_Account_OrderList = value;
                OnPropertyChanged(nameof(Id_for_Account_OrderList));
            }
        }
       
        private Account currentAccount;
        public Account CurrentAccount
        {
            get { return currentAccount; }
            set 
            {
                currentAccount = value;
                OnPropertyChanged(nameof(CurrentAccount));
            }
        
        }
        public string CurrentAccountFirstname
        {
            get { return currentAccount.FirstName; }
            set
            {
                currentAccount.FirstName = value;
                OnPropertyChanged(nameof(CurrentAccountFirstname));
            }

        }
        public string CurrentAccountLastname
        {
            get { return currentAccount.LastName; }
            set
            {
                currentAccount.LastName = value;
                OnPropertyChanged(nameof(CurrentAccountLastname));
            }

        }

        private int index_selected_comboboxAuthor = -1;
        public int Index_selected_comboboxAuthor
        {
            get
            {
                return index_selected_comboboxAuthor;
            }
            set
            {
                index_selected_comboboxAuthor = value;
                OnPropertyChanged(nameof(Index_selected_comboboxAuthor));
            }
        }

        private int index_selected_comboboxStock = -1;
        public int Index_selected_comboboxStock
        {
            get
            {
                return index_selected_comboboxStock;
            }
            set
            {
                index_selected_comboboxStock = value;
                OnPropertyChanged(nameof(Index_selected_comboboxStock));
            }
        }

        private int index_selected_comboboxPublishing = -1;
        public int Index_selected_comboboxPublishing
        {
            get
            {
                return index_selected_comboboxPublishing;
            }
            set
            {

                index_selected_comboboxPublishing = value;

                OnPropertyChanged(nameof(Index_selected_comboboxPublishing));
            }
        }

        private int index_selected_comboboxLanguage = -1;
        public int Index_selected_comboboxLanguage
        {
            get
            {
                return index_selected_comboboxLanguage;
            }
            set
            {

                index_selected_comboboxLanguage = value;

                OnPropertyChanged(nameof(Index_selected_comboboxLanguage));
            }
        }

        private int index_selected_comboboxGenre = -1;
        public int Index_selected_comboboxGenre
        {
            get
            {
                return index_selected_comboboxGenre;
            }
            set
            {

                index_selected_comboboxGenre = value;

                OnPropertyChanged(nameof(Index_selected_comboboxGenre));
            }
        }

        private int index_selected_listbox_Books = -1;

        public int Index_selected_listbox_Books
        {
            get
            {
                return index_selected_listbox_Books;
            }
            set
            {
                index_selected_listbox_Books = value;

                if (index_selected_listbox_Books > -1)
                {
                    NameBookEdit = BooksList[index_selected_listbox_Books].Name;
                    YearEditBookEdit = Convert.ToString(BooksList[index_selected_listbox_Books].Year_Edit);
                    CostPriceBookEdit = Convert.ToString(BooksList[index_selected_listbox_Books].Cost_Piece);
                    PagesBookEdit = Convert.ToString(BooksList[index_selected_listbox_Books].Pages);
                    CountBookEdit = Convert.ToString(BooksList[index_selected_listbox_Books].CountBooks);

                    string nameA = BooksList[index_selected_listbox_Books].Author;

                    for (int i = 0; i < AuthorsList.Count; i++)
                    {
                        if (AuthorsList[i].Name == nameA)
                        {
                            Index_selected_comboboxAuthorEdit = i;
                            break;
                        }
                    }
                    string nameG = BooksList[index_selected_listbox_Books].Genre;

                    for (int i = 0; i < GenresList.Count; i++)
                    {
                        if (GenresList[i].Name == nameG)
                        {
                            Index_selected_comboboxGenreEdit = i;
                            break;
                        }
                    }

                    string nameP = BooksList[index_selected_listbox_Books].Edit;

                    for (int i = 0; i < PublishingsList.Count; i++)
                    {
                        if (PublishingsList[i].Name == nameP)
                        {
                            Index_selected_comboboxPublishingEdit = i;
                            break;
                        }
                    }
                    string nameL = BooksList[index_selected_listbox_Books].Language;

                    for (int i = 0; i < LanguagesList.Count; i++)
                    {
                        if (LanguagesList[i].Name == nameL)
                        {
                            Index_selected_comboboxLanguageEdit = i;
                            break;
                        }
                    }

                    string nameS = BooksList[index_selected_listbox_Books]?.Stock;
                    if (nameS == null)
                    {
                        Index_selected_comboboxStockEdit = -1;
                    }
                    else
                    {
                        for (int i = 0; i < StocksList.Count; i++)
                        {
                            if (StocksList[i].Name == nameS)
                            {
                                Index_selected_comboboxStockEdit = i;
                                break;
                            }

                        }
                    }
                }
                OnPropertyChanged(nameof(Index_selected_listbox_Books));
            }
        }

        private int index_selected_listbox_Accounts = -1;

        public int Index_selected_listbox_Accounts
        {
            get
            {
                return index_selected_listbox_Accounts;
            }
            set
            {
                index_selected_listbox_Accounts = value;

                FirstnameAccountEdit = AccountsList[index_selected_listbox_Accounts].Firstname;
                LastnameAccountEdit = AccountsList[index_selected_listbox_Accounts].Lastname;
                LoginAccountEdit = AccountsList[index_selected_listbox_Accounts].Login;
                PasswordAccountEdit = AccountsList[index_selected_listbox_Accounts].Password;

                string namePosition = AccountsList[index_selected_listbox_Accounts].Position;

                for (int i = 0; i < PositionsList.Count; i++)
                {
                    if (PositionsList[i].Name == namePosition)
                    {
                        Index_selected_combobox_Position_Edit = i;
                        break;
                    }
                }
               
                OnPropertyChanged(nameof(Index_selected_listbox_Accounts));
            }
        }
        //==== Edit Book
        string nameBookEdit = null;
        string yearEditBookEdit = null;
        string costPriceBookEdit = null;
        string pagesBookEdit = null;
        string countBookEdit = null;

        public string NameBookEdit
        {
            get { return nameBookEdit; }
            set
            {
                nameBookEdit = value;
                OnPropertyChanged(nameof(NameBookEdit));
            }
        }
        public string YearEditBookEdit
        {
            get { return yearEditBookEdit; }
            set
            {
                try
                {
                    yearEditBookEdit = value;
                    OnPropertyChanged(nameof(YearEditBookEdit));
                }
                catch (Exception ex)
                {

                    StreamWriter sw = new StreamWriter("../../Exception.txt", false);
                    string line = ex.ToString();
                    sw.WriteLine(line);
                    sw.Close();
                }
            }
        }
        public string CostPriceBookEdit
        {
            get { return costPriceBookEdit; }
            set
            {
                costPriceBookEdit = value;
                OnPropertyChanged(nameof(CostPriceBookEdit));
            }
        }
        public string PagesBookEdit
        {
            get { return pagesBookEdit; }
            set
            {
                pagesBookEdit = value;
                OnPropertyChanged(nameof(PagesBookEdit));
            }
        }
        public string CountBookEdit
        {
            get { return countBookEdit; }
            set
            {
                countBookEdit = value;
                OnPropertyChanged(nameof(CountBookEdit));
            }
        }

        private int index_selected_comboboxAuthorEdit = -1;
        public int Index_selected_comboboxAuthorEdit
        {
            get
            {
                return index_selected_comboboxAuthorEdit;
            }
            set
            {
                index_selected_comboboxAuthorEdit = value;
                OnPropertyChanged(nameof(Index_selected_comboboxAuthorEdit));
            }
        }

        private int index_selected_comboboxStockEdit = -1;
        public int Index_selected_comboboxStockEdit
        {
            get
            {
                return index_selected_comboboxStockEdit;
            }
            set
            {
                index_selected_comboboxStockEdit = value;
                OnPropertyChanged(nameof(Index_selected_comboboxStockEdit));
            }
        }

        private int index_selected_comboboxPublishingEdit = -1;
        public int Index_selected_comboboxPublishingEdit
        {
            get
            {
                return index_selected_comboboxPublishingEdit;
            }
            set
            {

                index_selected_comboboxPublishingEdit = value;

                OnPropertyChanged(nameof(Index_selected_comboboxPublishingEdit));
            }
        }

        private int index_selected_comboboxLanguageEdit = -1;
        public int Index_selected_comboboxLanguageEdit
        {
            get
            {
                return index_selected_comboboxLanguageEdit;
            }
            set
            {

                index_selected_comboboxLanguageEdit = value;

                OnPropertyChanged(nameof(Index_selected_comboboxLanguageEdit));
            }
        }

        private int index_selected_comboboxGenreEdit = -1;
        public int Index_selected_comboboxGenreEdit
        {
            get
            {
                return index_selected_comboboxGenreEdit;
            }
            set
            {

                index_selected_comboboxGenreEdit = value;

                OnPropertyChanged(nameof(Index_selected_comboboxGenreEdit));
            }
        }

        private DelegateCommand bookEditCommand;
        public ICommand BookEditCommand
        {
            get
            {
                if (bookEditCommand == null)
                {
                    bookEditCommand = new DelegateCommand(param => this.BookEdit(), param => this.CanBookEdit());
                }
                return bookEditCommand;
            }
        }
        private void BookEdit()
        {
            try
            {
                int idBook = BooksList[index_selected_listbox_Books].Id;
                var queryBookEdit = (from b in db.Books
                                     where b.Id == idBook
                                     select b).Single();

                var queryBookCount = (from b in db.BooksAvailables
                                      where b.Id == idBook
                                      select b).Single();

                int idAuthor = AuthorsList[index_selected_comboboxAuthorEdit].Id;
                var queryBookAuthorEdit = (from b in db.Authors
                                           where b.Id == idAuthor
                                           select b).Single();

                int idPublishing = PublishingsList[index_selected_comboboxPublishingEdit].Id;
                var queryBookPublishingEdit = (from b in db.Publishings
                                               where b.Id == idPublishing
                                               select b).Single();

                int idLanguage = LanguagesList[index_selected_comboboxLanguageEdit].Id;
                var queryBookLanguageEdit = (from b in db.Languages
                                               where b.Id == idLanguage
                                               select b).Single();

                int idGenre = GenresList[index_selected_comboboxGenreEdit].Id;
                var queryBookGenreEdit = (from b in db.Genres
                                             where b.Id == idGenre
                                             select b).Single();


                queryBookEdit.Name = nameBookEdit;
                queryBookEdit.Year_edit = Convert.ToInt32(yearEditBookEdit);
                queryBookEdit.Cost_price =Convert.ToDouble(costPriceBookEdit);
                queryBookEdit.Pages = Convert.ToInt32(pagesBookEdit);
                queryBookCount.Count_Book = Convert.ToInt32(countBookEdit);
                queryBookEdit.Author = queryBookAuthorEdit;
                queryBookEdit.Publishing = queryBookPublishingEdit;
                queryBookEdit.Language = queryBookLanguageEdit;
                queryBookEdit.Genre = queryBookGenreEdit;
                
                if (index_selected_comboboxStockEdit == -1)
                {
                    queryBookEdit.Stock = null;
                }
                else
                {
                    int idStock = StocksList[index_selected_comboboxStockEdit].Id;
                    var queryBookStockEdit = (from b in db.Stocks
                                              where b.Id == idStock
                                              select b).Single();
                    queryBookEdit.Stock = queryBookStockEdit;
                }              
                NameBookEdit = null;
                YearEditBookEdit = null;
                CostPriceBookEdit = null;
                PagesBookEdit = null;
                CountBookEdit = null;
                index_selected_listbox_Books = -1;
                Index_selected_comboboxAuthorEdit = -1;
                Index_selected_comboboxPublishingEdit = -1;
                Index_selected_comboboxLanguageEdit = -1;
                Index_selected_comboboxGenreEdit = -1;
                Index_selected_comboboxStockEdit = -1;
                db.SaveChanges();               
                LoadBooks();

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanBookEdit()
        {
            return (index_selected_listbox_Books != -1);
        }
        //====Add book

        string nameBookAdd = null;
        string yearEditBookAdd = null;
        string costPriceBookAdd = null;
        string pagesBookAdd = null;
        string countBookAdd = null;
   
        public string NameBookAdd
        {
            get { return nameBookAdd; }
            set
            {
                nameBookAdd = value;
                OnPropertyChanged(nameof(NameBookAdd));
            }
        }
        public string YearEditBookAdd
        {
            get { return yearEditBookAdd; }
            set
            {
                try
                {
                    yearEditBookAdd = value;
                    OnPropertyChanged(nameof(YearEditBookAdd));
                }
                catch (Exception ex)
                {

                    StreamWriter sw = new StreamWriter("../../Exception.txt", false);
                    string line = ex.ToString();
                    sw.WriteLine(line);
                    sw.Close();
                }
            }
        }
        public string CostPriceBookAdd
        {
            get { return costPriceBookAdd; }
            set
            {
                costPriceBookAdd = value;
                OnPropertyChanged(nameof(CostPriceBookAdd));
            }
        }
        public string PagesBookAdd
        {
            get { return pagesBookAdd; }
            set
            {
                pagesBookAdd = value;
                OnPropertyChanged(nameof(PagesBookAdd));
            }
        }
        public string CountBookAdd
        {
            get { return countBookAdd; }
            set
            {
                countBookAdd = value;
                OnPropertyChanged(nameof(CountBookAdd));
            }
        }

        private DelegateCommand addBookCommand;

        public ICommand AddBookCommand
        {
            get
            {
                if (addBookCommand == null)
                {
                    addBookCommand = new DelegateCommand(param => this.AddBook(), param => this.CanAddBook());
                }
                return addBookCommand;
            }
        }

        private void AddBook()
        {
            try
            {              
                Stock queryStock = null;
                Publishing queryPublishing = null;
                Language queryLanguage = null;
                Genre queryGenre = null;
                Author queryAuthor = null;
                if (index_selected_comboboxStock != -1)
                {
                    int idStock = StocksList[index_selected_comboboxStock].Id;
                    queryStock = (from b in db.Stocks
                                  where b.Id == idStock
                                  select b).Single();
                }
                if (index_selected_comboboxPublishing != -1)
                {
                    int idPublishing = PublishingsList[index_selected_comboboxPublishing].Id;
                    queryPublishing = (from b in db.Publishings
                                       where b.Id == idPublishing
                                       select b).Single();
                }
                if (index_selected_comboboxLanguage != -1)
                {
                    int idLanguage = LanguagesList[index_selected_comboboxLanguage].Id;
                    queryLanguage = (from b in db.Languages
                                     where b.Id == idLanguage
                                     select b).Single();
                }
                if (index_selected_comboboxGenre != -1)
                {
                    int idGenre = GenresList[index_selected_comboboxGenre].Id;
                    queryGenre = (from b in db.Genres
                                  where b.Id == idGenre
                                  select b).Single();
                }
                if (index_selected_comboboxAuthor != -1)
                {
                    int idAuthor = AuthorsList[index_selected_comboboxAuthor].Id;
                    queryAuthor = (from b in db.Authors
                                   where b.Id == idAuthor
                                   select b).Single();
                }
                var tmpBook = new Book
                {
                    Name = nameBookAdd,
                    Year_edit = Convert.ToInt32(yearEditBookAdd),
                    Cost_price = Convert.ToDouble(costPriceBookAdd),
                    Pages = Convert.ToInt32(pagesBookAdd),
                    Stock = queryStock,
                    Publishing = queryPublishing,
                    Language = queryLanguage,
                    Genre = queryGenre,
                    Author = queryAuthor
                };
                db.Books.Add(tmpBook);

                var tmpCountBook = new BooksAvailable
                {
                    Book = tmpBook,
                    Count_Book = Convert.ToInt32(countBookAdd)
                };

                db.BooksAvailables.Add(tmpCountBook);
                db.SaveChanges();
                
                LoadBooks();

                NameBookAdd = null;
                YearEditBookAdd = null;
                CostPriceBookAdd = null;
                PagesBookAdd = null;
                CountBookAdd = null;
                Index_selected_comboboxAuthor = -1;
                Index_selected_comboboxGenre = -1;
                Index_selected_comboboxLanguage = -1;
                Index_selected_comboboxPublishing = -1;
                Index_selected_comboboxStock = -1;

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }

        private bool CanAddBook()
        {
            return (nameBookAdd != null && yearEditBookAdd != null  &&
                    pagesBookAdd != null &&
                    costPriceBookAdd != null &&
                    index_selected_comboboxAuthor != -1 &&
                    index_selected_comboboxLanguage != -1 &&
                    index_selected_comboboxGenre != -1 &&
                    index_selected_comboboxPublishing != -1);
        }
        //----Delete Book

        private DelegateCommand deleteBookCommand;

        public ICommand DeleteBookCommand
        {
            get
            {
                if (deleteBookCommand == null)
                {
                    deleteBookCommand = new DelegateCommand(param => this.DeleteBook(), param => this.CanDeleteBook());
                }
                return deleteBookCommand;
            }
        }

        private void DeleteBook()
        {
            ConDeleteBookFromDBWin delW = new ConDeleteBookFromDBWin();
            delW.DataContext = this;
            delW.WindowMess.Text = "Are you sure you want to delete this book?";
            delW.Show();           
        }

        private bool CanDeleteBook()
        {
            return index_selected_listbox_Books != -1;
        }

        //===Add Edit Remove

        private string nameAdd = null;
        public string NameAdd
        {
            get { return nameAdd; }
            set
            {
                nameAdd = value;
                OnPropertyChanged(nameof(NameAdd));
            }
        }

        private string nameEdit = null;
        public string NameEdit
        {
            get { return nameEdit; }
            set
            {
                nameEdit = value;
                OnPropertyChanged(nameof(NameEdit));
            }
        }

        //-----Language
        private int index_selected_listbox_EditRemove_Language = -1;

        public int Index_selected_listbox_EditRemove_Language
        {
            get
            {
                return index_selected_listbox_EditRemove_Language;
            }
            set
            {
                index_selected_listbox_EditRemove_Language = value;


                NameEdit = LanguagesList[index_selected_listbox_EditRemove_Language].Name;

                OnPropertyChanged(nameof(Index_selected_listbox_EditRemove_Language));
            }
        }    
        private DelegateCommand languageCommand;
        public ICommand LanguageCommand
        {
            get
            {
                if (languageCommand == null)
                {
                    languageCommand = new DelegateCommand(param => this.Language(), null);
                }
                return languageCommand;
            }
        }
        
        private void Language()
        {
            try
            {
                LanguageWin lanWin = new LanguageWin();
                lanWin.DataContext = this;
                lanWin.Show();
                NameEdit = null;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        //=== Add Language
        private DelegateCommand languageAddCommand;
        public ICommand LanguageAddCommand
        {
            get
            {
                if (languageAddCommand == null)
                {
                    languageAddCommand = new DelegateCommand(param => this.LanguageAdd(), param => this.CanLanguageAdd());
                }
                return languageAddCommand;
            }
        }
        private void LanguageAdd()
        {
            try
            {
                var language1 = new Language { Name = nameAdd };
               
                db.Languages.Add(language1);
                db.SaveChanges();
                LoadLanguages();
                NameAdd = "";

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanLanguageAdd()
        {
            return (nameAdd != null && nameAdd != "");
        }
        //=== Edit Language
        private DelegateCommand languageEditCommand;
        public ICommand LanguageEditCommand
        {
            get
            {
                if (languageEditCommand == null)
                {
                    languageEditCommand = new DelegateCommand(param => this.LanguageEdit(), param => this.CanLanguageEdit());
                }
                return languageEditCommand;
            }
        }
        private void LanguageEdit()
        {
            try
            {
                int idLang = LanguagesList[index_selected_listbox_EditRemove_Language].Id;
                var queryLangEdit = (from b in db.Languages
                                where b.Id == idLang
                                select b).Single();
                queryLangEdit.Name = nameEdit;                        
               
                index_selected_listbox_EditRemove_Language = -1;
                db.SaveChanges();
                LoadLanguages();
                NameEdit = "";
                LoadBooks();

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanLanguageEdit()
        {
            return (index_selected_listbox_EditRemove_Language != -1);
        }

        //===Delete Language

        private DelegateCommand languageDeleteCommand;
        public ICommand LanguageDeleteCommand
        {
            get
            {
                if (languageDeleteCommand == null)
                {
                    languageDeleteCommand = new DelegateCommand(param => this.LanguageDelete(), param => this.CanLanguageDelete());
                }
                return languageDeleteCommand;
            }
        }
        private void LanguageDelete()
        {
            ConDeleteLanguageWin dL = new ConDeleteLanguageWin();
           dL.DataContext = this;
            dL.WindowMess.Text = "Are you sure you want to delete this language?";
            dL.Show();

        }
        private bool CanLanguageDelete()
        {
            return (index_selected_listbox_EditRemove_Language != -1);
        }


        //-----Genre
        private int index_selected_listbox_EditRemove_Genre = -1;

        public int Index_selected_listbox_EditRemove_Genre
        {
            get
            {
                return index_selected_listbox_EditRemove_Genre;
            }
            set
            {
                index_selected_listbox_EditRemove_Genre = value;


                NameEdit = GenresList[index_selected_listbox_EditRemove_Genre].Name;

                OnPropertyChanged(nameof(Index_selected_listbox_EditRemove_Genre));
            }
        }

        
        private DelegateCommand genreCommand;
        public ICommand GenreCommand
        {
            get
            {
                if (genreCommand == null)
                {
                    genreCommand = new DelegateCommand(param => this.Genre(), null);
                }
                return genreCommand;
            }
        }

        private void Genre()
        {
            try
            {
                GenreWin genWin = new GenreWin();
                genWin.DataContext = this;
                genWin.Show();
                NameEdit = null;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        //=== Add Genre
        private DelegateCommand genreAddCommand;
        public ICommand GenreAddCommand
        {
            get
            {
                if (genreAddCommand == null)
                {
                    genreAddCommand = new DelegateCommand(param => this.GenreAdd(), param => this.CanGenreAdd());
                }
                return genreAddCommand;
            }
        }
        private void GenreAdd()
        {
            try
            {
                var genre1 = new Genre { Name = nameAdd };

                db.Genres.Add(genre1);
                db.SaveChanges();
                LoadGenres();
                NameAdd = "";

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanGenreAdd()
        {
            return (nameAdd != null && NameAdd != "");
        }
        //=== Edit Genre
        private DelegateCommand genreEditCommand;
        public ICommand GenreEditCommand
        {
            get
            {
                if (genreEditCommand == null)
                {
                    genreEditCommand = new DelegateCommand(param => this.GenreEdit(), param => this.CanGenreEdit());
                }
                return genreEditCommand;
            }
        }
        private void GenreEdit()
        {
            try
            {
                int idLang = GenresList[index_selected_listbox_EditRemove_Genre].Id;
                var queryLangEdit = (from b in db.Genres
                                     where b.Id == idLang
                                     select b).Single();
                queryLangEdit.Name = nameEdit;
                NameEdit = "";
                index_selected_listbox_EditRemove_Genre = -1;
                db.SaveChanges();
                LoadGenres();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanGenreEdit()
        {
            return (index_selected_listbox_EditRemove_Genre != -1);
        }

        //===Delete Genre

        private DelegateCommand genreDeleteCommand;
        public ICommand GenreDeleteCommand
        {
            get
            {
                if (genreDeleteCommand == null)
                {
                    genreDeleteCommand = new DelegateCommand(param => this.GenreDelete(), param => this.CanGenreDelete());
                }
                return genreDeleteCommand;
            }
        }
        private void GenreDelete()
        {
            ConDeleteGenreWin dL = new ConDeleteGenreWin();
            dL.DataContext = this;
            dL.WindowMess.Text = "Are you sure you want to delete this genre?";
            dL.Show();

        }
        private bool CanGenreDelete()
        {
            return (index_selected_listbox_EditRemove_Genre != -1);
        }

        //-----Publishing

        private int index_selected_listbox_EditRemove_Publishing = -1;
        public int Index_selected_listbox_EditRemove_Publishing
        {
            get
            {
                return index_selected_listbox_EditRemove_Publishing;
            }
            set
            {
                index_selected_listbox_EditRemove_Publishing = value;


                NameEdit = PublishingsList[index_selected_listbox_EditRemove_Publishing].Name;

                OnPropertyChanged(nameof(Index_selected_listbox_EditRemove_Publishing));
            }
        }

        private DelegateCommand publishingCommand;
        public ICommand PublishingCommand
        {
            get
            {
                if (publishingCommand == null)
                {
                    publishingCommand = new DelegateCommand(param => this.Publishing(), null);
                }
                return publishingCommand;
            }
        }

        private void Publishing()
        {
            try
            {
                PublishingWin publWin = new PublishingWin();
                publWin.DataContext = this;
                publWin.Show();
                NameEdit = null;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        //=== Add Publishing
        private DelegateCommand publishingAddCommand;
        public ICommand PublishingAddCommand
        {
            get
            {
                if (publishingAddCommand == null)
                {
                    publishingAddCommand = new DelegateCommand(param => this.PublishingAdd(), param => this.CanPublishingAdd());
                }
                return publishingAddCommand;
            }
        }
        private void PublishingAdd()
        {
            try
            {
                var publishing1 = new Publishing { Name = nameAdd };

                db.Publishings.Add(publishing1);
                db.SaveChanges();
                LoadPublishings();
                NameAdd = "";

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanPublishingAdd()
        {
            return (NameAdd != null && NameAdd != "");
        }
        //=== Edit Publishing
        private DelegateCommand publishingEditCommand;
        public ICommand PublishingEditCommand
        {
            get
            {
                if (publishingEditCommand == null)
                {
                    publishingEditCommand = new DelegateCommand(param => this.PublishingEdit(), param => this.CanPublishingEdit());
                }
                return publishingEditCommand;
            }
        }
        private void PublishingEdit()
        {
            try
            {
                int idPubl = PublishingsList[index_selected_listbox_EditRemove_Publishing].Id;
                var queryPublEdit = (from b in db.Publishings
                                     where b.Id == idPubl
                                     select b).Single();
                queryPublEdit.Name = nameEdit;
                NameEdit = "";
                index_selected_listbox_EditRemove_Publishing = -1;
                db.SaveChanges();
                LoadPublishings();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanPublishingEdit()
        {
            return (index_selected_listbox_EditRemove_Publishing != -1);
        }

        //===Delete Publishing

        private DelegateCommand publishingDeleteCommand;
        public ICommand PublishingDeleteCommand
        {
            get
            {
                if (publishingDeleteCommand == null)
                {
                    publishingDeleteCommand = new DelegateCommand(param => this.PublishingDelete(), param => this.CanPublishingDelete());
                }
                return publishingDeleteCommand;
            }
        }
        private void PublishingDelete()
        {
            ConDeletePublishingWin dL = new ConDeletePublishingWin();
            dL.DataContext = this;
            dL.WindowMess.Text = "Are you sure you want to delete this publishing?";
            dL.Show();
        }
        private bool CanPublishingDelete()
        {
            return (index_selected_listbox_EditRemove_Publishing != -1);
        }

        //-----Author

        private int index_selected_listbox_EditRemove_Author = -1;

        public int Index_selected_listbox_EditRemove_Author
        {
            get
            {
                return index_selected_listbox_EditRemove_Author;
            }
            set
            {
                index_selected_listbox_EditRemove_Author = value;


                NameEdit = AuthorsList[index_selected_listbox_EditRemove_Author].Name;

                OnPropertyChanged(nameof(Index_selected_listbox_EditRemove_Author));
            }
        }


        private DelegateCommand authorCommand;
        public ICommand AuthorCommand
        {
            get
            {
                if (authorCommand == null)
                {
                    authorCommand = new DelegateCommand(param => this.Author(), null);
                }
                return authorCommand;
            }
        }

        private void Author()
        {
            try
            {
                AuthorWin publWin = new AuthorWin();
                publWin.DataContext = this;
                publWin.Show();
                NameEdit = null;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        //=== Add Author
        private DelegateCommand authorAddCommand;
        public ICommand AuthorAddCommand
        {
            get
            {
                if (authorAddCommand == null)
                {
                    authorAddCommand = new DelegateCommand(param => this.AuthorAdd(), param => this.CanAuthorAdd());
                }
                return authorAddCommand;
            }
        }
        private void AuthorAdd()
        {
            try
            {
                var author1 = new Author { Name = nameAdd };

                db.Authors.Add(author1);
                db.SaveChanges();
                LoadAuthors();
                NameAdd = "";

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanAuthorAdd()
        {
            return (NameAdd != null && NameAdd != "");
        }
        //=== Edit Author

        private DelegateCommand authorEditCommand;
        public ICommand AuthorEditCommand
        {
            get
            {
                if (authorEditCommand == null)
                {
                    authorEditCommand = new DelegateCommand(param => this.AuthorEdit(), param => this.CanAuthorEdit());
                }
                return authorEditCommand;
            }
        }
        private void AuthorEdit()
        {
            try
            {
                int idAuthor = AuthorsList[index_selected_listbox_EditRemove_Author].Id;
                var queryAuthorEdit = (from b in db.Authors
                                     where b.Id == idAuthor
                                       select b).Single();
                queryAuthorEdit.Name = nameEdit;
                NameEdit = "";
                index_selected_listbox_EditRemove_Author = -1;
                db.SaveChanges();
                LoadAuthors();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanAuthorEdit()
        {
            return (index_selected_listbox_EditRemove_Author != -1);
        }

        //===Delete Author

        private DelegateCommand authorDeleteCommand;
        public ICommand AuthorDeleteCommand
        {
            get
            {
                if (authorDeleteCommand == null)
                {
                    authorDeleteCommand = new DelegateCommand(param => this.AuthorDelete(), param => this.CanAuthorDelete());
                }
                return authorDeleteCommand;
            }
        }
        private void AuthorDelete()
        {
            ConDeleteAuthorWin dL = new ConDeleteAuthorWin();
            dL.DataContext = this;
            dL.WindowMess.Text = "Are you sure you want to delete this author?";
            dL.Show();
        }
        private bool CanAuthorDelete()
        {
            return (index_selected_listbox_EditRemove_Author != -1);
        }

        //-----Stock

        private string nameStockPrAdd = null;
        public string NameStockPrAdd
        {
            get { return nameStockPrAdd; }
            set
            {
                nameStockPrAdd = value;
                OnPropertyChanged(nameof(NameStockPrAdd));
            }
        }

        private string nameStockPrEdit = null;
        public string NameStockPrEdit
        {
            get { return nameStockPrEdit; }
            set
            {
                nameStockPrEdit = value;
                OnPropertyChanged(nameof(NameStockPrEdit));
            }
        }

        private int index_selected_listbox_EditRemove_Stock = -1;

        public int Index_selected_listbox_EditRemove_Stock
        {
            get
            {
                return index_selected_listbox_EditRemove_Stock;
            }
            set
            {
                index_selected_listbox_EditRemove_Stock = value;


                NameEdit = StocksList[index_selected_listbox_EditRemove_Stock].Name;

                NameStockPrEdit = Convert.ToString(StocksList[index_selected_listbox_EditRemove_Stock].PercentageDiscount);

                OnPropertyChanged(nameof(Index_selected_listbox_EditRemove_Stock));
            }
        }

        private DelegateCommand stockCommand;
        public ICommand StockCommand
        {
            get
            {
                if (stockCommand == null)
                {
                    stockCommand = new DelegateCommand(param => this.Stock(), null);
                }
                return stockCommand;
            }
        }

        private void Stock()
        {
            try
            {
                StockWin stockWin = new StockWin();
                stockWin.DataContext = this;
                stockWin.Show();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        //=== Add Stock
        private DelegateCommand stockAddCommand;
        public ICommand StockAddCommand
        {
            get
            {
                if (stockAddCommand == null)
                {
                    stockAddCommand = new DelegateCommand(param => this.StockAdd(), param => this.CanStockAdd());
                }
                return stockAddCommand;
            }
        }
        private void StockAdd()
        {
            try
            {
                var stock1 = new Stock 
                {
                    Name = nameAdd,
                    PercentageDiscount = Convert.ToInt32(nameStockPrAdd)
                };

                db.Stocks.Add(stock1);
                db.SaveChanges();
                LoadStocks();
                NameAdd = "";
                nameStockPrAdd = "";

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanStockAdd()
        {
            return (NameAdd != null && NameAdd != "" && NameStockPrAdd != "" && NameStockPrAdd != null);
        }
        //=== Edit Stock

        private DelegateCommand stockEditCommand;
        public ICommand StockEditCommand
        {
            get
            {
                if (stockEditCommand == null)
                {
                    stockEditCommand = new DelegateCommand(param => this.StockEdit(), param => this.CanStockEdit());
                }
                return stockEditCommand;
            }
        }
        private void StockEdit()
        {
            try
            {
                int idStock = StocksList[index_selected_listbox_EditRemove_Stock].Id;
                var queryStockEdit = (from b in db.Stocks
                                      where b.Id == idStock
                                      select b).Single();
                queryStockEdit.Name = nameEdit;
                queryStockEdit.PercentageDiscount = Convert.ToInt32(nameStockPrEdit);
                NameStockPrEdit = "";
                NameEdit = "";
                index_selected_listbox_EditRemove_Stock = -1;
                db.SaveChanges();
                LoadStocks();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanStockEdit()
        {
            return (index_selected_listbox_EditRemove_Stock != -1);
        }
        //===Delete Stock

        private DelegateCommand stockDeleteCommand;
        public ICommand StockDeleteCommand
        {
            get
            {
                if (stockDeleteCommand == null)
                {
                    stockDeleteCommand = new DelegateCommand(param => this.StockDelete(), param => this.CanStockDelete());
                }
                return stockDeleteCommand;
            }
        }
        private void StockDelete()
        {
            ConDeleteStockWin dL = new ConDeleteStockWin();
            dL.DataContext = this;
            dL.WindowMess.Text = "Are you sure you want to delete this stock?";
            dL.Show();
        }
        private bool CanStockDelete()
        {
            return (index_selected_listbox_EditRemove_Stock != -1);
        }
        //=== Delete Stock from Book

        private DelegateCommand stockDeleteFromBookCommand;
        public ICommand StockDeleteFromBookCommand
        {
            get
            {
                if (stockDeleteFromBookCommand == null)
                {
                    stockDeleteFromBookCommand = new DelegateCommand(param => this.StockDeleteFromBook(), param => this.CanStockDeleteFromBook());
                }
                return stockDeleteFromBookCommand;
            }
        }
        private void StockDeleteFromBook()
        {
            try
            {
                int idBook = BooksList[index_selected_listbox_Books].Id;
                var query = (from b in db.Books
                            where b.Id == idBook
                            select b).Single();
                query.Stock = null;
                db.SaveChanges();
                LoadStocks();
                LoadBooks();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanStockDeleteFromBook()
        {
            return (index_selected_listbox_Books != -1 && BooksList[index_selected_listbox_Books].Stock != null);
        }
        //===========Search

        private string nameSearchBook = null;
        public string NameSearchBook
        {
            get { return nameSearchBook; }
            set
            {
                nameSearchBook = value;
                OnPropertyChanged(nameof(NameSearchBook));
            }
        }

        private int index_selected_combobox_Search_Author = -1;

        public int Index_selected_combobox_Search_Author
        {
            get
            {
                return index_selected_combobox_Search_Author;
            }
            set
            {
                index_selected_combobox_Search_Author = value;
                OnPropertyChanged(nameof(Index_selected_combobox_Search_Author));
            }
        }

        private int index_selected_combobox_Search_Genre = -1;

        public int Index_selected_combobox_Search_Genre
        {
            get
            {
                return index_selected_combobox_Search_Genre;
            }
            set
            {
                index_selected_combobox_Search_Genre = value;
                OnPropertyChanged(nameof(Index_selected_combobox_Search_Genre));
            }
        }

        private bool checkbox_NewBook = false;

        public bool Checkbox_NewBook
        {
            get
            {
                return checkbox_NewBook;
            }
            set
            {
                checkbox_NewBook = value;
                OnPropertyChanged(nameof(Checkbox_NewBook));
            }
        }

        List<int> resultSearch = new List<int>();
        List<int> resultSearchName = new List<int>();
        List<int> resultSearchAuthor = new List<int>();
        List<int> resultSearchNew = new List<int>();
        List<int> resultSearchGenre = new List<int>();
        int currentItemSearch = 0;
       

        private DelegateCommand searchBookCommand;
        public ICommand SearchBookCommand
        {
            get
            {
                if (searchBookCommand == null)
                {
                    searchBookCommand = new DelegateCommand(param => this.SearchBooks(), param => this.CanSearchBooks());
                }
                return searchBookCommand;
            }
        }
        private void SearchBooks()
        {
            try
            {              
                resultSearch.Clear();
                resultSearchName.Clear();
                resultSearchAuthor.Clear();
                resultSearchGenre.Clear();
                resultSearchNew.Clear();
                currentItemSearch = 0;

                for (int i = 0; i < BooksList.Count; i++)
                {
                    resultSearch.Add(i);
                }

                if (nameSearchBook != null && nameSearchBook != "")
                {
                    nameSearchBook = nameSearchBook.Replace(".", @"\.");                 
                    nameSearchBook = nameSearchBook.Replace("?", ".");
                    nameSearchBook = nameSearchBook.Replace("*", ".*");
                    nameSearchBook = "^" + nameSearchBook + "$";

                    Regex regMask = new Regex(nameSearchBook, RegexOptions.IgnoreCase);
                    for (int j = 0; j < BooksList.Count; j++)
                    {
                        if (regMask.IsMatch(BooksList[j].Name))
                        {
                            resultSearchName.Add(j);
                        }
                    }
                    var res = resultSearch.Intersect(resultSearchName).ToList();
                    resultSearch.Clear();
                    foreach (int i in res)
                    {
                        resultSearch.Add(i);
                    }

                }

                if (index_selected_combobox_Search_Author != -1)
                {
                    for (int j = 0; j < BooksList.Count; j++)
                    {
                        if (BooksList[j].Author == AuthorsList[index_selected_combobox_Search_Author].Name)
                        {
                            resultSearchAuthor.Add(j);
                        }
                    }
                    var res = resultSearch.Intersect(resultSearchAuthor).ToList();
                    resultSearch.Clear();
                    foreach (int i in res)
                    {
                        resultSearch.Add(i);
                    }
                }

                if (index_selected_combobox_Search_Genre != -1)
                {
                    for (int j = 0; j < BooksList.Count; j++)
                    {
                        if (BooksList[j].Genre == GenresList[index_selected_combobox_Search_Genre].Name)
                        {
                            resultSearchGenre.Add(j);
                        }
                    }
                    var res = resultSearch.Intersect(resultSearchGenre).ToList();
                    resultSearch.Clear();
                    foreach (int i in res)
                    {
                        resultSearch.Add(i);
                    }
                }

                if (checkbox_NewBook != false)
                {
                    for (int j = 0; j < BooksList.Count; j++)
                    {
                        if (Convert.ToInt32(BooksList[j].Year_Edit) >= 2020)
                        {
                            resultSearchNew.Add(j);
                        }
                    }
                    var res = resultSearch.Intersect(resultSearchNew).ToList();
                    resultSearch.Clear();
                    foreach (int i in res)
                    {
                        resultSearch.Add(i);
                    }
                }
                if (resultSearch.Count != 0)
                {
                    Index_selected_listbox_Books = resultSearch[currentItemSearch];
                }
                else
                {
                    Index_selected_listbox_Books = -1;
                }
                NameSearchBook = "";
                Index_selected_combobox_Search_Author = -1;
                Index_selected_combobox_Search_Genre = -1;
                Checkbox_NewBook = false;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanSearchBooks()
        {
            return ((   nameSearchBook != null && nameSearchBook != "") || index_selected_combobox_Search_Author != -1
                        || index_selected_combobox_Search_Genre != -1 || checkbox_NewBook != false);
        }

        //====Next Search
        private DelegateCommand searchNextBookCommand;
        public ICommand SearchNextBookCommand
        {
            get
            {
                if (searchNextBookCommand == null)
                {
                    searchNextBookCommand = new DelegateCommand(param => this.SearchNextBooks(), param => this.CanSearchNextBooks());
                }
                return searchNextBookCommand;
            }
        }
        private void SearchNextBooks()
        {
            try
            {
                currentItemSearch++;
                Index_selected_listbox_Books = resultSearch[currentItemSearch];
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanSearchNextBooks()
        {
            return (resultSearch.Count>1 && currentItemSearch<resultSearch.Count-1);
        }


        //------ Check Login
        string loginCheck = null;
        string passworCheck = null;
        string activeAccount = null;
        public string LoginCheck
        {
            get { return loginCheck; }
            set
            {
                loginCheck = value;
                OnPropertyChanged(nameof(LoginCheck));
            }
        }
        public string PasswordCheck
        {
            get { return passworCheck; }
            set
            {
                passworCheck = value;
                OnPropertyChanged(nameof(PasswordCheck));
            }
        }
        public string ActiveAccount
        {
            get { return activeAccount; }
            set
            {
                activeAccount = value;
                OnPropertyChanged(nameof(ActiveAccount));
            }
        }

        private int CheckLogin()
        {
            for (int i = 0; i < AccountsList.Count; i++)
            {
                if (AccountsList[i].Login == loginCheck)
                {
                    ActiveAccount = AccountsList[i].Firstname + " " + AccountsList[i].Lastname;
                    return i;
                }
            }
            return -1;
        }



        private DelegateCommand enterCommand;

        public ICommand EnterCommand
        {
            get
            {
                if (enterCommand == null)
                {
                    enterCommand = new DelegateCommand(param => this.Enter(), param => this.CanEnter());
                }
                return enterCommand;
            }
        }
        private void Enter()
        {
            if (CheckLogin() == -1)
            {
                ExceptionWindow exc = new ExceptionWindow("There is no account with such a login in the database!");
                exc.Show();
                return;
            }
            if (AccountsList[CheckLogin()].Password != passworCheck)
            {
                ExceptionWindow exc = new ExceptionWindow("Wrong password!");
                exc.Show();
                return;
            }
            else
            {
                try { 
                int idAccount = AccountsList[CheckLogin()].Id;
                var queryAccount =(from b in db.Accounts
                                   where b.Id == idAccount
                                   select b).Single();
                CurrentAccount = queryAccount;

                if (AccountsList[CheckLogin()].Position == "Buyer")
                {
                        Id_for_Account_OrderList = AccountsList[CheckLogin()].Id;
                        LoadAccountBookInOrder();
                        CountPriceInOrderBuyer();
                        BuyerWin buyerWin = new BuyerWin();
                    buyerWin.DataContext = this;
                    buyerWin.Show();
                }
                if (AccountsList[CheckLogin()].Position == "Administrator")
                {
                    AdminWin adminWin = new AdminWin();
                    adminWin.DataContext = this;
                    adminWin.Show();
                }
                if (AccountsList[CheckLogin()].Position == "Seller")
                {                  
                    LoadBuyersList();   
                    SellerWin sellerWin = new SellerWin();
                    sellerWin.DataContext = this;
                    sellerWin.Show();
                }
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }        
    } 
        private bool CanEnter()
        {
            if (enterCommand?.Parameter is PasswordBox)
            {
                PasswordCheck = ((PasswordBox)enterCommand.Parameter).Password;
            }
            return (LoginCheck != null && PasswordCheck != null && LoginCheck != "" && PasswordCheck != "");
        }

        //====Admin Add Account 

        string loginAdminAddAccount = null;
        string passworAdminAddAccount = null;
        string firstnameAdminAddAccount = null;
        string lastnameAdminAddAccount = null;
        int index_combobox_position = -1;

        public int Index_combobox_position
        {
            get { return index_combobox_position; }
            set
            {
                index_combobox_position = value;
                OnPropertyChanged(nameof(Index_combobox_position));
            }
        }
        public string LoginAdminAddAccount
        {
            get { return loginAdminAddAccount; }
            set
            {
                loginAdminAddAccount = value;
                OnPropertyChanged(nameof(LoginAdminAddAccount));
            }
        }
        public string PassworAdminAddAccount
        {
            get { return passworAdminAddAccount; }
            set
            {
                passworAdminAddAccount = value;
                OnPropertyChanged(nameof(PassworAdminAddAccount));
            }
        }
        public string FirstnameAdminAddAccount
        {
            get { return firstnameAdminAddAccount; }
            set
            {
                firstnameAdminAddAccount = value;
                OnPropertyChanged(nameof(FirstnameAdminAddAccount));
            }
        }
        public string LastnameAdminAddAccount
        {
            get { return lastnameAdminAddAccount; }
            set
            {
                lastnameAdminAddAccount = value;
                OnPropertyChanged(nameof(LastnameAdminAddAccount));
            }
        }

        private DelegateCommand adminAddAccountCommand;
        public ICommand AdminAddAccountCommand
        {
            get
            {
                if (adminAddAccountCommand == null)
                {
                    adminAddAccountCommand = new DelegateCommand(param => this.AdminAddAccount(), param => this.CanAdminAddAccount());
                }
                return adminAddAccountCommand;
            }
        }
        private void AdminAddAccount()
        {
            try
            {
                for (int i = 0; i < AccountsList.Count; i++)
                {
                    if (AccountsList[i].Login == loginAdminAddAccount)
                    {
                        ExceptionWindow exc = new ExceptionWindow("This login is already in use!");
                        exc.Show();
                        return; 
                    }              
                }
                Position queryPosition = null;
               
                    int idPosition = PositionsList[Index_combobox_position].Id;
                    queryPosition = (from b in db.Positions
                                  where b.Id == idPosition
                                     select b).Single();
                Account tmp = new Account
                {
                    FirstName = firstnameAdminAddAccount,
                    LastName = lastnameAdminAddAccount,
                    Login = loginAdminAddAccount,
                    Password = passworAdminAddAccount,
                    Position = queryPosition
                };
                db.Accounts.Add(tmp);
                db.SaveChanges();
                LoadAccounts();
                LoginAdminAddAccount = null;
                PassworAdminAddAccount = null;
                FirstnameAdminAddAccount = null;
                LastnameAdminAddAccount = null;
                Index_combobox_position = -1;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanAdminAddAccount()
        {
            return (loginAdminAddAccount != null && passworAdminAddAccount != null &&
                firstnameAdminAddAccount != null && lastnameAdminAddAccount != null && index_combobox_position != -1);
        }
        //====Registration Buyer

        string loginAdd = null;
        string passwordAdd = null;
        string passwordAgainAdd = null;
        string surnameAdd = null;
        string nameAddB = null;

        public string LoginAdd
        {

            get { return loginAdd; }
            set
            {
                loginAdd = value;
                OnPropertyChanged(nameof(LoginAdd));
            }
        }
        public string PasswordAdd
        {
            get { return passwordAdd; }
            set
            {
                passwordAdd = value;
                OnPropertyChanged(nameof(PasswordAdd));
            }
        }
        public string PasswordAgainAdd
        {
            get { return passwordAgainAdd; }
            set
            {
                passwordAgainAdd = value;
                OnPropertyChanged(nameof(PasswordAgainAdd));
            }
        }
        public string NameAddB
        {
            get { return nameAddB; }
            set
            {
                nameAddB = value;
                OnPropertyChanged(nameof(NameAddB));
            }
        }
        public string SurnameAdd
        {
            get { return surnameAdd; }
            set
            {
                surnameAdd = value;
                OnPropertyChanged(nameof(SurnameAdd));
            }
        }
        //-------------------------------------
        DelegateCommand passwordAgain;

        public ICommand PasswordAgain
        {
            get
            {
                if (passwordAgain == null)
                {
                    passwordAgain = new DelegateCommand(param => this.PasswordAgainA(), param => this.CanPasswordAgain());
                }
                return passwordAgain;
            }
        }

        void PasswordAgainA()
        {

        }

        bool CanPasswordAgain()
        {
            if (passwordAgain.Parameter is PasswordBox)
            {
                PasswordAgainAdd = ((PasswordBox)passwordAgain.Parameter).Password;
            }
            return true;
        }

       


        private DelegateCommand buyerAddAccountCommand;
        public ICommand BuyerAddAccountCommand
        {
            get
            {
                if (buyerAddAccountCommand == null)
                {
                    buyerAddAccountCommand = new DelegateCommand(param => this.BuyerAddAccount(), param => this.CanBuyerAddAccount());
                }
                return buyerAddAccountCommand;
            }
        }
        private void BuyerAddAccount()
        {
            try
            {
                for (int i = 0; i < AccountsList.Count; i++)
                {
                    if (AccountsList[i].Login == loginAdminAddAccount)
                    {
                        ExceptionWindow exc = new ExceptionWindow("This login is already in use!");
                        exc.Show();
                        return;
                    }
                }
               

                //int idPosition = PositionsList[Index_combobox_position].Id;
               var queryPosition = (from b in db.Positions
                                 where b.Name == "Buyer"
                                 select b).Single();

                bool checkLoginToBase = true;
                for (int i = 0; i < AccountsList.Count; i++)
                {
                    if (AccountsList[i].Login == LoginAdd)
                    { checkLoginToBase = false; }

                }
                if (checkLoginToBase)
                {
                    if (PasswordAdd == PasswordAgainAdd)
                    {
                        Account tmp = new Account
                        {
                        FirstName = NameAddB,
                        LastName = SurnameAdd,
                        Login = LoginAdd,
                        Password = PasswordAdd,
                        Position = queryPosition
                        };
                        db.Accounts.Add(tmp);
                        db.SaveChanges();
                        LoadAccounts();
                        ExceptionWindow exc = new ExceptionWindow("Account registered successfully!");
                        exc.Show();
                    }
                    else
                    {
                        ExceptionWindow exc = new ExceptionWindow("Passwords do not match!");
                        exc.Show();
                    }
                }
                else
                {
                    ExceptionWindow exc = new ExceptionWindow("The database already has an account with this login!");
                    exc.Show();
                }
                NameAddB = null;
                SurnameAdd = null;
                LoginAdd = null;
                PasswordAdd = null;
                PasswordAgainAdd = null;
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanBuyerAddAccount()
        {
            if (buyerAddAccountCommand?.Parameter is PasswordBox)
            {
                PasswordAdd = ((PasswordBox)buyerAddAccountCommand.Parameter).Password;
            }
            return (LoginAdd != null && PasswordAdd != null && PasswordAgainAdd != null && NameAddB != null && SurnameAdd != null &&
                    LoginAdd != "" && PasswordAdd != "" && PasswordAgainAdd != "" && NameAddB != "" && SurnameAdd != "");
        }
        //----Delete Admin Account

        private DelegateCommand deleteAdminAccountCommand;

        public ICommand DeleteAdminAccountCommand
        {
            get
            {
                if (deleteAdminAccountCommand == null)
                {
                    deleteAdminAccountCommand = new DelegateCommand(param => this.DeleteAdminAccount(), param => this.CanDeleteAdminAccount());
                }
                return deleteAdminAccountCommand;
            }
        }

        private void DeleteAdminAccount()
        {
            ConDeleteAccountWin dL = new ConDeleteAccountWin();
            dL.DataContext = this;
            dL.WindowMess.Text = "Are you sure you want to delete this account?";
            dL.Show();
        }

        private bool CanDeleteAdminAccount()
        {
            return index_selected_listbox_Accounts != -1;
        }

        //==== Edit Admin Account
        string firstnameAccountEdit = null;
        public string FirstnameAccountEdit
        {
            get { return firstnameAccountEdit; }
            set
            {
                firstnameAccountEdit = value;
                OnPropertyChanged(nameof(FirstnameAccountEdit));
            }
        }

        string lastnameAccountEdit = null;
        public string LastnameAccountEdit
        {
            get { return lastnameAccountEdit; }
            set
            {
                lastnameAccountEdit = value;
                OnPropertyChanged(nameof(LastnameAccountEdit));               
            }
        }

        string loginAccountEdit = null;
        public string LoginAccountEdit
        {
            get { return loginAccountEdit; }
            set
            {
                loginAccountEdit = value;
                OnPropertyChanged(nameof(LoginAccountEdit));
            }
        }
        string passwordAccountEdit = null;
        public string PasswordAccountEdit
        {
            get { return passwordAccountEdit; }
            set
            {
                passwordAccountEdit = value;
                OnPropertyChanged(nameof(PasswordAccountEdit));
            }
        }       
        private int index_selected_combobox_Position_Edit = -1;
        public int Index_selected_combobox_Position_Edit
        {
            get
            {
                return index_selected_combobox_Position_Edit;
            }
            set
            {
                index_selected_combobox_Position_Edit = value;
                OnPropertyChanged(nameof(Index_selected_combobox_Position_Edit));
            }
        }
        private DelegateCommand accountAdminEditCommand;
        public ICommand AccountAdminEditCommand
        {
            get
            {
                if (accountAdminEditCommand == null)
                {
                    accountAdminEditCommand = new DelegateCommand(param => this.AccountEdit(), param => this.CanAccountEdit());
                }
                return accountAdminEditCommand;
            }
        }
        private void AccountEdit()
        {
            try
            {
                int idAccount = AccountsList[index_selected_listbox_Accounts].Id;
                var queryAccountEdit = (from b in db.Accounts
                                     where b.Id == idAccount
                                        select b).Single();

                int idPosition = PositionsList[Index_selected_combobox_Position_Edit].Id;
                var queryAccountPositionEdit = (from b in db.Positions
                                           where b.Id == idPosition
                                           select b).Single();



                queryAccountEdit.FirstName = firstnameAccountEdit;
                queryAccountEdit.LastName = lastnameAccountEdit;
                queryAccountEdit.Login = loginAccountEdit;
                queryAccountEdit.Password = passwordAccountEdit;
                queryAccountEdit.Position = queryAccountPositionEdit;

                db.SaveChanges();
                LoadAccounts();

                FirstnameAccountEdit = null;
                LastnameAccountEdit = null;
                LoginAccountEdit = null;
                PasswordAccountEdit = null;
                Index_selected_combobox_Position_Edit = -1;


            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanAccountEdit()
        {
            return index_selected_listbox_Accounts != -1;
        }
        //===Seller add book by order

        int index_listview_position_buyer_sellerWin = -1;

        public int Index_listview_position_buyer_sellerWin
        {
            get { return index_listview_position_buyer_sellerWin; }
            set
            {
                index_listview_position_buyer_sellerWin = value;
                OnPropertyChanged(nameof(Index_listview_position_buyer_sellerWin));
            }
        }

        private DelegateCommand sellerAddBookToOrderCommand;
        public ICommand SellerAddBookToOrderCommand
        {
            get
            {
                if (sellerAddBookToOrderCommand == null)
                {
                    sellerAddBookToOrderCommand = new DelegateCommand(param => this.AddBookByOrder(), param => this.CanAddBookByOrdert());
                }
                return sellerAddBookToOrderCommand;
            }
        }
        private void AddBookByOrder()
        {
            try
            {

                int idBook = BooksList[Index_selected_listbox_Books].Id;

                var queryBookAv = (from b in db.BooksAvailables
                                   where b.Book.Id == idBook
                                   select b).Single();

                if (queryBookAv.Count_Book < 1)
                {
                    ExceptionWindow exc = new ExceptionWindow("There are not so many books available!");
                    exc.Show();
                }
                else
                {
                    queryBookAv.Count_Book--;

                    var queryBook = (from b in db.Books
                                     where b.Id == idBook
                                     select b).Single();

                    int idAccount = BuyerList[Index_listview_position_buyer_sellerWin].Id;
                    var queryAccount = (from b in db.Accounts
                                        where b.Id == idAccount
                                        select b).Single();


                    var queryOrder = (from b in db.Orders
                                      where b.Book.Id == idBook && b.Account.Id == idAccount
                                      select b).ToList();
                    if (queryOrder.Count != 0)
                    {
                        var queryOrder1 = (from b in db.Orders
                                           where b.Book.Id == idBook && b.Account.Id == idAccount
                                           select b).Single();
                        queryOrder1.Count_Book++;
                    }
                    else
                    {
                        Order tmp = new Order
                        {
                            Count_Book = 1,
                            Book = queryBook,
                            Account = queryAccount
                        };
                        db.Orders.Add(tmp);
                    }



                    db.SaveChanges();
                    LoadOrders();
                    LoadBooks();
                    LoadBuyersList();
                }

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanAddBookByOrdert()
        {
            return ( index_listview_position_buyer_sellerWin != -1 && Index_selected_listbox_Books != -1);
        }
        //====Open List order

        private DelegateCommand openListOrderCommand;
        public ICommand OpenListOrderCommand
        {
            get
            {
                if (openListOrderCommand == null)
                {
                    openListOrderCommand = new DelegateCommand(param => this.OpenListOrder(), param => this.CanOpenListOrder());
                }
                return openListOrderCommand;
            }
        }
        private void OpenListOrder()
        {
            try
            {

                LoadBookInOrder();


                string strTitle = BuyerList[Index_listview_position_buyer_sellerWin].Firstname + " " + BuyerList[Index_listview_position_buyer_sellerWin].Lastname;


                SellerListOrderWin orderWin = new SellerListOrderWin();
                orderWin.DataContext = this;
                orderWin.Title = strTitle;
                orderWin.Show();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }

        private bool CanOpenListOrder()
        {
            return (index_listview_position_buyer_sellerWin != -1 );
        }

        //===Delete Book from Orders

        int index_book_in_order_list_for_delete = -1;

        public int Index_book_in_order_list_for_delete
        {
            get { return index_book_in_order_list_for_delete; }
            set
            {
                index_book_in_order_list_for_delete = value;
                OnPropertyChanged(nameof(Index_book_in_order_list_for_delete));
            }
        }
        private DelegateCommand deleteBookFromOrderCommand;
        public ICommand DeleteBookFromOrderCommand
        {
            get
            {
                if (deleteBookFromOrderCommand == null)
                {
                    deleteBookFromOrderCommand = new DelegateCommand(param => this.DelBookFromOrder (), param => this.CanDelBookFromOrder());
                }
                return deleteBookFromOrderCommand;
            }
        }
        private void DelBookFromOrder()
        {
            try
            {
                
                int idOder = BooksInOrder[Index_book_in_order_list_for_delete].Id;
                var queryOrder = (from b in db.Orders.Include("Book")
                                  where b.Id == idOder
                                  select b).Single();
                int idBookRem = queryOrder.Book.Id;
                var queryBookAv = (from b in db.BooksAvailables
                                   where b.Id == idBookRem
                                   select b).Single();
                queryBookAv.Count_Book++;

                if (queryOrder.Count_Book > 1)
                {
                    queryOrder.Count_Book--;
                }
                else
                {
                    db.Orders.Remove(queryOrder);
                }
               int tmpIndex = index_listview_position_buyer_sellerWin;
                db.SaveChanges();
                LoadBooks();               
                LoadBuyersList();
                index_listview_position_buyer_sellerWin = tmpIndex;
                LoadBookInOrder();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanDelBookFromOrder()
        {
            return (index_book_in_order_list_for_delete != -1);
        }

        //Buyer add Book
    
    private DelegateCommand addBuyerBookToOrderCommand;
    public ICommand AddBuyerBookToOrderCommand
    {
        get
        {
            if (addBuyerBookToOrderCommand == null)
            {
                addBuyerBookToOrderCommand = new DelegateCommand(param => this.AddBuyerBookToOrder(), param => this.CanAddBuyerBookToOrder());
            }
            return addBuyerBookToOrderCommand;
        }
    }
    private void AddBuyerBookToOrder()
    {
            try
            {
                int idBook = BooksList[Index_selected_listbox_Books].Id;////////////////////////////////////

                var queryBookAv = (from b in db.BooksAvailables
                                   where b.Book.Id == idBook
                                   select b).Single();

                if (queryBookAv.Count_Book < 1)
                {
                    ExceptionWindow exc = new ExceptionWindow("There are not so many books available!");
                    exc.Show();
                }
                else
                {

                    var queryBook = (from b in db.Books
                                     where b.Id == idBook
                                     select b).Single();

                    int idAccount = Id_for_Account_OrderList;
                    var queryAccount = (from b in db.Accounts
                                        where b.Id == idAccount
                                        select b).Single();


                    var queryOrder = (from b in db.Orders
                                      where b.Book.Id == idBook && b.Account.Id == idAccount
                                      select b).ToList();
                    if (queryOrder.Count != 0)
                    {
                        var queryOrder1 = (from b in db.Orders
                                           where b.Book.Id == idBook && b.Account.Id == idAccount
                                           select b).Single();
                        queryOrder1.Count_Book++;
                    }
                    else
                    {
                        Order tmp = new Order
                        {
                            Count_Book = 1,
                            Book = queryBook,
                            Account = queryAccount
                        };
                        db.Orders.Add(tmp);
                    }



                    queryBookAv.Count_Book--;

                    db.SaveChanges();
                    LoadOrders();
                    LoadBooks();
                    LoadAccountBookInOrder();
                    CountPriceInOrderBuyer();
                }
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
    private bool CanAddBuyerBookToOrder()
    {
        return (Index_selected_listbox_Books != -1);
    }
        //delete Buyer book from order

        int index_book_in_order_list_for_delete_buyer = -1;

        public int Index_book_in_order_list_for_delete_buyer
        {
            get { return index_book_in_order_list_for_delete_buyer; }
            set
            {
                index_book_in_order_list_for_delete_buyer = value;
                OnPropertyChanged(nameof(Index_book_in_order_list_for_delete_buyer));
            }
        }

        private DelegateCommand deleteBuyerBookToOrderCommand;
        public ICommand DeleteBuyerBookToOrderCommand
        {
            get
            {
                if (deleteBuyerBookToOrderCommand == null)
                {
                    deleteBuyerBookToOrderCommand = new DelegateCommand(param => this.DeleteBuyerBookToOrder(), param => this.CanDeleteBuyerBookToOrder());
                }
                return deleteBuyerBookToOrderCommand;
            }
        }
        private void DeleteBuyerBookToOrder()
        {
            try 
            { 
                int idOder = AccountBookInOrder[Index_book_in_order_list_for_delete_buyer].Id;

                var queryOrder = (from b in db.Orders.Include("Book")
                                  where b.Id == idOder
                                  select b).Single();

                int idBookRem = queryOrder.Book.Id;
                var queryBookAv = (from b in db.BooksAvailables
                                   where b.Id == idBookRem
                                   select b).Single();

                queryBookAv.Count_Book++;

                if (queryOrder.Count_Book > 1)
                {
                    queryOrder.Count_Book--;
                }
                else
                {
                    db.Orders.Remove(queryOrder);
                }
              //  int tmpIndex = index_listview_position_buyer_sellerWin;
                db.SaveChanges();
                LoadBooks();
               // LoadBuyersList();
              //  index_listview_position_buyer_sellerWin = tmpIndex;
                LoadAccountBookInOrder();
                CountPriceInOrderBuyer();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
}
        private bool CanDeleteBuyerBookToOrder()
        {
            return (Index_book_in_order_list_for_delete_buyer != -1);
        }

        //=====Buy

        private DelegateCommand buyCommand;
        public ICommand BuyCommand
        {
            get
            {
                if (buyCommand == null)
                {
                    buyCommand = new DelegateCommand(param => this.Buy(), param => this.CanBuy());
                }
                return buyCommand;
            }
        }
        private void Buy()
        {
            try
            {
                var query = (from b in db.Orders
                             where b.Account.Id == Id_for_Account_OrderList
                             select b).ToList();

                foreach (Order i in query)
                {

                    Purchase tmp = new Purchase

                    {
                        Id = i.Id,
                        Account = i.Account,
                        Book = i.Book,
                        Count_Book = i.Count_Book,
                        DateTime = DateTime.Now,
                        Author = i.Book.Author,
                        Genre = i.Book.Genre
                        

                    };
                   
                    db.Purchases.Add(tmp);
                    
                }
                for (int i = query.Count - 1; i >= 0; i--)
                {
                    db.Orders.Remove(query[i]);
                }
            
                db.SaveChanges();
                CountPriceInOrderBuyer();
                LoadAccountBookInOrder();
            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanBuy()
        {
            return (AccountBookInOrder.Count != 0);
        }

        private void CountPriceInOrderBuyer()
        {
            int idaccount = Id_for_Account_OrderList;

            var queryOrderCheck = (from b in db.Orders
                              where b.Account.Id == idaccount
                              select b).ToList();
            if (queryOrderCheck.Count != 0)
            {
                var queryOrder = (from b in db.Orders
                                  where b.Account.Id == idaccount
                                  select b.Count_Book).Sum();
                CountBookInOrderBuyer = queryOrder;
            }
            else
            {
                CountBookInOrderBuyer = 0;
            }
            var queryAccount = (from b in db.Accounts.Include("Orders")
                               where b.Id == idaccount
                               select b).Single();

            double priceBIO = 0;
            foreach (Order i in queryAccount.Orders)
            {
                if (i.Book.Stock == null)
                {
                    priceBIO += (i.Book.Cost_price + i.Book.Cost_price * 0.3) * i.Count_Book;
                }
                else
                {
                    priceBIO += (i.Book.Cost_price + i.Book.Cost_price * 0.3 - i.Book.Cost_price / 100 * i.Book.Stock.PercentageDiscount) * i.Count_Book;
                }

            }
            PriceBookInOrderBuyer = priceBIO;
        }

        int countBookInOrderBuyer = 0;

        public int CountBookInOrderBuyer
        {
            get { return countBookInOrderBuyer; }
            set
            {
                countBookInOrderBuyer = value;
                OnPropertyChanged(nameof(CountBookInOrderBuyer));
            }
        }
        double priceBookInOrderBuyer = 0;
        public double PriceBookInOrderBuyer
        {
            get { return priceBookInOrderBuyer; }
            set
            {
                priceBookInOrderBuyer = value;
                OnPropertyChanged(nameof(PriceBookInOrderBuyer));
            }
        }

        //===Most Popular

        int index_combobox_popular_search_param = -1;

        public int Index_combobox_popular_search_param
        {
            get { return index_combobox_popular_search_param; }
            set
            {
                index_combobox_popular_search_param = value;
                OnPropertyChanged(nameof(Index_combobox_popular_search_param));
            }
        }
        int index_combobox_popular_search_time = -1;

        public int Index_combobox_popular_search_time
        {
            get { return index_combobox_popular_search_time; }
            set
            {
                index_combobox_popular_search_time = value;
                OnPropertyChanged(nameof(Index_combobox_popular_search_time));
            }
        }

        private string result_popular_search = null;

        public string Result_popular_search
        {
            get { return result_popular_search; }
            set
            {
                result_popular_search = value;
                OnPropertyChanged(nameof(Result_popular_search));
            }
        }

        private string count_popular_search = null;

        public string Count_popular_search
        {
            get { return count_popular_search; }
            set
            {
                count_popular_search = value;
                OnPropertyChanged(nameof(Count_popular_search));
            }
        }

        private DelegateCommand searchPopularCommand;
        public ICommand SearchPopularCommand
        {
            get
            {
                if (searchPopularCommand == null)
                {
                    searchPopularCommand = new DelegateCommand(param => this.SearchPopular(), param => this.CanSearchPopular());
                }
                return searchPopularCommand;
            }
        }
        private void SearchPopular()
        {
            try
            {
                DateTime endR = DateTime.Now;
                DateTime startR = new DateTime(DateTime.MinValue.Ticks);


                if (index_combobox_popular_search_time == 0)
                {
                    int year_ = endR.Year;
                    int month_ = endR.Month;
                    int day_ = endR.Day;
                    startR = new DateTime(year_, month_, day_);
                }
                if (index_combobox_popular_search_time == 1)
                {
                    int year_ = endR.Year;
                    int month_ = endR.Month;
                    int day_ = endR.Day;
                    startR = new DateTime(year_, month_, day_);
                    int dt = (int)DateTime.Now.DayOfWeek;
                    startR = startR.AddDays(-dt);

                }

                if (index_combobox_popular_search_time == 2)
                {
                    int year_ = endR.Year;
                    int month_ = endR.Month;
                    int day_ = 1;
                    startR = new DateTime(year_, month_, day_);
                }
                if (index_combobox_popular_search_time == 3)
                {
                    int year_ = endR.Year;
                    int month_ = 1;
                    int day_ = 1;
                    startR = new DateTime(year_, month_, day_);
                }


                if (index_combobox_popular_search_param == 0)
                {
                    var query = (from pur in db.Purchases.Include("Book").Include("Account")
                                where pur.DateTime > startR && pur.DateTime < endR
                                group pur by pur.Book into g
                                select new { NameBook = g.Key.Name, Sum = g.Sum(a => a.Count_Book)}).ToList();

                    int maxCountBook = query.Max(a => a.Sum);

                    var resBook = (from b in query
                                   where b.Sum == maxCountBook
                                   select b).Single();
                    Result_popular_search = resBook.NameBook;
                    Count_popular_search = maxCountBook.ToString();
                }

                if (index_combobox_popular_search_param == 1)
                {
                    var query = (from pur in db.Purchases.Include("Book").Include("Account")
                                 where pur.DateTime > startR && pur.DateTime < endR
                                 group pur by pur.Author into g
                                 select new { NameAuthor = g.Key.Name, Sum = g.Sum(a => a.Count_Book) }).ToList();

                    int maxCountBook = query.Max(a => a.Sum);

                    var resBook = (from b in query
                                   where b.Sum == maxCountBook
                                   select b).Single();
                    Result_popular_search = resBook.NameAuthor;
                    Count_popular_search = maxCountBook.ToString();
                }
                if (index_combobox_popular_search_param == 2)
                {
                    var query = (from pur in db.Purchases.Include("Book").Include("Account")
                                 where pur.DateTime > startR && pur.DateTime < endR
                                 group pur by pur.Genre into g
                                 select new { NameGenre = g.Key.Name, Sum = g.Sum(a => a.Count_Book) }).ToList();

                    int maxCountBook = query.Max(a => a.Sum);

                    var resBook = (from b in query
                                   where b.Sum == maxCountBook
                                   select b).Single();
                    Result_popular_search = resBook.NameGenre;
                    Count_popular_search = maxCountBook.ToString();
                }

                Index_combobox_popular_search_time = -1;
                Index_combobox_popular_search_param = -1;




                //  var result2 = queryAll.GroupBy(p => p.Book).Select(g => new {  = g.Key, Sum = g.Sum() });
                //var queryBookAv = (from b in db.BooksAvailables
                //                   where b.Book.Id == idBook
                //                   select b).Single();

                //if (Index_combobox_popular_search_time != -1)
                //{
                //    var que = (from c in queryAll
                //               where c.DateTime>startR && c.DateTime<endR
                //               select c).ToList();

                //}


            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private bool CanSearchPopular()
        {
            return (Index_combobox_popular_search_param != -1);
        }

        

        private DelegateCommand deleteBookFromDBCommand;
        public ICommand DeleteBookFromDBCommand
        {
            get
            {
                if (deleteBookFromDBCommand == null)
                {
                    deleteBookFromDBCommand = new DelegateCommand(param => this.DeleteBookFromDB(), null);
                }
                return deleteBookFromDBCommand;
            }
        }
        private void DeleteBookFromDB()
        {
            try
            {

                int idDel = BooksList[index_selected_listbox_Books].Id;
                var query = from b in db.Books
                            where b.Id == idDel
                            select b;
                db.Books.RemoveRange(query);
                db.SaveChanges();

                BooksList.RemoveAt(index_selected_listbox_Books);
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter("../../ExceptionDEL.txt", false);
                string line = ex.ToString();
                sw.WriteLine(line);
                sw.Close();

            }
        }
       
        private DelegateCommand deleteLanguageCommand;
        public ICommand DeleteLanguageCommand
        {
            get
            {
                if (deleteLanguageCommand == null)
                {
                    deleteLanguageCommand = new DelegateCommand(param => this.DeleteLanguage(), null);
                }
                return deleteLanguageCommand;
            }
        }
        private void DeleteLanguage()
        {
            try
            {
                int idDel = LanguagesList[index_selected_listbox_EditRemove_Language].Id;
                var query = from b in db.Languages
                            where b.Id == idDel
                            select b;
                db.Languages.RemoveRange(query);
                db.SaveChanges();

                LanguagesList.RemoveAt(index_selected_listbox_EditRemove_Language);

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }


        private DelegateCommand deleteGenreCommand;
        public ICommand DeleteGenreCommand
        {
            get
            {
                if (deleteGenreCommand == null)
                {
                    deleteGenreCommand = new DelegateCommand(param => this.DeleteGenre(), null);
                }
                return deleteGenreCommand;
            }
        }
        private void DeleteGenre()
        {
            try
            {
                int idDel = GenresList[index_selected_listbox_EditRemove_Genre].Id;
                var query = from b in db.Genres
                            where b.Id == idDel
                            select b;
                db.Genres.RemoveRange(query);
                db.SaveChanges();

                GenresList.RemoveAt(index_selected_listbox_EditRemove_Genre);

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }
        private DelegateCommand deletePublishingCommand;
        public ICommand DeletePublishingCommand
        {
            get
            {
                if (deletePublishingCommand == null)
                {
                    deletePublishingCommand = new DelegateCommand(param => this.DeletePublishing(), null);
                }
                return deletePublishingCommand;
            }
        }
        private void DeletePublishing()
        {
            try
            {
                int idDel = PublishingsList[index_selected_listbox_EditRemove_Publishing].Id;
                var query = from b in db.Publishings
                            where b.Id == idDel
                            select b;
                db.Publishings.RemoveRange(query);
                db.SaveChanges();

                PublishingsList.RemoveAt(index_selected_listbox_EditRemove_Publishing);

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }

        private DelegateCommand deleteAuthorCommand;
        public ICommand DeleteAuthorCommand
        {
            get
            {
                if (deleteAuthorCommand == null)
                {
                    deleteAuthorCommand = new DelegateCommand(param => this.DeleteAuthor(), null);
                }
                return deleteAuthorCommand;
            }
        }
        private void DeleteAuthor()
        {
            try
            {
                int idDel = AuthorsList[index_selected_listbox_EditRemove_Author].Id;
                var query = from b in db.Authors
                            where b.Id == idDel
                            select b;
                db.Authors.RemoveRange(query);
                db.SaveChanges();

                AuthorsList.RemoveAt(index_selected_listbox_EditRemove_Author);

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }

        private DelegateCommand deleteStockCommand;
        public ICommand DeleteStockCommand
        {
            get
            {
                if (deleteStockCommand == null)
                {
                    deleteStockCommand = new DelegateCommand(param => this.DeleteStock(), null);
                }
                return deleteStockCommand;
            }
        }
        private void DeleteStock()
        {
            try
            {
                int idDel = StocksList[index_selected_listbox_EditRemove_Stock].Id;
                var query = from b in db.Stocks
                            where b.Id == idDel
                            select b;
                db.Stocks.RemoveRange(query);
                db.SaveChanges();
                LoadStocks();
                LoadBooks();

            }
            catch (Exception ex)
            {
                ExceptionWindow exc = new ExceptionWindow(ex.ToString());
                exc.Show();
            }
        }

        private DelegateCommand deleteAccountCommand;
        public ICommand DeleteAccountCommand
        {
            get
            {
                if (deleteAccountCommand == null)
                {
                    deleteAccountCommand = new DelegateCommand(param => this.DeleteAccount(), null);
                }
                return deleteAccountCommand;
            }
        }
        private void DeleteAccount()
        {
            try
            {
                int idAccount = AccountsList[index_selected_listbox_Accounts].Id;
                var query = (from b in db.Accounts.Include("Orders")
                             where b.Id == idAccount
                             select b).Single();
                if (query.Orders.Count != 0)
                {
                    foreach (Order c in query.Orders)
                    {
                        int idBook = c.Book.Id;
                        var queryBookAv = (from b in db.BooksAvailables.Include("Book")
                                           where b.Book.Id == idBook
                                           select b).Single();
                        queryBookAv.Count_Book += c.Count_Book;
                    }
                }

                db.Accounts.Remove(query);
                db.SaveChanges();
                LoadBooks();
                LoadAccounts();
            }
            catch (Exception ex)
            {
                StreamWriter sw = new StreamWriter("../../ExceptionDEL.txt", false);
                string line = ex.ToString();
                sw.WriteLine(line);
                sw.Close();

            }
        }
    }
}
