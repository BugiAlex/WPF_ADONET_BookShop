using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;


namespace Book_Shop
{
    class ContextDB : DbContext
    {
        static ContextDB()
        {
            Database.SetInitializer(new MyContextInitializer());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publishing> Publishings { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Account> Accounts { get; set; }                 
        public DbSet<Language> Languages { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<BooksAvailable> BooksAvailables { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
    }
}
