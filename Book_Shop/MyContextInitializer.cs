using System.Data.Entity;

namespace Book_Shop
{
    class MyContextInitializer : CreateDatabaseIfNotExists<ContextDB>
    {
        protected override void Seed(ContextDB db)
        {
            var admin = new Position
            {
                Name = "Administrator"
            };
            db.Positions.Add(admin);

            var buyer = new Position
            {
                Name = "Buyer"
            };
            db.Positions.Add(buyer);

            var seller = new Position
            {
                Name = "Seller"
            };
            db.Positions.Add(seller);
            //-----Administrator
            var accA = new Account
            {
                FirstName = "Алексей",
                LastName = "Бугайцов",
                Login = "1",
                Password = "1",
                Position = admin

            };
            db.Accounts.Add(accA);

            
            //----Buyer
            var accB = new Account
            {
                FirstName = "Полина",
                LastName = "Бугайцова",
                Login = "2",
                Password = "2",
                Position = buyer
            };
            db.Accounts.Add(accB);

            //----Seller
            var accS = new Account
            {
                FirstName = "Марианна",
                LastName = "Бугайцова",
                Login = "3",
                Password = "3",
                Position = seller
            };
            db.Accounts.Add(accS);
           
            //====Жанр

            var genre1 = new Genre { Name = "Фантастика" };
            var genre2 = new Genre { Name = "Детектив" };
            var genre3 = new Genre { Name = "Мелодрама" };
            var genre4 = new Genre { Name = "Научная литература" };
            var genre5 = new Genre { Name = "Фэнтези" };
            var genre6 = new Genre { Name = "Триллер" };
            var genre7 = new Genre { Name = "Классика" };
            var genre8 = new Genre { Name = "Справочная литература" };
            var genre9 = new Genre { Name = "Программирование" };
            db.Genres.Add(genre1);
            db.Genres.Add(genre2);
            db.Genres.Add(genre3);
            db.Genres.Add(genre4);
            db.Genres.Add(genre5);
            db.Genres.Add(genre6);
            db.Genres.Add(genre7);
            db.Genres.Add(genre8);
            db.Genres.Add(genre9);

            //--Языки
            var language1 = new Language { Name = "Ukr" };
            var language2 = new Language { Name = "Rus" };
            var language3 = new Language { Name = "Eng" };
            db.Languages.Add(language1);
            db.Languages.Add(language2);
            db.Languages.Add(language3);
            //===Издательства

            var edit1 = new Publishing { Name = "Ранок" };
            var edit2 = new Publishing { Name = "Генеза" };
            var edit3 = new Publishing { Name = "Учебники и пособия" };
            var edit4 = new Publishing { Name = "Иглмосс Эдишинз" };
            var edit5 = new Publishing { Name = "Освита" };
            var edit6 = new Publishing { Name = "Грамота" };
            var edit7 = new Publishing { Name = "Фолио" };
            var edit8 = new Publishing { Name = "Картография" };
            var edit9 = new Publishing { Name = "Морион" };
            var edit10 = new Publishing { Name = "Эгмонт Украина" };
            var edit11 = new Publishing { Name = "BHV" };
            db.Publishings.Add(edit1);
            db.Publishings.Add(edit2);
            db.Publishings.Add(edit3);
            db.Publishings.Add(edit4);
            db.Publishings.Add(edit5);
            db.Publishings.Add(edit6);
            db.Publishings.Add(edit7);
            db.Publishings.Add(edit8);
            db.Publishings.Add(edit9);
            db.Publishings.Add(edit10);
            db.Publishings.Add(edit11);

            //--- Акции

            var stock1 = new Stock { Name = "Super Stock", PercentageDiscount = 10 };
            var stock2 = new Stock { Name = "New Years", PercentageDiscount = 7 };
            db.Stocks.Add(stock1);
            db.Stocks.Add(stock2);

            //---- Авторы

            var author1 = new Author {  Name = "Ден Браун" };
            var author3 = new Author { Name = "Стив Макконнелл" };
            var author2 = new Author {Name = "Герберт Уеллс" };
            var author4 = new Author { Name = "Стивен Прата" };
            var author5 = new Author { Name = "Метью МакДональд" };
            var author6 = new Author { Name = "Эрик Фримен" };
            var author7 = new Author { Name = "Джеффри Рихтер" };

            db.Authors.Add(author1);
            db.Authors.Add(author3);
            db.Authors.Add(author2);
            db.Authors.Add(author4);
            db.Authors.Add(author5);
            db.Authors.Add(author6);
            db.Authors.Add(author7);

            var book1 = new Book
            {
                Name = "Ангелы и демоны",
                Author = author1,
                Year_edit = 2000,
                Pages = 400,
                Language = language1,
                Cost_price = 300,
                Publishing = edit1,
                Genre = genre1,
                Stock = stock1
            };
            db.Books.Add(book1);

            var bookAvaib1 = new BooksAvailable
            {
                Book = book1,
                Count_Book = 10
            };
            db.BooksAvailables.Add(bookAvaib1);

            var book2 = new Book
            {
                Name = "CLR via C#. Программирование на платформе Microsoft .NET Framework 4.5 на языке C#",
                Author = author7,
                Year_edit = 2010,
                Pages = 400,
                Language = language1,
                Cost_price = 900,
                Publishing = edit1,
                Genre = genre9,
                Stock = stock1
            };

            db.Books.Add(book2);

            var bookAvaib2 = new BooksAvailable
            {
                Book = book2,
                Count_Book = 10
            };
            db.BooksAvailables.Add(bookAvaib2);

            var book3 = new Book
            {
                Name = "Язык программирования С++",
                Author = author4,
                Year_edit = 1999,
                Pages = 300,
                Language = language1,
                Cost_price = 700,
                Publishing = edit5,
                Genre = genre9,
                Stock = stock1
            };
            db.Books.Add(book3);

            var bookAvaib3 = new BooksAvailable
            {
                Book = book3,
                Count_Book = 10
            };
            db.BooksAvailables.Add(bookAvaib3);

            var book4 = new Book
            {
                Name = "Паттерны проектирования",
                Author = author6,
                Year_edit = 2000,
                Pages = 400,
                Language = language1,
                Cost_price = 300,
                Publishing = edit1,
                Genre = genre9,
                Stock = stock1
            };
            db.Books.Add(book4);

            var bookAvaib4 = new BooksAvailable
            {
                Book = book4,
                Count_Book = 10
            };
            db.BooksAvailables.Add(bookAvaib4);

            db.SaveChanges();
        }
    }
}
